Using the app
Open the Books page to browse sample books. From there, you can view a book’s details, edit it, or delete it.

The app creates 100 sample books when it starts. Because it uses an in-memory database, changes are temporary and reset when the app restarts.

Project layout

1) BookHub/Controllers - handles web requests and book actions

2) BookHub/Models - defines the book data

3) BookHub/Data - sets up and fills the in-memory database

4) BookHub/Views - contains the pages shown in the browser

5) BookHub.Tests - test project


## Getting Started

Follow these steps to run the project locally:

### 1. Clone the Repository
```bash
git clone <repository-url>
```

### 2. Navigate to the Project Directory
```bash
cd <repository-folder>
```

### 3. Restore Project Dependencies
```bash
dotnet restore
```

### 4. Build the Project
```bash
dotnet build
```

### 5. Run the Application
```bash
dotnet run
```

