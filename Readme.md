<div align="center">

<img src="assets/webapp-landing-page.png" alt="landing-oage" width="900"/>

### This is the source code of the LectorNet web application using .NET 9

</div>

- [Overview](#overview)
- [Backend Architecture](#backend-architecture)
- [Technologies](#technologies)
- [Usage](#usage)
- [API Definition](#api-definition)
  - [Create Book](#create-book)
    - [Create Book Request](#create-book-request)
    - [Create Book Response](#create-book-response)
  - [Get Book](#get-book)
    - [Get Book Request](#get-book-request)
    - [Get Book Response](#get-book-response)
  - [Update Book](#update-book)
    - [Update Book Request](#update-book-request)
    - [Update Book Response](#update-book-response)
  - [Delete Book](#delete-book)
    - [Delete Book Request](#delete-book-request)
    - [Delete Book Response](#delete-book-response)
- [Credits](#credits)
- [VSCode Extensions](#vscode-extensions)
- [Disclaimer](#disclaimer)
- [License](#license)

---

# Overview

This repository contains a full-stack web application built with .NET 8 technologies. 
The application features a Blazor Server frontend for creating dynamic user interfaces, complemented by a RESTful Web API backend that interfaces with a SQL Server database for data persistence and management.

# Backend Architecture

The backend follows Clean Architecture principles, organized into five distinct layers: API, Application, Contracts, Domain, and Infrastructure. 

These layers ensure separation of concerns and maintainable code.

Here's what each layer represents:
* API: The outermost layer that handles HTTP requests and responses. It exposes endpoints for client applications to interact with the system and manages input validation and authentication.

* Application: Contains the business logic and orchestrates the flow of data between the API and Domain layers. It implements use cases and application-specific rules without knowing about the database or external services.

* Contracts: Defines interfaces, DTOs (Data Transfer Objects), and shared models that establish clear boundaries between layers. This layer helps maintain consistent communication protocols throughout the application.
  
* Domain: The core layer containing business entities. It's independent of other layers and frameworks.

* Infrastructure: This layer implements technical concerns such as database access, external service integrations, file handling. This layer contains concrete implementations of interfaces defined in the Contracts layer, including repository classes, which handle data persistence and retrieval operations.

<div align="center">

<img src="assets/clean-architecture.png" alt="clean-architecture-drawing" width="900px"/>

</div>

# Technologies

1. ASP.NET web api
2. Blazor (with server interactivity)
3. Rider
4. dotnet CLI
5. SQL server
6. Docker

# Usage

1. Clone the repository: `git clone https://github.com/rachidamrani/lector-csharpdotnet-fullstack-app.git`. 
2. Make sure you have Docker installed on your machine.
3. Navigate to the root folder and run Docker Compose: `docker compose up --build`.
4. Access the application in your browser at : http://localhost:5001.

<!-- # API Definition

## Create Book

### Create Book Request

```js
POST / breakfasts;
```

```json
{
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy breakfast..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

### Create Book Response

```js
201 Created
```

```yml
Location: {{host}}/Books/{{id}}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy breakfast..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2022-04-06T12:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

## Get Book

### Get Book Request

```js
GET /breakfasts/{{id}}
```

### Get Book Response

```js
200 Ok
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy breakfast..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2022-04-06T12:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

## Update Book

### Update Book Request

```js
PUT /breakfasts/{{id}}
```

```json
{
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy breakfast..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

### Update Book Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Books/{{id}}
```

## Delete Book

### Delete Book Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Book Response

```js
204 No Content
``` -->