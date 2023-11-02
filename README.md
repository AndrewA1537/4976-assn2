# 4976-assn2

Brief description of your project.

## Features

-   **Feature 1**: Brief description of feature 1.
-   **Feature 2**: Brief description of feature 2.
-   ...

## Getting Started

### Prerequisites

-   .NET SDK (Specify the version, e.g., .NET 5, .NET 6).
-   Any other dependencies or software needed.

### Installation

1. **Clone the repository**:

    ```bash
     git clone https://github.com/AndrewA1537/4976-assn2.git
    ```

2. **Change directory** to the project directory:

    ```bash
    cd your-project-name
    ```

3. **Run the application**:
    ```bash
    dotnet watch
    ```

### App Building Steps

1.  **Create the .NET Blazor Server app**:

    ```bash
     dotnet new blazorserver --auth individual -o NonProfitApp
    ```

2.  **Create the .NET Class Library**:

    ```bash
    dotnet new classlib -o NonProfitLibrary
    ```

3.  **Create a .NET Solution file and add the projects to that solution**:

    ```bash
    dotnet new sln

    dotnet sln add NonProfitApp/NonProfitApp.csproj

    dotnet sln add NonProfitLibrary/NonProfitLibrary.csproj
    ```

4.  **Install the following packages in the Blazor Server app**:

    ```bash
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package CsvHelper
    ```
