
![Dashboard](https://github.com/AhmedMah/ClinicManagement/blob/master/ClinicManagement/Content/images/d1.PNG)

# Clinic Management

Clinic web application  to support requirement which is that patients visit clinic and get registered, after that, they make an appointment by selecting the populated available doctors, which in turn lists the upcoming appointments for the selected doctor. By default the appointment gets a pending status because it needs to be reviewed. After that, the doctor is going to work out the patient attendance. Under the report we should have daily and monthly appointments.

# Frameworks - Libraries

1. ASP.NET MVC (version 5)
2. Entity Framework
3. Ninject
4. Automapper

# Running Project

Open project with Visual Studio
In package manager console run the following commands

    - enable-migrations
    -  add-migration "InitialDb"
    -  update-database

