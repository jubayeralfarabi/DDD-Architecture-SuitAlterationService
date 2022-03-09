# Alteration System Introduction 
This repo includes 3 backend services and 1 Azure Funtion written on c# .Net 6 

**Tools used:** Azure SQL Database, Azure Service Bus, Azure Application Insight, Azure AppService, Azure Function

# Swagger Url
Applications are hosted in Azure 

Alteration Service : https://alterationapi.azurewebsites.net/swagger/index.html

Payment Service : https://paymentapiservice.azurewebsites.net/swagger/index.html
  
---- Here in MockOrderPaidCommand, RefId is the AlterationId and OrderId is just and Id.

Email Service : https://emailapiservice.azurewebsites.net/swagger/index.html

# Run Locally
Please change database connection string in all appsettings because the given database connection string has **IP restrictions**.  

# Overview of the application
#### Common Folder Structure 
<img src="https://user-images.githubusercontent.com/62177256/157477026-7abc662a-5248-4d43-aaf5-c5b567b91cca.PNG" width="500">

#### Project Reference Diagram 
<img src="https://user-images.githubusercontent.com/62177256/157477116-fa7f6085-1fe0-43ce-9f84-80ce69f4141b.png" width="600">

#### Business Data Flow Diagram
<img src="https://user-images.githubusercontent.com/62177256/157522296-d9d72c38-507c-4559-9aa6-18a9423df5c3.png" width="600">


