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
4. Build up the project.
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
                                                                   |

### Testing
| Library                                                              | Description                 | External Content                                                                                                                                     |
|----------------------------------------------------------------------|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|

### Database Migrations
| Library     | Description         | External Content                 |
|-------------|---------------------|----------------------------------|

## Features
### Included

- [X] Setup conventional commits
- [X] Github actions [Continious Integration](https://www.atlassian.com/continuous-delivery/continuous-integration)

### Feature Backlog

- [ ] Security
- [ ] Kubernetes cluster integration
- [ ] Event messaging integration
- [ ] API Stress Testing
