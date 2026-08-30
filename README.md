[![](https://img.shields.io/nuget/v/soenneker.asana.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.asana.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.asana.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.asana.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.asana.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.asana.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.asana.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.asana.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Asana.OpenApiClient

A Kiota-generated .NET client containing request builders and models for Asana's REST API.

## Installation

```bash
dotnet add package Soenneker.Asana.OpenApiClient
```

## Creating the client

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Asana.OpenApiClient;

httpClient.BaseAddress = new Uri("https://app.asana.com/api/1.0");
httpClient.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", personalAccessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new AsanaOpenApiClient(adapter);
```

For dependency-injection setup and cached client creation, use [`Soenneker.Asana.OpenApiClientUtil`](https://www.nuget.org/packages/Soenneker.Asana.OpenApiClientUtil).

## Usage

Request builders follow Asana's resource hierarchy. Asana accepts `me` wherever a user GID can identify the authenticated user:

```csharp
using Soenneker.Asana.OpenApiClient.Models;

UserResponseData? currentUser = await client
    .Users["me"]
    .GetAsync(cancellationToken: cancellationToken);
```

Generated operations expose request configuration for query parameters, headers, and Kiota middleware options:

```csharp
UserResponseArray? users = await client.Users.GetAsync(
    request =>
    {
        request.QueryParameters.Workspace = workspaceGid;
        request.QueryParameters.Limit = 50;
    },
    cancellationToken);
```

## Important behavior

- Request and response types are in `Soenneker.Asana.OpenApiClient.Models`.
- Collection responses use Asana's generated envelope and pagination fields; a successful response is not generally a bare array.
- Kiota maps documented non-success responses to the generated `ErrorResponse` exception type.
- The generated default base URL is Asana's production API. Supply a different adapter base URL when using a proxy or test double.
- The source is generated. Configure authentication, retries, and logging in the adapter or HTTP pipeline instead of editing generated files.
