add-migration-linux:
	@read -p "Nome da migration (ex: TipoTabelaMotivo) : " table \
	&& dotnet ef --startup-project ../TccBackendUmc.WebApi migrations add $${table}

remove-migration-linux:
	dotnet ef --startup-project ../TccBackendUmc.WebApi migrations remove

update-database:
	@echo "Você revisou a migration antes de enviar?"
	@read -p "[Enter para confimar || CTRL + C para cancelar]" reponse;
	dotnet ef --startup-project ../TccBackendUmc.Api database update