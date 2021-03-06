/* Help Code Gen an AddPage for a migration.  Recently added pages will be listed last */
SELECT 
  'AddPage("' + CONVERT(nvarchar(50), parentPage.Guid) + '","' + p.Name +  '","' +  p.Description +  '","' +  CONVERT(nvarchar(50), p.Guid) + '");'
FROM 
  [Page] p
join [Page] parentPage on p.ParentPageId = parentPage.Id
order by p.Id desc
