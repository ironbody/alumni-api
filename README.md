# AlumniAPI

Deployed at https://case-alumni-api.azurewebsites.net

[API Documentation](https://case-alumni-api.azurewebsites.net/swagger/index.html)

# Deployment

## Keycloak

You need a keycloak instance for this API to work properly.
When you have one set up, if you are running this locally create a `.env` file in the API's root folder (not the repository's root),
if you are running this on a cloud VM, add the variables to the cloud provider's built in env variable system.

Add the following variables:

`TOKEN_KEYURI=https://<keycloak instance url>/auth/realms/<realm id>/protocol/openid-connect/certs`

`TOKEN_ISSUERURI=https://<keycloak instance url>/auth/realms/<realm id>`

## Cloud

There is a GitHub workflow that automatically builds and pushes the project to dockerhub.
To configure this, add `DOCKER_PASSWORD` and `DOCKER_USERNAME` secrets
to the project's repository secrets on GitHub.
The resulting docker image will be pushed to `${DOCKER_USERNAME}/alumni-api:latest`.

When the workflow has been configured, you can easily set up an App Service on Azure
that retrieves the latest image using a webhook and runs it on a VM. 
Don't forget to add the keycloak environment variables as above to the app VM.

This project requires a Microsoft SQL server database. You can set one up on Azure and insert its connection string
as `DefaultConnection` within the app VM's connection strings.

## Local

Make sure there is a Microsoft SQL server instance running and add its connection string to either 
the `appsettings.json` file or make an `appsettings.Development.json` file and add it to there.

# Contributors

Erik Rundberg - [GitHub](https://github.com/ErikRundberg)

Oscar Nordström - [GitHub](https://github.com/Oscar-Nordstrom)

Simon Saberian - [GitHub](https://github.com/ironbody)

# License

[Unlicense](https://choosealicense.com/licenses/unlicense/)
