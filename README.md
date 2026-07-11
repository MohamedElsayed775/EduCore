# 🎓 EduCore - Education Management System

EduCore is a web application built with **ASP.NET Core MVC** to simplify educational management. It provides an easy way to manage departments, instructors, trainees, courses, enrollments, and student results.

The project was developed to practice building scalable MVC applications using **Entity Framework Core**, **SQL Server**, **Repository Pattern**, and **ASP.NET Core Identity**.

---

## ✨ Features

### 🏢 Department Management
- Create, edit, delete, and view departments.
- Assign courses, instructors, and trainees to departments.

### 👨‍🏫 Instructor Management
- Create, edit, delete, and view instructors.
- Assign instructors to departments.
- Assign instructors to courses.

### 🎓 Trainee Management
- Create, edit, delete, and view trainees.
- Associate trainees with departments.

### 📚 Course Management
- Create, edit, delete, and view courses.
- Add trainees to courses.
- Remove trainees from courses.

### 📊 Student Results
- Assign and update trainee grades.
- Display trainee results.
- Determine Pass/Fail based on the minimum course degree.

### 🔐 Authentication
- User Registration
- User Login
- ASP.NET Core Identity

---

## 🛠 Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- LINQ
- HTML5
- CSS3
- Bootstrap

---

## 🏗 Architecture & Design Patterns

- Repository Pattern
- Dependency Injection
- MVC Architecture
- View Models

---

## 🗄 Database Relationships

- Department → Courses
- Department → Instructors
- Department → Trainees
- Course ↔ Trainee (Many-to-Many using `CrsResult`)
- Course → Results
- Trainee → Results

---

## 🚀 Getting Started

### Clone the repository

```bash
git clone https://github.com/MohamedElsayed775/EduCore.git
```

### Configure the database

Update the SQL Server connection string inside:

```text
appsettings.json
```

### Apply migrations

```powershell
Update-Database
```

### Run the application

Run the project using Visual Studio.

---

## 📌 Future Improvements

- Search & Filtering
- Pagination
- Role-Based Authorization
- Dashboard Statistics
- Upload trainee profile images

---

## 👨‍💻 Author

**Mohamed Elsayed**

Junior Backend Developer (.NET)

- LinkedIn: https://www.linkedin.com/in/mohamed-alsayed-925137275/

---

⭐ If you found this project useful, consider giving it a star.
