project=UpemProject

migration:
	dotnet ef migrations add $(name) -p $(project)
	dotnet ef database update -p $(project)
