graph TD
    A[API Layer<br/>(BojLeave.Api)] --> B[Application Layer<br/>(BojLeave.Application)]
    B --> C[Domain Layer<br/>(BojLeave.Domain)]
    A --> D[Infrastructure Layer<br/>(BojLeave.Infrastructure)]
    B --> D
    D --> C

    subgraph API Layer
        A1[Controllers]
        A2[Program.cs / DI]
        A1 --> A2
    end

    subgraph Application Layer
        B1[Services<br/>(LoginService, LeaveService)]
        B2[DTOs / Validators]
        B1 --> B2
    end

    subgraph Domain Layer
        C1[Entities<br/>(User, Leave)]
        C2[Interfaces<br/>(IUserRepository, ILeaveRepository)]
        C1 --> C2
    end

    subgraph Infrastructure Layer
        D1[DbContext]
        D2[Repositories<br/>(UserRepository, LeaveRepository)]
        D1 --> D2
    end

    A1 --> B1
    B1 --> C2
    D2 --> C2
    D1 --> C1
