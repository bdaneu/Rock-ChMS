SELECT 
  p.[Name] as [Page.Name],
  p.[Title] as [Page.Title],
  p.[Guid] as [Page.Guid],
  p.[Layout] as [Page.Layout],
  parentPage.[Name] as [ParentPage.Name],
  parentPage.[Guid] as [ParentPage.Guid],
  p.[Order]
FROM 
  [Page] p
join [Page] parentPage on p.ParentPageId = parentPage.Id
order by [p].[Name]


