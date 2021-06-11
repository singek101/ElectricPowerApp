# Team-Saturn-ElectricityDigitalSystem

Team Project Done by Ekene, Sarah and Michael and supervised by Soji

Problem : 
The government of Nigeria wants to make power Generation and Management / Distribution easy for its citizens. Previously , Customers had to Go Directly to the offices of the discos ( distribution companies) to refill their Bill. But now The Government wants that process to become easy. For this reason they have come to Your team to come up with a solution.

Using The Pillars Of Object Oriented Programming learned over the past few weeks, write a software program That the Disco Company Agents can Use To 

Register a New Customer Into the System/ Remove a Customer From the System / Update a Customer’s information
Accept And Process Payments from a Customer For a particular Electricity Tariff subscription and Store that Information on the Customer in their Database
View the Personal/ Electricity  Tariff Information related to a Customer. 
Modify the Information for an Electrify Power Tariff Plan(i.e Price per Units of Electricity)

Also, 
Write another  simple Software Program That the Customer can Use To
Register into the System.
Subscribe for an Electricity Tariff
Unsubscribe from an Electricity Tariff 
Update personal Information

Notes :

When A Customer has Subscribed for an electricity tariff, it should reflect in the Agents Application Database.


Hints
Use a persistent storage type (most likely Text file or Json File) as your database
Create a Library and Two Console Applications (one for the agent and one for the customer) 
The Two Console Applications  should be serviced from the common Library. Ie (add a reference to the Library project inside both console apps)
The Library should be smart enough to separate namespaces that are only peculiar to the Customer application or to the Agent Application.
-Only the Library should be able to read/write to the database. The service layers can also stay inside the Library project (as namespaces)
Your program should be interactive.
When you want to run your program, to run the customer app, just change your starting point to the program.cs file of the customer console app,
Alternatively when you want to run the Agent Application, change your starting point to the Program.cs file for  the Agent app
