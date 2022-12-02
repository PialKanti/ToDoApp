# ToDoApp
ToDoApp is a web-based **VueJS-powered** application that is using **ASP.NET Core Web API** for backend services.  Users can easily create, update or delete to-do events.

## Features
- Create, update or delete a todo event
- Complete an event with a single button click
- Show events in three separate categories - upcoming, completed, and expired
- Automatically move an expired event to the Expired category
- Form validation from both client and server-side
- Search todo items by name

## Tech

ToDoApp uses several open-source projects to work properly:

- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0) - used for building HTTP services
- [VueJS](https://vuejs.org/) - client-side application development
- [Bootstrap](https://getbootstrap.com/) - great UI boilerplate for modern web apps

## Installation

ToDoApp requires [Node.js®](https://nodejs.org/) to run.
If Node is not installed on your machine, please install it from [here](https://nodejs.org/en/).

Also, it requires [Vue CLI](https://cli.vuejs.org/) for running the client application built on **VueJS**.
First check if Vue CLI is installed or not:

    vue --version
    
If it returns a version number then Vue CLI is installed.

    C:\Users\user>vue --version
    @vue/cli 5.0.8

Otherwise, install Vue CLI by below command

    npm install -g @vue/cli

First, open ***ToDoApp.sln*** file with [Visual Studio](https://visualstudio.microsoft.com/). Run the project by clicking the **F5** button.

After a successful run, a command prompt will be opened. 
![cmd](https://i.ibb.co/Z6YMVMc/Screenshot-2022-11-28-171738.png)

Next, open ***clientapp*** Folder from this location 

> ToDoApp\ToDoApp\clientapp

Open a command prompt in this location and install the necessary dependencies via the below command:

    npm install

This will install all the necessary dependencies and devDependencies from ***package.json*** file.
After that, start the client application

    npm run serve

## Preview of Application

![Home page](https://i.ibb.co/xS587V1/Screenshot-2022-11-28-175425.png)