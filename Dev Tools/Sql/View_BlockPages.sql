SELECT b.Id [Block.Id],
       p.[Title] [Page.Title], 
       b.[Name] [Block.Name],
       b.Zone [Block.Zone],
       b.Guid [Block.Guid],
       bt.[Name] [BlockType.Name],
       bt.[Guid] [BlockType.Guid],
       bt.[Path],
       p.[Guid] [Page.Guid]
  FROM [BlockType] [bt]
  left outer join [Block] [b] on [bt].[Id] = [b].[BlockTypeId]  
  left outer join [Page] [p] on [p].[Id] = [b].[PageId]
  --where bt.[Path] like '%Workflow%'
  order by b.Id, b.Name, p.Name
