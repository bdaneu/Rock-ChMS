set nocount on
declare
@crlf varchar(2) = char(13) + char(10)
declare
@codeTable TABLE
(
    CodeText nvarchar(max)
)
begin
    -- pages
    insert into @codeTable
    SELECT '            AddPage("' +
        CONVERT( nvarchar(50), [parentPage].[Guid]) + '","'+ 
        [p].[Name] +  '","'+  
        ISNULL([p].[Description],'')+  '","'+
        [p].[Layout] +  '","'+
        CONVERT( nvarchar(50), [p].[Guid])+ '");'
    FROM 
      [Page] p
    join [Page] [parentPage] on [p].[ParentPageId] = [parentPage].[Id]
    where [p].[IsSystem] = 0
    order by [p].[Id]
    
    -- block types
    insert into @codeTable
    SELECT '            AddBlockType("'+
        [Name]+ '","'+  
        ISNULL([Description],'')+ '","'+  
        [Path]+ '","'+  
        CONVERT( nvarchar(50),[Guid])+ '");'
    from [BlockType]
    where [IsSystem] = 0
    order by [Id]

    -- blocks
    insert into @codeTable
    SELECT
        '            AddBlock("'+
        CONVERT(nvarchar(50), [p].[Guid])+ '","'+ 
        CONVERT(nvarchar(50), [bt].[Guid])+ '","'+
        [b].[Name]+ '","'+
        ISNULL([b].[Layout],'')+ '","'+
        [b].[Zone]+ '",'+
        CONVERT(varchar, [b].[Order])+ ',"'+
        CONVERT(nvarchar(50), [b].[Guid])+ '");'
    from [Block] [b]
    left outer join [Page] [p] on [p].[Id] = [b].[PageId]
    join [BlockType] [bt] on [bt].[Id] = [b].[BlockTypeId]
    where 
      [b].[IsSystem] = 0
    order by [b].[Id]

    -- attributes
    if object_id('tempdb..#attributeIds') is not null
    begin
      drop table #attributeIds
    end

    select * into #attributeIds from (select [Id] from [dbo].[Attribute] where [IsSystem] = 0) [newattribs]
    
    insert into @codeTable
    SELECT 
        '            AddBlockTypeAttribute("'+ 
        CONVERT(nvarchar(50), bt.Guid)+ '","'+   
        CONVERT(nvarchar(50), ft.Guid)+ '","'+   
        a.name+ '","'+  
        a.[Key]+ '","'+ 
        ISNULL(a.Category,'')+ '","'+ 
        ISNULL(a.Description,'')+ '",'+ 
        CONVERT(varchar, a.[Order])+ ',"'+ 
        ISNULL(a.DefaultValue,'')+ '","'+ 
        CONVERT(nvarchar(50), a.Guid)+ '");'
    from [Attribute] [a]
    left outer join [FieldType] [ft] on [ft].[Id] = [a].[FieldTypeId]
    left outer join [BlockType] [bt] on [bt].[Id] = cast([a].[EntityTypeQualifierValue] as int)
    where EntityTypeQualifierColumn = 'BlockTypeId'
    and [a].[id] in (select [Id] from #attributeIds)

    -- attributes values    
    insert into @codeTable
    SELECT 
        '            // Attrib Value for '+ b.Name+ ':'+ a.Name+
        @crlf +
        '            AddBlockAttributeValue("'+     
        CONVERT(nvarchar(50), b.Guid)+ '","'+ 
        CONVERT(nvarchar(50), a.Guid)+ '","'+ 
        av.Value + '");'+
        @crlf
    from [AttributeValue] [av]
    join Block b on b.Id = av.EntityId
    join Attribute a on a.id = av.AttributeId
    where ([av].[AttributeId] in (select [Id] from #attributeIds))
    or (b.IsSystem = 0)

    drop table #attributeIds

    select CodeText [MigrationUp] from @codeTable
    delete from @codeTable

    -- generate MigrationDown

    insert into @codeTable SELECT '            DeleteAttribute("'+ CONVERT(nvarchar(50), [Guid])+ '"); // '+ [Name]  from [Attribute] where [IsSystem] = 0 order by [Id]    
    insert into @codeTable SELECT '            DeleteBlock("'+ CONVERT(nvarchar(50), [Guid])+ '"); // '+ [Name] from [Block] where [IsSystem] = 0 order by [Id]
    insert into @codeTable SELECT '            DeleteBlockType("'+ CONVERT(nvarchar(50), [Guid])+ '"); // '+ [Name] from [BlockType] where [IsSystem] = 0 order by [Id]
    insert into @codeTable SELECT '            DeletePage("'+ CONVERT(nvarchar(50), [Guid])+ '"); // '+ [Name]  from [Page] where [IsSystem] = 0 order by [Id] asc 

    select CodeText [MigrationDown] from @codeTable
end


