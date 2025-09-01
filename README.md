
# Fintcs - Finance Management System

A complete full-stack finance management system built with Angular frontend and ASP.NET Core backend.

## Features

- **User Authentication & Authorization**: JWT-based authentication with role-based access control
- **Society Management**: Configure society details with approval workflow
- **User Management**: Admin can register and manage system users
- **Member Management**: Add and manage society members with auto-generated member numbers
- **Role-based Access**: Different levels of access for admin and regular users
- **Responsive UI**: Modern, clean interface built with Tailwind CSS

## Technology Stack

### Frontend
- **Angular 18**: Modern framework with standalone components
- **Tailwind CSS**: Utility-first CSS framework for responsive design
- **TypeScript**: Type-safe development
- **RxJS**: Reactive programming for HTTP operations

### Backend
- **ASP.NET Core 8**: Web API framework
- **Entity Framework Core**: ORM with SQLite database
- **JWT Authentication**: Secure token-based authentication
- **BCrypt**: Password hashing
- **Swagger**: API documentation

## Quick Start

### Prerequisites
- Node.js 18+ and npm
- .NET 8 SDK

### Running the Application

1. **Start the Full Stack Application**:
   Click the "Run" button in Replit, which will start both frontend and backend services in parallel.

   Or run manually:
   ```bash
   # Terminal 1 - Backend
   cd backend
   dotnet run

   # Terminal 2 - Frontend  
   cd frontend
   npm install
   npm start
   ```

2. **Access the Application**:
   - Frontend: `http://localhost:4200`
   - Backend API: `http://localhost:5000`
   - Swagger Documentation: `http://localhost:5000/swagger`

3. **Default Login Credentials**:
   - Username: `admin`
   - Password: `admin`

## Project Structure

### Backend (`/backend`)
```
backend/
├── Controllers/          # API controllers
├── Models/              # Entity models
├── DTOs/                # Data transfer objects
├── Services/            # Business logic services
├── Repositories/        # Data access layer
├── Data/                # Entity Framework context and seeding
├── Program.cs           # Application entry point
└── appsettings.json     # Configuration
```

### Frontend (`/frontend`)
```
frontend/src/app/
├── core/                # Core services, guards, interceptors
│   ├── guards/          # Route guards
│   ├── interceptors/    # HTTP interceptors
│   ├── models/          # TypeScript interfaces
│   └── services/        # Data services
├── features/            # Feature modules
│   ├── auth/            # Authentication components
│   ├── dashboard/       # Dashboard component
│   ├── societies/       # Society management
│   ├── users/           # User management
│   └── members/         # Member management
├── shared/              # Shared components and utilities
└── app.routes.ts        # Application routing
```

## API Endpoints

### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/register` - Register new user (Admin only)
- `GET /api/auth/roles` - Get available roles

### Users
- `GET /api/users` - Get all users (Admin only)
- `GET /api/users/me` - Get current user profile
- `PUT /api/users/{id}/role` - Update user role (Admin only)

### Society
- `GET /api/society` - Get society information
- `POST /api/society` - Create society (Admin only, when no society exists)
- `PUT /api/society` - Update society (Admin only, requires approval)
- `POST /api/society/approve-changes` - Approve society changes
- `GET /api/society/approval-status` - Get approval status (Admin only)
- `GET /api/society/pending-changes` - Get pending changes

### Members
- `GET /api/member` - Get all members
- `GET /api/member/{id}` - Get member by ID
- `POST /api/member` - Create new member
- `PUT /api/member/{id}` - Update member (requires approval)
- `POST /api/member/{id}/approve-changes` - Approve member changes
- `GET /api/member/pending-changes` - Get members with pending changes

## Key Features

### Authentication & Authorization
- JWT token-based authentication
- Role-based access control (admin, user)
- Automatic token refresh handling
- Protected routes with auth guards

### Society Management
- Single society per system
- Admin-only creation and updates
- Approval workflow for society changes
- All non-admin users must approve changes

### User Management
- Admin can register new users
- Profile management with detailed information
- Role assignment and management
- User listing with search and filters

### Member Management
- Auto-generated member numbers (MEM_001, MEM_002, etc.)
- Complete member profiles with banking details
- Update approval workflow
- Member search and management

### UI/UX Features
- Responsive design with Tailwind CSS
- Form validation and error handling
- Loading states and success/error messages
- Clean, modern interface
- Role-based navigation and features

## Development

### Adding New Features
1. **Backend**: Create models, DTOs, services, repositories, and controllers
2. **Frontend**: Create components, services, and models
3. **Update routing**: Add new routes to `app.routes.ts`
4. **Update navigation**: Add menu items in `app.component.ts`

### Database
- Uses SQLite for development (fintcs.db)
- Entity Framework Code First approach
- Automatic database creation and seeding
- Default admin user created on startup

### Configuration
- Backend settings in `appsettings.json`
- Frontend API URL configured in services
- JWT secret and expiration configurable
- CORS enabled for local development

## Troubleshooting

### Common Issues

1. **CORS Errors**: Ensure backend CORS is configured for frontend URL
2. **Database Issues**: Delete `fintcs.db` to reset database
3. **Token Expiration**: Check JWT expiration settings in `appsettings.json`
4. **Port Conflicts**: Ensure ports 4200 (frontend) and 5000 (backend) are available

### Reset Database
```bash
cd backend
rm fintcs.db
dotnet run
```

### Clear Browser Storage
- Clear localStorage to reset user session
- Refresh page after clearing storage

## Future Enhancements

- [ ] Loan Management System
- [ ] Monthly Demand Processing
- [ ] Voucher Creation and Management
- [ ] Financial Reports and Analytics
- [ ] Email Notifications
- [ ] File Upload for Member Photos
- [ ] Excel/PDF Export Features
- [ ] Advanced Search and Filtering
- [ ] Audit Trail and Logging
- [ ] Multi-language Support

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## License

This project is licensed under the MIT License.
