# Track Items Application

This documentation will guide you on how to run  both the front end and the backend
## The application keeps track of the items that need to be accomplished and their priority and progress.



### Project Technoliges Overview:

- **Client_UI:** Developed using Angular and for styling PRIMENG and bootstrap.

- **Backend:** Built with .NET 7 and ASP.NET core.

To get started, follow the instructions below to set up your environment.

## Directory Structure

The application resides in the `complyRepo` directory, which contains two main subfolders:

- **API**: Houses the .NET backend.
    - **src**: The source code for the API.
    - **tests**: Contains tests for the API.
- **ClientUI**: Contains front end.

## Building and Running the API
0. Clone this repository.

1. Navigate to the API source directory:
    ```bash
    cd /API/src
    ```

2. Restore the .NET packages:
    ```bash
    dotnet restore
    ```

3. Build the API:
    ```bash
    dotnet build
    ```

4. Run the API:
    ```bash
    dotnet run
    ```

## Building and Running the Angular UI

1. Navigate to the UI directory:
    ```bash
    cd /ClientUI
    ```


2. Install the required npm packages:
    ```bash
    npm install
    ```

3. Build and run the Angular app:
    ```bash
    npm start
    ```

The application should now be running locally. Open a browser and navigate to `http://localhost:4200` to access the UI, and the API will be available at `http://localhost:5000`.

## Running the Tests

### API Tests

To run the tests for the `API`:

1. Navigate to the `tests` folder inside `API`:
    ```bash
    cd compliance-checklist/API/tests
    ```

2. Run the tests using the `dotnet test` command:
    ```bash
    dotnet test
    ```
