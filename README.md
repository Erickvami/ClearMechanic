# API Documentation
## Overview

This API is designed for managing movie-related data and is built using .NET Core 8 with Entity Framework Core, employing a code-first approach. The API is organized into several components, each serving a specific purpose.
Project Structure

- Controllers: Contains the API controllers that handle incoming HTTP requests and return responses. Controllers interact with services to process data and provide results.

- Data/Migrations: Contains database migration files that manage changes to the database schema over time.

- Data/Models: Includes the data models that represent the database entities. These models define the structure and relationships of the data stored in the database.

- Data/Repositories: Houses repository classes that abstract the data access layer, providing methods to interact with the database.

- Data/ApplicationDbContext.cs: Defines the Entity Framework Core DbContext, which is responsible for managing the database connections and entity tracking.

- Services/GenreService.cs: Implements the business logic related to genres, such as retrieving and manipulating genre data.

- Services/IGenreService.cs: Defines the interface for genre-related operations, ensuring that the service implementation adheres to a contract.

- Services/MovieService.cs: Implements the business logic related to movies, such as retrieving and manipulating movie data.

- Services/IMovieService.cs: Defines the interface for movie-related operations, ensuring that the service implementation adheres to a contract.

## How to Run:
```shell
dotnet run --urls "https://localhost:7216;http://localhost:5142"
```

## Functionality

The API provides comprehensive functionality for managing movies:

- Retrieve All Movies: Allows users to fetch a list of all movies available in the database. This is useful for displaying an overview of the movie collection.

- Search Movies: Enables users to search for movies using query parameters. Users can filter results by genres and other criteria to find specific movies.

- Get Movie Details: Provides detailed information about a specific movie, including its attributes and related entities like actors and genres. This endpoint is used to view more in-depth information about a movie.

- Create a New Movie: Allows users to add new movie records to the database. This functionality is used for expanding the movie collection with new entries.

- Delete a Movie: Facilitates the removal of movie records from the database. It supports both hard and soft deletion, allowing movies to be marked as deleted without removing them physically if needed.

## Key Components
### Repository Pattern

The repository classes handle data access logic and abstract interactions with the database. They support various operations such as:

- CRUD Operations: Methods to create, read, update, and delete entities.
    Soft Deletes: Support for soft deleting entities by marking them as deleted instead of physically removing them.
    Transactional Operations: Methods to perform multiple database operations within a single transaction, ensuring data consistency.

### Controllers

The MoviesController is the main controller responsible for handling movie-related API requests. It provides the following endpoints:

- Get All Movies: Retrieves a list of all movies.
- Search Movies: Searches for movies based on a query and optional filters such as genres.
- Get Movie by ID: Retrieves detailed information about a specific movie by its ID, with options to- include related actors and genres.
- Create Movie: Adds a new movie to the database.
- Delete Movie: Deletes a movie by its ID, with support for soft deletion.

API Routes

- `GET /api/movies`: Fetches a list of all movies.
- `GET /api/movies/search`: Searches for movies based on query parameters, including optional genre filters.
- `GET /api/movies/{id}`: Retrieves detailed information about a specific movie.
- `GET /api/genres`: Fetches a list of all genres.
- `POST /api/movies`: Creates a new movie entry.
- `DELETE /api/movies/{id}`: Deletes a movie by its ID, with support for soft deletion.

Services

The service classes handle the core business logic of the application. They interact with the repositories to perform operations such as:

- Fetching Movies: Retrieve movies from the database with optional filters and related data.
- Searching Movies: Search for movies based on query parameters and filters.
- Creating and Deleting Movies: Add new movies to the database and handle deletion operations.

Data Models

The data models define the structure of the entities in the database. They include properties that map to the database columns and define relationships between entities.
Database Context

The ApplicationDbContext class is responsible for managing the database connection and tracking entity changes. It uses Entity Framework Core to handle database operations and ensure consistency.