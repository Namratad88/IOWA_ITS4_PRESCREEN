# IOWA ITS4 PRESCREEN PROJECT

This is a WPF application with .NET 6 to determine the adjacency of Iowa counties. This project aims to develop a user-friendly tool for identifying whether one Iowa county shares a border with another

# Architecture

<img src = "https://i.imgur.com/4SymcZb.png"/>


- WPF UI - For prompting the user inputs and displaying the result of the adjacency function
- Backend in .Net 6
  * Button Click Function
  * Button Click Function
  * Function is triggered when the button on the UI is clicked
- Business Logics - Adjacency function and database related code.
- DB - SQL Server DB

# Database Schema

`tbl_mas_county` - contains county names and county IDs

| Column Name  | Data Type |
| ------------- | ------------- |
| id  |  integer  |
| mapId  | integer  |
| countyName | varchar |

`tbl_rel_county_adjacency` - contains county IDs with it's respective adjacent county IDs

| Column Name  | Data Type |
| ------------- | ------------- |
| mapId  |  integer  |
| adjacentMapId  | integer  |

# Setup

- clone the repo
- use the sql files under the folder `sql` to set up the database and tables
- load the project into visual studio
- change the DB URL in `IOWA.ITS4.PRESCREEN\IOWA.ITS4.PRESCREEN\appsettings.json`
- run the code, make sure startup project is `IOWA.ITS4.PRESCREEN`


# Assumptions

- I have created two tables, one containing county names and IDs and the other containing adjacent IDs
- I have made the inputs into a class for code organisation
- I have assumed the following validations
  * input cannot be special characters or non-digit characters
  * input cannot be greater than two digits
  * input cannot be zero
  * inputs cannot be equal to each other
  * input cannot be empty
- database only contains a sample of three counties
- I am displaying the county names in output as an extra feature

