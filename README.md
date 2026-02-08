# TechVenture Bootcamp Project

This repository contains the **backend** of the project.  
Frontend repository: [TechVenture-Frontend](https://github.com/gulsum-oran-gunes/TechVenture-Frontend)

A full‑scope bootcamp project built on .NET 8 that delivers a production‑style backend for a bootcamp management platform. The system covers user onboarding, bootcamp management, applications, quizzes, results, certificates, and media management. It uses layered architecture, CQRS with MediatR, and a clean separation of concerns to keep the codebase maintainable as it grows.

## Live Demo

- App: [TechVenture](https://techventure-web.vercel.app)


## Tech Stack (Highlights)

- .NET 8, ASP.NET Core Web API
- Entity Framework Core, SQL Server
- MediatR (CQRS), AutoMapper
- JWT Authentication (Microsoft.AspNetCore.Authentication.JwtBearer)
- Serilog (file logging)
- Redis cache (StackExchange.Redis)
- Swagger (Swashbuckle)
- Emailing (NArchitecture.Core.Mailing)
- Dynamic Query (NArchitecture.Core.Persistence.Dynamic)
- Cloudinary, QuestPDF

## Packages & Integrations (Selected)

- **QuestPDF**: Generates PDF documents such as certificates and reports.
- **CloudinaryDotNet**: Uploads and manages images for instructors/bootcamps.
- **Swashbuckle.AspNetCore**: Swagger UI and API documentation.
- **Microsoft.AspNetCore.Authentication.JwtBearer** + **System.IdentityModel.Tokens.Jwt**: JWT authentication flow.
- **MediatR**: CQRS command/query pipeline.
- **AutoMapper** (+ ExpressionMapping): DTO/entity mapping.
- **Microsoft.EntityFrameworkCore** (SQL Server): ORM and migrations.
- **Serilog** (file sink): Centralized logging.
- **NArchitecture.Core.Mailing**: Email sending (verification, notifications).
- **StackExchange.Redis**: Distributed caching.

## Architecture

- Layered Architecture (Domain / Application / Persistence / Infrastructure / WebAPI)
- CQRS + MediatR
- Repository Pattern
- DTOs + AutoMapper

## Features

- JWT authentication and role-based authorization
- Email verification and OTP support
- Dynamic filtering and pagination
- File logging with Serilog
- Swagger documentation
- Cloud image upload integration
- PDF generation for documents/certificates

## Project Scope

This project models a real bootcamp platform with multiple roles (applicant, employee, instructor, admin) and related workflows:

- User management and authentication
- Bootcamp lifecycle management
- Application process and status tracking
- Quiz and question management
- Results and certificate generation
- Media management for instructors/bootcamps

## Domain Model (Key Modules)

- **Users & Auth**: Users, roles (operation claims), refresh tokens, email/OTP authenticators
- **Applicants**: Applicant profiles and their applications
- **Bootcamps**: Bootcamp, bootcamp state, bootcamp images and contents
- **Applications**: Application entity + application state tracking
- **Quizzes**: Quiz, questions, quiz questions, results
- **Certificates**: Certificate generation/management

## Entities & Tables (Overview)

Below are the main entities and their responsibilities:

- **User / Applicant / Employee / Instructor**: Core identities and profiles for different roles.
- **Bootcamp / BootcampState**: Bootcamp definition and lifecycle status.
- **BootcampImage / BootcampContent**: Media and content related to a bootcamp.
- **ApplicationEntity / ApplicationState**: Application submission and state tracking.
- **Quiz / Question / QuizQuestion / Result**: Quiz setup, questions, and exam results.
- **Certificate**: Generated certificates linked to results/users.
- **OperationClaim / UserOperationClaim**: Role/permission management.
- **RefreshToken / EmailAuthenticator / OtpAuthenticator**: Auth flows and verification.

## User Capabilities (High Level)

Typical actions by role:

- **Applicants**
  - Register and verify email
  - Browse bootcamps and apply
  - Take quizzes and view results
  - Access earned certificates
- **Instructors**
  - Manage bootcamp content and media
  - Create questions and quizzes
  - Review applicant progress/results
- **Employees / Admins**
  - Manage users and roles
  - Create/update bootcamps and states
  - Monitor applications and approvals
  - Maintain operational settings and permissions

## Database

- Database: Microsoft SQL Server (MS SQL)
- ORM: Entity Framework Core (Code First with migrations)
- Migrations are stored under `src/narchBootcampProject/Persistence/Migrations`.

### Example Tables (Entities)

- Users, Applicants, Employees, Instructors
- Bootcamps, BootcampStates, BootcampImages, BootcampContents
- ApplicationEntities, ApplicationStates, ApplicantBootcampContents
- Questions, Quizs, QuizQuestions, Results
- OperationClaims, UserOperationClaims, RefreshTokens
- EmailAuthenticators, OtpAuthenticators

## Authentication & Authorization

- JWT-based authentication for API access
- Role-based authorization using `ISecuredRequest` and MediatR pipeline behaviors
- Refresh token flow for session continuity
- Optional email and OTP authenticators

## Dynamic Search & Pagination

- Dynamic filtering and sorting via `DynamicQuery`
- Standard pagination using `PageRequest` and `IPaginate<T>`
- Implemented in list endpoints (e.g., bootcamps, applications, users)

## Logging & Monitoring

- Centralized logging with Serilog
- Logs are written to file using `NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File`

## Mail Verification

- Email verification is handled through activation keys
- Mail delivery via `NArchitecture.Core.Mailing` (MailKit/MimeKit under the hood)

## Folder Structure

- `src/narchBootcampProject/Domain`: Entities and core models
- `src/narchBootcampProject/Application`: Business rules, CQRS, DTOs, services
- `src/narchBootcampProject/Persistence`: EF Core, repositories, migrations
- `src/narchBootcampProject/Infrastructure`: External service adapters (e.g., Cloudinary)
- `src/narchBootcampProject/WebAPI`: API layer

## Setup

### Requirements

- .NET 8 SDK
- SQL Server

### Steps

1. Clone the repository
   ```bash
   git clone <REPO_URL>
   ```
2. Configure database and mail settings in `src/narchBootcampProject/WebAPI/appsettings.json`.
3. Apply migrations
   ```bash
   dotnet ef database update --project src/narchBootcampProject/Persistence --startup-project src/narchBootcampProject/WebAPI
   ```
4. Run the API
   ```bash
   dotnet run --project src/narchBootcampProject/WebAPI
   ```

## Usage

- Swagger UI: `<API_BASE_URL>/swagger`
- Auth endpoints: `/api/Auth/*`

## API Highlights

- **Auth**: login, register, refresh token, email/OTP verification
- **Users**: CRUD, list with pagination
- **Bootcamps**: CRUD, dynamic search, image/content management
- **Applications**: CRUD, status tracking
- **Quizzes**: questions, quiz setup, results
- **Certificates**: generate, download, and view as PDF

## Development Notes

- CQRS handlers are located under `Application/Features/*`
- Validation is handled via FluentValidation pipelines
- Business rules are centralized under `Application/Features/*/Rules`


