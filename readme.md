# How to run this application on a local PC

This app is written in net core 2.0, so net core 2.0 runtime is minimum requirement to run the app successfully.

## To run this app on a local PC, follow instructions below:

1- Open a Powershell in elevated mode and change directory to where is readme file is located.
2- run  `dotnet restore .` This will restore all required packages. Please make sure the PC has access to internet.
3- run `dotnet build .` This command builds the solution.
4- run `cd dotnet-code-challenge`
5- run `dotnet run .`   This will the app.


Alternatively, if Visual studio is installed on PC, please open solution in Visual studio and change default project to `dotnet-code-challenge` and hit F5.



 