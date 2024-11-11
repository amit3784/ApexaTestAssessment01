## Introduction to Apexa Advisor API

Welcome to Apexa advisor API , which is built using below technologies

    - .NET Core 8.0
    - C#
    - MediateR
    - Carter
    - In memory database

In addition to above technologies , here are some design patterns and principles used-

    - CQRS to seggregate commands and queries
    - Vertical slice architecture to promote modularity
 
The details about the API used are listed below-

1. Get All Advisors:-this api is used to get all the advisors.

        api/Advisor/GetAll

2. Get Advisor By Id:- this api is used to get the specified advisor by its unique id.

        api/Advisor/GetById/{Id}

3. Create Advisor:- this api is used to create a new advisor.

        api/Advisor/Create

4. Update Advisor:- this api is used to update the existing advisor information.
   
        api/Advisor/Update

 5. Delete Advisor:- this api is used to delete the specified advisor by its unique id.
   
        api/Advisor/Delete
  
