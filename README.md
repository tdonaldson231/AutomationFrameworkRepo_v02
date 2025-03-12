# AutomationFrameworkRepo_v01

## Overview  
This repository demonstrates a basic test automation framework in C# using:
- **.NET 8** 
- **RestSharp** for API testing  
- **Selenium WebDriver** for UI automation  
- **Extent Reports** for generating HTML reports
- **MySql** for a simple SQL query test case.

There are only 4-test cases for a basic demonstration, two API, a UI, and one SQL. 
One of the API is set to fail intentionally to show how failures are displayed in the results.
The SQL test case spins up a MySql DB and seeds with mock data to be used for the test SQL tests.

## Prerequisites
- Docker Desktop must be installed and running locally.- 

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
dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll
```
Results
```bash
 ~/source/repos/AutomationFrameworkRepo_v02 (main)
$ dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:00.40]     RestApi.RestApi.RestApiPostDataBackendServiceFailure [FAIL]
  Failed RestApi.RestApi.RestApiPostDataBackendServiceFailure [214 ms]
  Error Message:
   Assert.Equal() Failure: Strings differ
            ↓ (pos 1)
Expected: "OkieDokie"
Actual:   "OK"
            ↑ (pos 1)
  Stack Trace:
     at RestApi.RestApi.RestApiPostDataBackendServiceFailure() in C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02\Tests\RestApi.cs:line 54
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)

Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3, Duration: 5 s - AutomationFrameworkRepo_v02.dll (net8.0)

```

#### Per Category
From the home directory, execute only the tests flagged as `Regression`
```
dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll ----filter "Category=Regression"
```

Results
```
$ dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --filter "Category=Regression"
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 8 s - AutomationFrameworkRepo_v02.dll (net8.0)
```

## Automation Html Results 
Extent Html Reports are generated with date/timestamps in the `Reports` directory
