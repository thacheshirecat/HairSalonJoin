# Project
Hair Salon Employee Terminal

## Author
Alex Bunnell

### Description
This program was created using C# and the MVC method as well as a MySQL database. The program allows users to keep track of stylists and their specialties as well as their clients.

### Set Up Instructions
1. Clone repository from https://github.com/thacheshirecat/HairSalonJoin
2. Start a MySQL database server using port #8889
3. Add the included .sql files to your MySQL server, or use the below command promts to set up the correct databases and tables
4. In the terminal, navigate to the Project's main directory, HairSalon, and execute dotnet run
5. In the browser, navigate to localhost:5000

#### Database needed
alex_bunnell

#### Tables needed
1. clients (id, name, phone, category_id)
2. stylists (id, name, style)
3. specialties (id, name)
4. specialties_stylists (id, specialty_id, stylist_id)

#### Creating Database and Tables
1. CREATE DATABASE alex_bunnell;
2. USE alex_bunnell;
3. CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), category_id INT);
4. CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), style VARCHAR(255));
5. CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255));
6. CREATE TABLE specialties_stylists (id serial PRIMARY KEY, specialty_id INT, stylist_id INT);

#### Creating Test Database and Tables
1. CREATE DATABASE alex_bunnell_test;
2. USE alex_bunnell_test;
3. CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), category_id INT);
4. CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), style VARCHAR(255));
5. CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255));
6. CREATE TABLE specialties_stylists (id serial PRIMARY KEY, specialty_id INT, stylist_id INT);

#### Specs
1. User can add a new stylist to the database, as well as view all available stylists in the database.
2. User can delete all the stylists from the database.
3. User can add a new client to the database, including who their stylist is, as well as view all available clients in the database.
4. User can delete all clients from the database.
5. User can view a specific stylist from the database including all their clients.
6. User can delete a specific client from the database.
7. User can update a specific client from the database.
8. User can update a specific stylist from the database.
9. User can delete a specific stylist from the database.
10. User can create a specialty, and view all specialties available.
11. User can add a specialty to a stylist, or a stylist to a specialty depending on their view.
12. User can view a specific specialty, and see which stylists are proficient. Likewise, all specialties will now be shown under the specific stylists view page.

#### Copywrite & Licensing
This software utilizes the MIT License.
