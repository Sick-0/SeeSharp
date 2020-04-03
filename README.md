# SeeSharp <3 Stream_Sharp
Intro Stream to C# during Corona Times

# Getting started

	IDE:
	 Rider
	 Visual Studio


LINUX install
First add keys:

    wget -q https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb

then install .net coreSDK, aspnet core and .net core runtime (sudo apt-get update BEFORE EVERY COMMAND)

    sudo apt-get update
    sudo apt-get install apt-transport-https
    sudo apt-get install dotnet-sdk-3.1
    sudo apt-get install aspnetcore-runtime-3.1
    sudo apt-get install dotnet-runtime-3.1

Now type dotnet in terminal to verify (usage? OK! command not known? SOMETHING WRONG)


# PROJECT START:
All cool? lets gooo:
   
    dotnet new console helloWorld
    cd helloWorld
    dotnet run helloWorld

LEARN MORE[https://dotnet.microsoft.com/learn/]

# FILES HERE
	
	StreamConsole
		Getting to know C#

	textBasedGame
		A tiny game in the console to explain some more in depth stuff

	ChatClient + Server
		Making your own chat in C# MSN vibes all over the place
