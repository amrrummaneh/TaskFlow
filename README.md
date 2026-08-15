# TaskFlow — Task & Project Management System

A full-featured ASP.NET Core MVC web application designed to help teams and individuals organize, track, and manage daily tasks and projects efficiently with clear status pipelines and interactive dashboards.

## Overview

TaskFlow is a robust task management application built to streamline workflow tracking. It provides users with an intuitive UI to manage projects, assign task priorities, track deadlines, and follow progress through every stage of execution. The project was developed focusing on real-world multi-tier design, solid data architecture, and clean code principles.

## Features

- **Project & Task Management** with full CRUD operations for managing projects, task categories, and individual work items
- **Workflow & Status Tracking** across structured pipelines (To-Do, In Progress, Under Review, Completed)
- **Priority & Deadline Flags** with priority levels (High, Medium, Low) and due dates to ensure critical milestones are met
- **User Authentication & Authorization** with secure identity management and role-based access control (Admin, Manager, Member), powered by ASP.NET Core Identity
- **User Dashboard** with visual summaries and real-time counters displaying task statistics, impending deadlines, and recent activities
- **Assignment System** to assign tasks to individual team members with notification/status updates

## Architecture

The solution follows an N-Tier architecture, splitting responsibilities across separate class libraries instead of putting everything in the web project:

- **TaskFlow.Models** — Domain entities, Data Transfer Objects (DTOs), and View Models
- **TaskFlow.DataAccess** — EF Core DbContext, database migrations, Repository pattern, and Unit of Work implementation
- **TaskFlow.Utility** — Shared constants, authorization roles, helpers, and static configuration settings
- **TaskFlow.Web** — MVC application (Controllers, Views, ViewComponents, and static assets)

This separation keeps the data access logic decoupled from the presentation layer and makes the codebase easier to test and extend.

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Bootstrap 5, FontAwesome, HTML5/CSS3

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 (recommended) or VS Code

### Setup

1. Clone the repository
git clone https://github.com/amrrummaneh/TaskFlow.git
cd TaskFlow

2. Update the connection string in `TaskFlow.Web/appsettings.json` to point to your local SQL Server instance:
```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskFlowDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
```

3. Apply the migrations:
dotnet ef database update --project TaskFlow.DataAccess --startup-project TaskFlow.Web

4. Run the application:
dotnet run --project TaskFlow.Web

## Notes

This project was developed as a practical implementation of software engineering best practices, focusing on clean separation of layers, EF Core data patterns, and building scalable MVC applications with ASP.NET Core.
