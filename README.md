# Invoice Maker

A WPF-based desktop application for creating and managing invoices with customer information, item details, and automatic tax calculations.

## BOOKMARKS

- [OBJECTIVE](#objective)
- [REASON](#reason)
- [LICENSE](#license)
- [REFERENCES](#references)
- [DISCLAIMER](#disclaimer)

## OBJECTIVE

### PURPOSE

The Invoice Maker is a desktop application designed to simplify the process of creating and managing invoices. It allows users to input customer information, add multiple items with quantities and prices, and automatically calculates subtotals, taxes (10%), and total amounts. The application provides a clean, user-friendly interface with real-time updates and validation to ensure accurate invoice generation.

- **Date of creation:** 2023-11
- **Badges:** N/A
- **Technical:**
  - **Laborator:** WPF, XAML, C#, .NET Framework
  - **Dependencies:** .NET Framework 4.7.2 or later
- **Installation Instructions**
  - **GitHub Repo:** [Invoice Maker Repo](https://github.com/username/invoice-maker)
  - Clone the repository: `git clone https://github.com/Naoyuki-Christopher-H/invoice-maker.git`
  - Open the solution file `create_invoice_cs.sln` in Visual Studio 2019 or later
  - Build the solution (Ctrl+Shift+B)
  - Run the application (F5)

### Key Features

- Real-time invoice calculation with automatic 10% tax computation
- Clean, modern UI with responsive design
- Comprehensive input validation for all fields
- Item management with quantity and price controls
- Invoice summary display with subtotal, tax, and total calculations
- Invoice generation with customer details and itemized list
- Data clearing functionality with confirmation

### File Structure

```
create_invoice_cs/
├── MainWindow.xaml             # Main window layout (XAML)
├── MainWindow.xaml.cs          # Main application logic (C#)
├── App.xaml                    # Application resources
├── App.xaml.cs                 # Application entry point
├── Properties/
│   ├── AssemblyInfo.cs         # Assembly metadata
│   └── Resources.resx          # Application resources
├── Packages.config             # NuGet package references
└── create_invoice_cs.csproj    # Project configuration file
```

## REASON

Developed this application to streamline the invoice creation process for small businesses and freelancers. The WPF framework was chosen for its powerful data binding capabilities and modern UI features. The application demonstrates:

- Implementation of MVVM-like architecture
- Data binding with ObservableCollection
- Input validation and error handling
- Custom styling with XAML
- Decimal and currency formatting
- Event-driven programming

The application reduces manual calculation errors and significantly speeds up the invoice creation process compared to manual methods.

## LICENSE

**License Name:** N/A 

## REFERENCES

IF THIS REPOSITORY IS USED, PLEASE USE THIS TEMPLATE AS A REFERENCE:

> Author(s). (Year). *Title of Repository*. Available at: \[URL] (Accessed: \[Date]).

## DISCLAIMER  

UNDER NO CIRCUMSTANCES SHOULD IMAGES OR EMOJIS BE INCLUDED DIRECTLY IN 
THE README FILE. ALL VISUAL MEDIA, INCLUDING SCREENSHOTS AND IMAGES OF 
THE APPLICATION, MUST BE STORED IN A DEDICATED FOLDER WITHIN THE PROJECT 
DIRECTORY. THIS FOLDER SHOULD BE CLEARLY STRUCTURED AND NAMED ACCORDINGLY 
TO INDICATE THAT IT CONTAINS ALL VISUAL CONTENT RELATED TO THE APPLICATION 
(FOR EXAMPLE, A FOLDER NAMED IMAGES, SCREENSHOTS, OR MEDIA).

I AM NOT LIABLE OR RESPONSIBLE FOR ANY MALFUNCTIONS, DEFECTS, OR ISSUES THAT 
MAY OCCUR AS A RESULT OF COPYING, MODIFYING, OR USING THIS SOFTWARE. IF YOU 
ENCOUNTER ANY PROBLEMS OR ERRORS, PLEASE DO NOT ATTEMPT TO FIX THEM SILENTLY 
OR OUTSIDE THE PROJECT. INSTEAD, KINDLY SUBMIT A PULL REQUEST OR OPEN AN ISSUE 
ON THE CORRESPONDING GITHUB REPOSITORY, SO THAT IT CAN BE ADDRESSED APPROPRIATELY 
BY THE MAINTAINERS OR CONTRIBUTORS.

---
