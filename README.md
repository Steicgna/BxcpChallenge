# BxcpChallenge
BettercallPaul programming challenge

## Overview
- The original repo is a Java Challenge so I didn't fork it but created a solution in C#
- This app is a console application written with Visual Studio 2022 using **.NET 8** as a framework. Just open the solution in VS and start the app. (or via .NET CLI)
- The solution contains two projects: The console application and the unit test project.
- Used Nuget-Packages:
  - **CsvHelper** for reading and parsing the csv-files
  - **Dotenv** to include the option for a configuration file to specify parameters / file location / db access / web services ...
  - **Serilog** as a flexible logging library to offer options to log into a file, database or service
