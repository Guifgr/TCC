start:
	gnome-terminal -- sh -c "dotnet run --arch x64 --os linux --project ./Backend/TccUmc.Api/TccUmc.Api.csproj" \
	&& npm start --prefix NewFrontend
	
