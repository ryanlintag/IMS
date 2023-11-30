### Blazor-CQRS-EventSourcing-EntityFramework-Template

This project is initially set as a study project that would help me understand and implement software development concepts stemming from the Domain-Driven-Design software development approach. My desire is for this project to be of help to others in faster learning Domain Driven Design and other concepts that I have been studying since its conceptualization. I hope that this can be a template that you can use to initialize your personal project. Cheers! 

# List of libraries implemented in this repository
1. FluentAssertions
2. Mediator.Abstractions
3. Mediator.SourceGenerator
4. NetArchTest.Rules
5. Serilog
6. SonarAnalyzer.CSharp
7. xunit
8. EntityFrameworkCore

# Software Development Concepts being implemented
1. Domain Driven Design
2. Clean Architecture
3. Event Sourcing

# Project Status:
* This project will be using Blazor 8
* **2023-11-14** : The project will be updated to use .net 8
* **2023-11-18** : Working on EventStore implementation using SQL Server and EntityFrameworkCore
* **2023-11-22** : Completed data models for SQL Server and EntityFrameworkCore. Now trying to implement the process of saving data from API Endpoint to Database
* **2023-11-28** : Completed API Endpoints for Users connected to Database. Implemented search, paging, orderby. 

I would like to thank the following people for the tutorials and concepts that they provide in their own channels. Please do follow them and I hope that they can help you too with the knowledge that they impart.
1. [Milan Jovanović](https://www.youtube.com/@MilanJovanovicTech)
2. [IAmTimCorey](https://www.youtube.com/@IAmTimCorey)
3. [Nick Chapsas]( https://www.youtube.com/@nickchapsas)
4. [Derek Comartin](https://www.youtube.com/@CodeOpinion)

# Lessons and pain points while developing this project
*2023-11-21*:  I tried using EFCore 8 for Event Sourcing. After finishing the models and such, it seems to me that the final projection should always be a separate table from the events. The events data on the other hand looks like will be a slower version implementation than that when using Marten and Postgres. Maybe when this project is finished, I'll work on a version of which will use Postgres as backend.
 
