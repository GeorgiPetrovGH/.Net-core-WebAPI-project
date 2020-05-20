1.Steps to create and initialize the database

There is an initial migration so
use "Update-Database" command in Package Manager Console under Websites.Data project

2.Steps to prepare the source code to build/run properly

Code should be able to build properly without any additional steps
Set Website.Api to be the default startup project

3.Any assumptions made and missing requirements that are not covered in the specifications

How many login credentials might there be for a single website. We pass a single email and password in the input, but maybe we can have a list.
Also if we store passwords in database they should be encrypted.
Should we keep Categories in the DB, or as enum in the code(assuming they don't change).

4.Any feedback you may wish to give about improving the assignment

I didn't understand what vertical means for categories. Maybe it is just me.