project=UpemProject
cc=dotnet

run:
	$(cc) run --project $(project)

watch:
	$(cc) watch run --project $(project)

migration:
	$(cc) ef migrations add $(name) -p $(project)
	$(cc) ef database update -p $(project)
