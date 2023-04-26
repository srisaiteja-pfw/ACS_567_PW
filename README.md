# ACS_567_PW_G8
ACS PROJECT WORK
ONE TRACK APP FOLDER has the final Implementation.
Open Folder -> Final Project -> HW -> Hw.sln file runs both the front end and backend code.




Summary of the C# files

This code represents a Fintech application that includes a model and a controller.
The model includes three classes: Fintech, FinTechModel, and CustomerService. The Fintech class includes properties such as Id, Firstname, Lastname, Address, Email, Contact, Age, SSN, and Balance. The FinTechModel class includes properties such as Account_number, Id, Date, Category, and Expense. The CustomerService class includes properties such as Id, CustomerServiceDescription, PhoneNumber, and Date.


The FintechController class includes methods for HTTP GET, POST, PUT, and DELETE requests. It implements the ILogger interface for logging purposes. It has a constructor that takes in ILogger and IFintechRepository parameters. The class includes several actions such as getItems(), GetItem(int id), AccountExists(int id), and CustomerService(). The getItems() method returns a list of items. The GetItem(int id) method returns an item based on the id parameter. The AccountExists(int id) method checks if the account exists based on the id parameter. The CustomerService() method returns customer service contact information.


This Fintech application provides a repository class called FintechRepository that implements the IFintechRepository interface. The repository class allows the application to interact with a database through Entity Framework Core.
The FintechRepository class contains methods to read, delete, edit and add data from/to the database. The DataContext class represents the application's database context and contains properties that represent the various tables in the database.
The methods in the FintechRepository class allow for retrieving and modifying data from two tables: Fintech and monthly_expenses. The former represents the financial accounts and the latter represents monthly expenses.
The methods include getItems(), GetItem(), AccountExists(), CustomerService(), GetCustomerServiceById(), CreateCustomerService(), AddAccount(), EditAccount(), DeleteAccount(), getAllExpenses(), GetExpense(), and AddExpense().
Overall, this repository class provides the basic CRUD functionality for the application's data model, allowing the application to interact with a persistent data store.


This Razor Pages project appears to be a simple web application for managing Fintech accounts. The project contains several files, including Create.cshtml, Create.cshtml.cs, Edit.cshtml, Edit.cshtml.cs, Index.cshtml, Index.cshtml.cs, and Delete.cshtml, Delete.cshtml.cs. In this response, I will provide a summary for Create.cshtml.cs and Create.cshtml.
Create.cshtml.cs:
The Create.cshtml.cs file contains a public class called CreateModel, which is defined as a PageModel. This class handles the creation of new Fintech accounts.
Within the CreateModel class, there is a public Fintech object named fintech, which is initialized with default values, and two strings named errorMessage and successMessage, which are used to display success and error messages to the user.
The CreateModel class also contains an asynchronous OnPostAsync method, which is triggered when a user submits a form on the Create page. This method sets the values of the fintech object to the values submitted by the user, creates a JSON string from the fintech object, and sends a POST request to a server to save the data. If the server returns a success message, the successMessage string is set and displayed to the user. If the server returns an error, the errorMessage string is set and displayed to the user. The user is then redirected to the Index page.
Create.cshtml:
The Create.cshtml file contains HTML and Razor syntax for rendering a web page that allows users to create new Fintech accounts. The file includes an HTML form that submits data to the OnPostAsync method in Create.cshtml.cs. The form contains fields for user input, including firstname, lastname, address, email, contact, age, ssn, and balance. If the server returns an error, an error message is displayed to the user. If the server returns a success message, a success message is displayed to the user. The file also includes an HTML table for displaying data from the server.


The Edit.cshtml file contains the HTML markup for the page layout and displays an editable form for updating the account details. The form uses the POST method and calls the OnPostAsync method in the corresponding Edit.cshtml.cs code-behind file.
The Edit.cshtml.cs file contains the C# code that provides the functionality for the page. It defines a EditModel class that inherits from PageModel. The EditModel class has two public properties: fintech, which is an instance of the Fintech class, and errorMessage and successMessage, which are string variables used for displaying messages to the user.
The OnGet() method retrieves the id of the account to be edited from the request query parameters and makes an HTTP GET request to the "/Fintech/{id}" endpoint to retrieve the corresponding Fintech object from the database. It then deserializes the JSON response into a Fintech object and assigns it to the fintech property.
The OnPostAsync() method updates the properties of the fintech object with the form data submitted by the user. If the firstname field is empty, it sets an error message, otherwise it serializes the fintech object to JSON and sends an HTTP PUT request to the "/Fintech" endpoint with the JSON payload.
The handleSubmit() JavaScript function is used to display a success message to the user when the account has been successfully updated.


These files are part of a web application for a Fintech company. The application allows users to deposit checks and withdraw money from their accounts.
The CheckDeposit.cshtml file contains the HTML code for a page that enables users to deposit checks online. The code includes a form that takes the user's account number and the deposit amount, and a submit button. The associated CheckDeposit.cshtml.cs file contains the C# code that retrieves the account information from the HTTP request and updates the account balance.
The WithdrawMoney.cshtml file contains the HTML code for a page that enables users to withdraw money from their accounts. The code includes a form that takes the user's account number and the withdrawal amount, and a submit button. The associated WithdrawMoney.cshtml.cs file contains the C# code that retrieves the account information from the HTTP request and updates the account balance.
Both pages use Razor syntax to define the UI and display validation messages. The C# code behind each page leverages the HttpClient to invoke REST APIs for updating the account balance. Additionally, it includes some error handling code to validate user input and handle errors that occur while invoking the APIs. The user is redirected to the index page upon successful transaction.


ExpenseTracker.cshtml is a Razor page that displays a table of all monthly expenses. Users can add, edit, or delete expenses from this page. The table displays the account number, date, category, and expense of each expense. Additionally, there are links to the pages for adding a new expense, analyzing data, finding the mean amount, and finding the minimum amount.
ExpenseTracker.cshtml.cs is the code-behind file for the ExpenseTracker.cshtml page. It contains the model class for the page, which is ExpenseTrackerModel. This model contains a list of monthly expenses, which are retrieved from a web API using an HTTP GET request.


AddExpense.cshtml is the Razor page for adding a new expense. It contains a form that enables users to enter the details of their expense, including the account number, date, category, and expense amount. If the form is submitted successfully, the user is redirected to the ExpenseTracker page, and the new expense is added to the list.
AddExpense.cshtml.cs is the code-behind file for the AddExpense.cshtml page. It contains the model class for the page, which is AddExpenseModel. This model contains methods for handling the HTTP POST request when the user submits the form. The method uses an HTTP POST request to send the new expense data to a web API, which adds the new expense to the database. If the addition is successful, a success message is displayed on the page, and the user is redirected to the ExpenseTracker page. If there is an error, an error message is displayed.
DeleteExpense.cshtml is another Razor page that displays a form for deleting a specific expense. It is linked to the DeleteExpense.cshtml.cs page, which contains the OnGet method that retrieves the expense data to be deleted and sends an HTTP DELETE request to the API. It also contains variables for displaying error or success messages to the user. Both Razor pages are part of the FintechWebApp.Pages.FintechApp namespace.


Mean.cshtml and Mean.cshtml.cs - These two files together create a Razor Page that displays the mean (average) value of all expenses recorded in the application. It uses a dictionary object to store and display the analysis data.


MinAmount.cshtml and MinAmount.cshtml.cs - These two files together create a Razor Page that displays the minimum amount spent on expenses recorded in the application. Like Mean.cshtml, it uses a dictionary object to store and display the analysis data.
All of these Razor Pages are part of the FintechWebApp project, which appears to be a web-based application for managing financial expenses. The code snippets also show the use of HTTP client to send GET requests to the application's API endpoint for retrieving data analysis results in JSON format.



