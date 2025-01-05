Books Catalogue API Documentation

Overview

The Books Catalogue API provides endpoints to manage and retrieve information about books, including sorting and calculating total prices. It supports sorting operations both directly and using stored procedures for optimized performance.

Controller: BooksCatalogueController

This controller handles all operations related to the Books Catalogue.

Endpoints

1. Constructor

Signature:

BooksCatalogueController(IBooksCatalogueService bookCatalogueService)

Description:
Initializes the controller with the provided Books Catalogue service.

2. GetSortedBooksByPublisher

Description:
Retrieves books sorted by Publisher, AuthorLastName, AuthorFirstName, and Title.

Returns:
A sorted list of books.

3. GetSortedBooksByAuthorName

Description:
Retrieves books sorted by AuthorLastName, AuthorFirstName, and Title.

Returns:
A sorted list of books.

4. GetTotalPrice

Description:
Calculates the total price of all books in the catalogue.

Returns:
The total price as a decimal value.

5. CreateBooks

Signature:

CreateBooks(List<CreateBooksRequest> books)

Description:
Saves the entire list of books to the database in a single call to the database server.

Parameters:

books: A list of books to be added.

Returns:
A response indicating success or failure of the operation.

6. GetSortedByPublisherSp

Description:
Retrieves books sorted by Publisher, Author (LastName, FirstName), and Title using a stored procedure.

Returns:
A sorted list of books.

7. GetSortedByAuthorSp

Description:
Retrieves books sorted by AuthorLastName, AuthorFirstName, and Title using a stored procedure.

Returns:
A sorted list of books.

8. GenericSort 
Note : Not in the requirement, created this endpoint to use all the mentioned sortings using a single endpoint.
Signature:

GenericSort(GetBooksRequest request)

Description:
Retrieves a list of books sorted based on the provided sorting criteria.

Parameters:

request: An object containing sorting options and preferences.

Returns:
A sorted list of books.

Data Models

CreateBooksRequest

Represents the request object for creating new books. Includes properties such as Title, Author, Publisher, Price, etc.

GetBooksRequest

Represents the request object for retrieving sorted books. Includes properties to specify sorting options and criteria.

Features

Sort books by publisher or author names.

Calculate the total price of all books in the catalogue.

Use stored procedures for optimized sorting.

Bulk insertion of books to minimize database interactions.

Technologies Used

C#

Entity Framework Core

SQL Server (for stored procedures)

Getting Started

step 1 : Clone the repository.

step 2 : Set up the database and update the connection string in the configuration file.

step 3 : Utilize TestData -> DBScripts.txt file for the test data.

step 4 : Start the API and test using tools like Swagger or Postman.

Example Usage

Creating Books

Send a POST request to the /CreateBooks endpoint with a JSON payload:
Sample payload:
[
  {
    "Title": "Pride and Prejudice",
    "AuthorLastName": "Austen",
    "AuthorFirstName": "Jane",
    "Publisher": "HarperCollins",
    "Price": 9.99,
    "Year": 1813,
    "city": "New york",
    "journalTitle": "life",
    "titleOfContainer": "Classic Novels Collection",
    "pageNumber": "1-17",
    "month": "February",
    "url": "https://example.com/book-details",
    "volume": "no 3"
  }
]

Getting Sorted Books

Send a GET request to /GetSortedBooksByAuthorName to retrieve books sorted by author names.