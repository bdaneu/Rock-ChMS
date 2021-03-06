begin
  SELECT 'INSERT INTO [dbo].[PageContext]([IsSystem],[PageId],[Entity],[IdParameter],[CreatedDateTime],[Guid])
     VALUES(1
           ,(select [Id] from [Page] where [Guid] = ''' + CONVERT( nvarchar(50), [p].[Guid]) +  ''')
           ,''' + [pc].[Entity] + '''
           ,''' + [pc].[IdParameter] +'''
           ,SYSDATETIME()
           ,'''+ CONVERT( nvarchar(50), NEWID()) +''')' as [MigrateUp]
  FROM [dbo].[PageContext] [pc]
  join [Page] [p]
  on [p].[Id] = [pc].[PageId]
  where [pc].[IsSystem] = 0

  SELECT 'DELETE FROM [dbo].[PageContext] where [Guid] = '''+ CONVERT( nvarchar(50), [Guid]) + '''' as [MigrateDown] 
  from dbo.PageContext where IsSystem = 0

end

