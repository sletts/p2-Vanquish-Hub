# Resturant Reviewer

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
* Add a new user
* Ability to search user as admin
* Display details of a restaurant for user
* Add reviews to a restaurant as a user
* View details of restaurants as a user
* View reviews of restaurants as a user
* Search restaurant (by name or zip code)

Todo:
* Calculate reviews’ average rating for each restaurant

## Getting Started

git clone https://github.com/220328-uta-sh-net-ext/Sean-Letts.git
Open your Visual Stuido
Select build at the top
Observe the program running

or

Go to https://resturantapitest.azurewebsites.net/swagger/index.html
From here you can test the diffent functionalities.
If you want to post something to the database outside of logging in, you will need to use Postman to do so.
Get the authentication token after performing a successful login
Put the token into the bearer token section in Postman
Post a new resturant or review with the proper information attached. 

