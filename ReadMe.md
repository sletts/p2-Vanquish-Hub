# Poke-Pictionary

## Project Description

A user will be able to log in to our website. From there, they can either look at their past drawings, look at other people's drawings, organized by
either time of posting (by most recent) or by most popular, able to rate each other's drawings. If they desire, the user can also play a game.
In single player, the user will recieve a random pokemon. From there, they attempt to draw said pokemon in the canvas screen. When done, their drawing
is put side by side with the original art. The user can then download it, upload it and save it, or delete it. The user can attempt this with a hint,
the pokemon sprite next to their drawing, or blind. A 1 on 1 feature could be added where a person attempts to draw a pokemon within a set period of time.
Once done, the other person gets the image and can try and guess what pokemon it is that the other person drew up. 

## Technologies Used

- Backend
    - C#
    - Sql
    - .Net 6
    - Asp.Net core web api
    - ADO.Net/Entity Framework Core    
- Infra
    - Git
    - Docker
    - Azure Sql Databases
    - Azure App Service
    - Github Actions
    - Github Secrets
    - Sonar Cloud
    - Trello
- Code Quality
    - XUnit
    - Sonar Cloud
- FrontEnd
    - HTML
    - CSS
    - JavaScript
    - Angular
    - TypeScript
    - [Canvas](https://www.w3schools.com/graphics/canvas_drawing.asp)
- external api
    - [pokeapi.co](https://pokeapi.co/)

## Features
List of features ready and TODOs for future development
* Register a new user
* Login
* Draw an image on the canvas
* Recieve a random Pokemon from the pokeAPI to draw
* Functional API that can be pinged by any other website

Todo:
* Multiplayer aspect
* Google sign on
* Saving images
* Increasing Security
* Admin Page

## Getting Started

git clone https://github.com/sletts/p2-Vanquish-Hub

Open your Visual Stuido
Open Pokemon_Vanquish_Proj
Run the program to observe the API working on your computer

cd into the poke-pictionary and run  ng serve -o
The website will then run locally

or

Go to https://poke-pictionary.azurewebsites.net/ and play the game
Go to https://vanquish-p2.azurewebsites.net/swagger/index.html and observe the API and the functionality 

## Contributors

- Steve Burgos
- Osman Elmahadi
- Randy Robinson
- Sean Letts
