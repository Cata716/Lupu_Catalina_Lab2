# Library Management System - ASP.NET Core Web Application

A comprehensive library management system built with ASP.NET Core, Entity Framework Core, and Razor Pages. This project demonstrates CRUD operations, many-to-many relationships, user authentication, role-based authorization, and data validation.

## Project Overview

This application allows libraries to manage their book inventory, track member borrowings, and organize books by categories, authors, and publishers. The system includes user authentication with role-based access control, distinguishing between regular users and administrators.

## Technology Stack

- **Framework**: ASP.NET Core (Razor Pages)
- **ORM**: Entity Framework Core (Code First)
- **Database**: SQL Server LocalDB
- **Authentication**: ASP.NET Core Identity
- **Language**: C#
- **IDE**: Visual Studio 2022 Community Edition

## Features

### Core Functionality
- **Book Management**: Complete CRUD operations for books with details including title, author, price, publishing date, publisher, and categories
- **Author Management**: Track book authors with first name, last name, and their published books
- **Publisher Management**: Manage publishing houses and view their catalog
- **Category Management**: Organize books into multiple categories using a many-to-many relationship
- **Member Management**: User registration and profile management
- **Borrowing System**: Track which members have borrowed which books and return dates

### Advanced Features
- **Search & Filter**: Search books by title or author name
- **Sorting**: Sort book listings by title or author
- **Related Data Display**: View all books by a publisher, all books in a category, etc.
- **Authentication & Authorization**: 
  - User registration and login
  - Role-based access (Admin and User roles)
  - Protected routes and actions
- **Data Validation**: Form validation with custom error messages
- **Responsive UI**: Bootstrap-based interface

## Database Schema

### Main Entities

**Book**
- ID (Primary Key)
- Title
- Price
- PublishingDate
- AuthorID (Foreign Key)
- PublisherID (Foreign Key)

**Author**
- ID (Primary Key)
- FirstName
- LastName
- FullName (Computed Property)

**Publisher**
- ID (Primary Key)
- PublisherName

**Category**
- ID (Primary Key)
- CategoryName

**Member**
- ID (Primary Key)
- FirstName
- LastName
- Address
- Email
- Phone
- FullName (Computed Property)

**BookCategory** (Junction Table)
- ID (Primary Key)
- BookID (Foreign Key)
- CategoryID (Foreign Key)

**Borrowing**
- ID (Primary Key)
- MemberID (Foreign Key)
- BookID (Foreign Key)
- ReturnDate

## Project Structure

```
Lupu_Catalina_Lab2/
├── Data/
│   ├── Lupu_Catalina_Lab2Context.cs       # Main database context
│   └── LibraryIdentityContext.cs       # Identity database context
├── Models/
│   ├── Book.cs
│   ├── Author.cs
│   ├── Publisher.cs
│   ├── Category.cs
│   ├── Member.cs
│   ├── Borrowing.cs
│   ├── BookCategory.cs
│   ├── AssignedCategoryData.cs
│   ├── BookCategoriesPageModel.cs
│   └── ViewModels/
│       ├── BookData.cs
│       └── PublisherIndexData.cs
├── Pages/
│   ├── Books/                          # Book CRUD pages
│   ├── Authors/                        # Author CRUD pages
│   ├── Publishers/                     # Publisher CRUD pages
│   ├── Categories/                     # Category CRUD pages
│   ├── Members/                        # Member management pages
│   ├── Borrowings/                     # Borrowing management pages
│   └── Shared/
│       └── _Layout.cshtml              # Main layout
├── Areas/
│   └── Identity/                       # Identity scaffolded pages
└── Program.cs                          # Application configuration
```

## Getting Started

### Prerequisites

- Visual Studio 2022 Community Edition or higher
- .NET 8.0 SDK (Long Term Support)
- SQL Server LocalDB
- Git

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Cata716/Lupu_Catalina_Lab2.git
   ```

2. Open the solution in Visual Studio 2022

3. Restore NuGet packages (Visual Studio will do this automatically)

4. Update the database with migrations:
   - Open Package Manager Console (Tools → NuGet Package Manager → Package Manager Console)
   - Run the following commands:
   ```powershell
   Update-Database
   Update-Database -Context LibraryIdentityContext
   ```

5. Run the application (F5 or click the green play button)

6. When prompted, accept the SSL certificate for local development

## Development Timeline

### Lab 2: Entity Framework & Basic CRUD
- Set up ASP.NET Core project with Entity Framework Code First
- Created Book, Author, and Publisher models
- Implemented scaffolded CRUD pages
- Database migrations and relationships
- Display name customization with data annotations

### Lab 3: Many-to-Many Relationships & Checkboxes
- Implemented Category system with BookCategory junction table
- Created checkbox interface for category selection
- Enhanced create and edit pages with multi-select functionality
- Displayed categories on book index page

### Lab 4: Related Data & Filtering
- Implemented related data display (books by publisher, books by category)
- Added sorting functionality (by title, by author)
- Implemented search functionality (by title or author name)
- Created view models for complex data display

### Lab 5: Authentication & Borrowing System
- Integrated ASP.NET Core Identity for authentication
- Created Member and Borrowing entities
- Implemented user registration with automatic Member creation
- Set up borrowing system for tracking book loans
- Configured role-based access control (Admin and User roles)

### Lab 6: Authorization & Validation
- Implemented role-based authorization policies
- Protected administrative routes and actions
- Added comprehensive data validation with custom error messages
- Configured access restrictions:
  - Anonymous access: Books/Index, Books/Details
  - Authenticated access: Book creation, editing, deletion (Admin only)
  - Member management (Admin only)
  - Publisher and Category management (Admin only)

## User Roles

### Administrator (Admin)
- Full access to all features
- Can create, edit, and delete books
- Can manage members, publishers, categories, and authors
- Can view and manage all borrowings

### User
- Can view books and their details
- Can register as a library member
- Limited access to administrative functions

## Data Validation Rules

### Member
- **FirstName**: Must start with uppercase, 3-30 characters, pattern: `^[A-Z]+[a-zA-Z\s-]*$`
- **LastName**: Must start with uppercase, 3-30 characters
- **Address**: Maximum 70 characters
- **Phone**: Format: '0722-123-123' or '0722.123.123' or '0722 123 123'
- **Email**: Read-only after registration

### Book
- **Title**: Required, 3-150 characters
- **Price**: Decimal (6,2), range 0.01-500
- **PublishingDate**: Date format

## Configuration

### Authorization Policies
The application uses convention-based authorization:

```csharp
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});
```

### Database Connection
Connection strings are managed in `appsettings.json`:
- Main application database: `Lupu_Catalina_Lab2Context`
- Identity database: `LibraryIdentityContext` (uses same connection)

## Branch Structure

- **master**: Contains Lab 2 (Basic CRUD operations)
- **Laborator3**: Many-to-many relationships
- **Laborator4**: Related data and filtering
- **Laborator5**: Authentication and borrowing system
- **Laborator6**: Authorization and validation (latest)

## Key Learning Outcomes

1. **Entity Framework Code First**: Creating models and generating databases through migrations
2. **Razor Pages**: Building server-side rendered web applications
3. **CRUD Operations**: Complete Create, Read, Update, Delete functionality
4. **Relationships**: One-to-many and many-to-many database relationships
5. **Data Annotations**: Using attributes for validation and display customization
6. **LINQ Queries**: Filtering, sorting, and joining data with Include() and ThenInclude()
7. **Authentication**: User registration, login, and account management
8. **Authorization**: Role-based access control and policies
9. **Validation**: Server-side validation with custom error messages
10. **View Models**: Organizing complex data for display

## Navigation

- **Books**: Main page (/) - Browse, search, and filter books
- **Authors**: Manage book authors
- **Publishers**: View publishers and their catalogs
- **Categories**: Manage book categories
- **Members**: User management (Admin only)
- **Borrowings**: Track book loans (Admin only)

## Testing the Application

1. Register a new user account (creates User role automatically)
2. Create an admin account and manually set role to "Admin" in database:
   - Navigate to `dbo.AspNetRoles` table
   - Find or create role with Name="Admin"
   - Update `dbo.AspNetUserRoles` to assign Admin role to your user

3. As Admin, test:
   - Creating/editing/deleting books
   - Managing publishers, authors, categories
   - Managing members
   - Creating borrowing records

4. As regular User, verify:
   - Can view books and details
   - Cannot access administrative functions

## Database Access

View the database using:
- **SQL Server Object Explorer** in Visual Studio
- **Server Explorer** connection to LocalDB


## Common Operations

### Adding a New Migration
```powershell
Add-Migration [MigrationName]
Update-Database
```

### Adding Migration for Identity
```powershell
Add-Migration [MigrationName] -Context LibraryIdentityContext
Update-Database -Context LibraryIdentityContext
```

## Course Information

- **Institution**: FSEGA (Faculty of Economics and Business Administration)
- **Course**: Programming Environments / Web Development
- **Labs**: 2-6 (Comprehensive application development)

## Future Enhancements

Potential improvements for the application:
- Book availability status
- Overdue borrowing notifications
- Book reviews and ratings
- Advanced search with multiple filters
- Email confirmation for registration
- Password reset functionality
- Borrowing history for members
- Statistical reports for administrators

## Troubleshooting

### Common Issues

**Database connection errors**:
- Ensure SQL Server LocalDB is installed
- Check connection strings in `appsettings.json`
- Run migrations for both contexts

**Authentication issues**:
- Verify AspNetUsers and AspNetRoles tables exist
- Check role assignments in AspNetUserRoles table
- Ensure LibraryIdentityContext migrations are applied

**Validation errors**:
- Check data annotations on models
- Verify input matches required patterns
- Review custom error messages

## Author

Catalina Lupu - FSEGA Student

## License

This project is created for educational purposes as part of university coursework.

## Acknowledgments

- Visual Studio documentation
- ASP.NET Core documentation
- Entity Framework Core documentation
- ASP.NET Core Identity documentation
- Course instructors at FSEGA
