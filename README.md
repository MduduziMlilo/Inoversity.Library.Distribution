# Inoversity Library Web Api


Inoversity Library **Web Api** built in C# using the
`Ports & Adapters` architecture, aka `Clean Architecture`.

<img src="./assets/applicationArchitecture.svg" alt="Microservice Architecture">

## Developer Setup Guide

> **_INFO:_** The project requires .NET 7. To install dotnet, head
> over to [microsoft](https://dotnet.microsoft.com/en-us/download) for installation details.

This section outlines the development setup of the `Inoversity Library Web Api`. If you're not
a shell fan, you can accomplish the same outcome (getting to build the project) using your preferred IDE.

1. Clone the repository to your development environment.
    ```
    git clone <repository_url>
    ```
2. Set working directory.
    ```
    cd ./Inoversity.Library.WebApi/InoversityLibrary/
    ```
3. Restore dependencies.
    ```
    dotnet restore .
    ```
4. Build up the project solution.
    ```
    dotnet build .
    ```

That will be all. Code ahead.

## Docker Setup Guide

This section outlines the setup for a docker container.

## Stack Overview

### Overall
| Library | Description | External Content |
|---------|-------------|------------------|

### API Server
| Library                                 | Description            | External Content                                                                                     |
|-----------------------------------------|------------------------|------------------------------------------------------------------------------------------------------|

### Testing
| Library                                                              | Description                 | External Content                                                                                                                                     |
|----------------------------------------------------------------------|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|

### Database Migrations
| Library     | Description         | External Content                 |
|-------------|---------------------|----------------------------------|

## Features
### Included
- [X] Conventional commits
- [X] Github actions [Continuous Integration](https://www.atlassian.com/continuous-delivery/continuous-integration)
- [X] Automatic semantic versioning
- [X] Standard branch name format

### Feature Backlog
- [ ] UnitTesting
- [ ] Authentication
- [ ] Documentation
- [ ] Authorisation
- [ ] ORM
- [ ] Database migrations
- [ ] Kubernetes cluster integration [Continuous Deployment](https://www.atlassian.com/continuous-delivery/principles/continuous-integration-vs-delivery-vs-deployment)
- [ ] Event messaging integration
- [ ] Api Stress Testing

## Domain Rules
 
1. Have a list of users.  
   - A user can loan document(s) from the library.
   - A user is restricted to be in possession a maximum of five documents loaned from the library.
   - A user can not loan copies of a document they have checked out.
   - Only a registered user can checkout a library document.
   - A user can not return a document they did not check out.
   - A user can book a document for checkout at a future date (Not longer than 60 days from booking date).
2. Have a list of documents in the library.
   - The library keeps different types of documents.
   - The number of copies of each document is assumed to be infinity.
   - Some documents can only be viewed within the library premises (i.e can not be checked out).
3. Have a list of accounts accounts to users.
   - An account can only be linked to a unique library user.
   - Charges are applied on accounts with overdue documents.