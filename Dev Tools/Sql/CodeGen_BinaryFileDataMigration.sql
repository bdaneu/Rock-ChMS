select concat('
            Sql( @"','
INSERT INTO [dbo].[BinaryFile] ([IsTemporary],[IsSystem],[Data],[Url],[FileName],[MimeType],[LastModifiedTime],[Description],[Guid])
     VALUES (0,0','',convert(nvarchar(max), data, 1 ),'
             '',''',[Url],''',''',[FileName],''',''',[MimeType],''',SYSDATETIME(),''',[Description],''',''',[Guid],''')', '
             " );') [MigrateUp], 
    concat('Sql (@"delete from [BinaryFile] where [Guid] = ''', [Guid], '''");') [MigrateDown],
             [FileName], [Id]
  FROM [RockChMS_dev01].[dbo].[BinaryFile]








            