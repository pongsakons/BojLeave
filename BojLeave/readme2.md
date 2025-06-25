# BojLeave - Leave Management System (.NET 8, DDD)

## โครงสร้างโปรเจค
- DDD: แยก 4 Layer (Api, Application, Domain, Infrastructure)
- TargetFramework: net8.0 ทุกโปรเจค
- รองรับ Docker, JWT Authentication, Swagger, Middleware, หลาย Environment (dev, acc, prod)

## คำสั่งสร้างโปรเจคและตั้งค่าเบื้องต้น

### 1. สร้าง Solution และแต่ละ Project
```powershell
# สร้าง Solution
 dotnet new sln -n BojLeave

# สร้างแต่ละ Project
 dotnet new webapi -n BojLeave.Api
 dotnet new classlib -n BojLeave.Application
 dotnet new classlib -n BojLeave.Domain
 dotnet new classlib -n BojLeave.Infrastructure

# เพิ่มโปรเจคเข้า Solution
 dotnet sln add .\BojLeave.Api\BojLeave.Api.csproj
 dotnet sln add .\BojLeave.Application\BojLeave.Application.csproj
 dotnet sln add .\BojLeave.Domain\BojLeave.Domain.csproj
 dotnet sln add .\BojLeave.Infrastructure\BojLeave.Infrastructure.csproj

# อ้างอิงข้ามโปรเจค
 dotnet add .\BojLeave.Api\BojLeave.Api.csproj reference .\BojLeave.Application\BojLeave.Application.csproj
 dotnet add .\BojLeave.Application\BojLeave.Application.csproj reference .\BojLeave.Domain\BojLeave.Domain.csproj
 dotnet add .\BojLeave.Infrastructure\BojLeave.Infrastructure.csproj reference .\BojLeave.Domain\BojLeave.Domain.csproj
```

### 2. ติดตั้ง NuGet Packages ที่จำเป็น
```powershell
# JWT, Swagger, Middleware, Config, EF Core
 dotnet add .\BojLeave.Api\ package Microsoft.AspNetCore.Authentication.JwtBearer
 dotnet add .\BojLeave.Api\ package Swashbuckle.AspNetCore
 dotnet add .\BojLeave.Api\ package Microsoft.Extensions.Configuration.Abstractions --version 9.0.6
 dotnet add .\BojLeave.Api\ package Microsoft.EntityFrameworkCore --version 9.0.6
 dotnet add .\BojLeave.Infrastructure\ package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.6
 dotnet add .\BojLeave.Infrastructure\ package Microsoft.EntityFrameworkCore.Abstractions --version 9.0.6
```

### 3. สร้าง/ปรับไฟล์ config หลาย environment
- appsettings.json, appsettings.Development.json, appsettings.acc.json, appsettings.Production.json
- เพิ่ม section `Jwt` สำหรับ config JWT

### 4. สร้าง Middleware และ Service
- Logging, Exception, CORS, Swagger, JWT
- แยก business logic (LoginService) และ JWT logic (JwtTokenGenerator) ไป Application Layer
- AuthController เรียกใช้ service ผ่าน DI

### 5. Docker
- สร้าง Dockerfile ใน BojLeave.Api
- ตัวอย่าง build/run:
```powershell
# Build Docker image
 docker build -t bojleave-api .
# Run Docker container
 docker run -d -p 5000:80 bojleave-api
```

### 6. รันโปรเจค
```powershell
# Build
 dotnet build
# Run
 dotnet run --project .\BojLeave.Api\BojLeave.Api.csproj
```

---

## หมายเหตุ
- สามารถขยาย logic เพิ่มเติม (เช่น เชื่อมต่อฐานข้อมูล, user management, test, CI/CD) ได้ตามต้องการ
- โค้ดแยกตามหลัก DDD และ Clean Architecture
- รองรับหลาย environment และ Docker พร้อมใช้งาน
