# Commerce.Backend
Commerce Backend

A modern e-commerce backend built using ASP.NET Core and Entity Framework Core, demonstrating clean architecture principles, Repository Pattern, Unit of Work Pattern, and RESTful API design.

Overview

This project provides backend services for managing products and categories in an e-commerce application. The solution follows a layered architecture to promote separation of concerns, maintainability, and scalability.

Architecture

Client Applications
        |
        v
ASP.NET Core Web API
        |
        v
Application Layer
        |
        v
Repository + Unit Of Work
        |
        v
Entity Framework Core
        |
        v
SQL Server

Technology Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Dependency Injection
- Repository Pattern
- Unit of Work Pattern

Solution Structure

- ASD.Host.Web – API Host Layer
- ASD.Commerce.Application – Application Services and Business Logic
- ASD.Commerce.Domain – Domain Entities and Contracts
- ASD.Commerce.EFCore – Data Access Layer

Features

Category Management

- Create Category
- Update Category
- Delete Category
- Get Category Details
- Get All Categories

Product Management

- Create Product
- Update Product
- Delete Product
- Get Product Details
- Get All Products

Design Patterns

Repository Pattern

Encapsulates data access logic and provides a clean abstraction over Entity Framework Core.

Unit of Work Pattern

Ensures multiple operations are committed as a single transaction.

API Documentation

Swagger UI is available when running the application locally.

Frontend

Angular Frontend:
https://github.com/dev-cart/Commerce.UI

React Frontend:
https://github.com/dev-cart/Commerce.React.UI

Future Enhancements

- Authentication and Authorization
- Shopping Cart
- Order Management
- Inventory Tracking
- AI-powered Commerce Assistant
- Product Recommendations
- Reporting and Analytics

Purpose

This project demonstrates enterprise application development practices using ASP.NET Core and Entity Framework Core.