project=Backend
cc=dotnet

run:
	$(cc) run --project $(project)

watch:
	$(cc) watch run --project $(project)

migrate:
	$(cc) ef migrations add $(name) -p $(project)
	$(cc) ef database update -p $(project)

new:
	$(cc) new $(template) -o $(name)
	$(cc) sln add $(name)

new-sln:
	$(cc) new sln

restore:
	$(cc) restore -v d --disable-parallel
