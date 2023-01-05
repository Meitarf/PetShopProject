# PetShopProject
ASP.Net Core MVC using MSSQL DB with Entity Framework Core. Information from controllers to the views is passed by **CRUD** operations.
## Installation
Download and run PetShopProject.sln on Visual Studio.
#### Connection String
```
"ConnectionStrings": {
    "PetShopDb": "Data Source=.\\SQLEXPRESS;Initial Catalog=PetShop;Integrated Security=True;Pooling=False"
  }
  ```
  This should be set on **appsettings.json** file.
  ## Overview
  There are 3 Models: **Animal**, **Category** and **Comment**.
  The website consiste 3 pages: Home, Catalogue and Administrator.
  The **Home Page** displays the 2 most commented animals.
  The **Catalogue Page** displayes all animals, and has a dropdown with categories. When choosing a category, it returns **all animals with the same CategoryID**.
  When clicking on "More Info" it returns the all the details of the specific with the same **AnimalID**. It also has an option to add more comments, which are added to the database.
  
  ![image](https://user-images.githubusercontent.com/62158246/210516780-dc080dfc-52b7-462c-bf56-e57d073bbdc3.png)
  
  The **Admin Page** has additional options like editing, deleting and adding new animal to the database.
  ![image](https://user-images.githubusercontent.com/62158246/210518325-ffac40f7-3930-4a19-8645-b9b844240da7.png)
