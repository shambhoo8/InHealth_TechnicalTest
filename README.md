# InHealth_TechnicalTest

Q.1 Technology used :-
    ASP .Net MVC, AngularJS, Entity Framework(Code First Approch), SQL

Q.2 How to create database
    1) Change connection setting in web.config file.
    2) Database will created from Tools => Nuget Package Manager => Package Manager Console
    3) Choose Default Project "InHealth_Assignment.Data" and 
    4) write command "update-database -verbose"
    
 Q.3 How it works?
     According to assignment first registered user will be in "Admin" role and rest of the in "Standard user" role. After registration
     user will be redirected to login page and according to role of logedin user different will is showing on dashboard.
     
     Admin Role:- 
     Admin can delete any user post and change user role "Standard User" to admin but admin cann't change Admin 
     role to standard user.
     
     Standard User Role :-
     These kind of user add new blog post and check own post list.
     
     Public User :
     Public user check blog home page, view individual post details and signup for standard user also.
     
     
