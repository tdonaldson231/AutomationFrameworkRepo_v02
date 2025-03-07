# AutomationFrameworkRepo_v01

## Overview  
This repository demonstrates a basic test automation framework in C# using:
- **.NET 8** 
- **RestSharp** for API testing  
- **Selenium WebDriver** for UI automation  
- **Extent Reports** for generating HTML reports

The framework is a work in progress show test case structure, execution, and reporting.
There are 3-test cases, two API and one UI. One of the API is set to fail intentionally. 

## Installation 
Clone this repository 
```bash
git clone https://github.com/tdonaldson231/AutomationFrameworkRepo_v02.git
```
Navigate to the project directory
```bash
cd AutomationFrameworkRepo_v02
```
## Execution 
### Visual Studio 2022
- Open the solution: `AutomationFrameworkRepo_v02.sln`
- Go to `Build > Build Solution`
- Then go to `Tests > Run All Tests`
 
### Command Line (dotnet)
From the home directory, execute the following to run all tests
```bash
dotnet test AutomationFrameworkRepo_v02/bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll
```
Results
```bash
~/source/repos/AutomationFrameworkRepo_v02 (main)
$ dotnet test AutomationFrameworkRepo_v02/bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 3 s - AutomationFrameworkRepo_v02.dll (net8.0)
```

## Results 
Extent Html Reports are generated with date/timestamps in the `Reports` directory
