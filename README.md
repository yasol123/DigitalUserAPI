# UserAccountManagementAPI

This user account management api is a part of microservices APIs.

Progress:
1. User account's bearer token generation feature has been implemented.
2. Created User account, API Response types classes etc
3. Implemented a dependency injection between JWT and account controller.

Project Structure:
Yasol.DigitalUser.API: controllers
Yasol.DigitalUser.Business: business logic implementation
Yasol.DigitalUser.Common: core, enums, security (Cosmos DB Context, DB repository, Azure KeyVault will be implemented in this solution)
Yasol.DigitalUser.Model: all business entities, types, request, response etc

Next Goals (Target Date: TBD):
Implement a login, registration, update profile, update address, update contact information APIs
Implement an Azure Cosmos DB Connection on the SIT/UAT environment
Implement a KeyVault to be authenticated.
Implement an ADB2C feature for user accounts.
