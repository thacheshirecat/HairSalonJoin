# Project
Hair Salon Employee Terminal

## Author
Alex Bunnell

### Description
This program was created using C# and the MVC method as well as a MySQL database. The program allows users to keep track of stylists and their clients.

### Set Up Instructions
1. Clone repository from https://github.com/thacheshirecat/HairSalon
2.

#### Database needed
alex_bunnell

#### Tables needed
1. Clients (id, name, phone, category_id)
2. Stylists (id, name, style)

#### Creating Database and Tables
1. CREATE DATABASE alex_bunnell;
2. USE alex_bunnell;
3. CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), category_id INT);
4. CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), style VARCHAR(255));

#### Creating Test Database and Tables
1. CREATE DATABASE alex_bunnell_test;
2. USE alex_bunnell_test;
3. CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), category_id INT);
4. CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), style VARCHAR(255));

#### Specs
1. User can add a new stylist to the database, as well as view all available stylists in the database.
2. User can delete all the stylists from the database.
3. User can add a new client to the database, including who their stylist is, as well as view all available clients in the database.
4. User can delete all clients from the database.
5. User can view a specific stylist from the database including all their clients.
6. User can delete a specific client from the database.
7. User can update a specific client from the database.
8. User can update a specific stylist from the database.
9. User can delete a specific stylist from the database, which will also delete their client list from the database.

#### Copywrite & Licensing
This software utilizes the MIT License.
