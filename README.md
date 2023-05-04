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
   - A user can borrow documents from the library for research.
   - If a user is not part of the users in the system, they should not be able to borrow documents.
   - A user should be only restricted to possess a maximum 5 documents from the library at a time.
   - Should a user have 5 documents in their posession, they can return documents to the library if they want to borrow other documents.
   - A user should not be able to borrow documents that they already have.
2. Have a list of documents in the library.
   - The library can have different types of documents.
   - Copies of each document is assumed to be infinity (i.e a lot of users can borrow the same document without running out of copies.)
3. Have a list of accounts accounts to users.
   - Each user in the system should only be linked to one account.