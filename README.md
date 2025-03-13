# AutomationFrameworkRepo_v01

## Overview  
This repository demonstrates a basic test automation framework in C# using:
- **.NET 8** 
- **RestSharp** for API testing  
- **Selenium WebDriver** for UI automation  
- **Extent Reports** for generating HTML reports
- **MySql** for a simple SQL query test case.

There are currently only 5-test cases for a basic demonstration, two API, a UI, and a couple for SQL. 
One of the API is set to fail intentionally to show how failures are displayed in the results.
The SQL test case spins up a MySql DB, seeds with mock data, adds a stored procedure both with are
used for the SQL tests.

## Prerequisites
- Docker Desktop must be installed and running locally (using windows). 

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

### Environment
The test uses the following precedence to determine the environment:
- If environment variable `testEnvironment` is set, use it.
- Else, if null then use the static value specified in the `Base` file (e.g. "dev").
- Else, if both are `null` or empty then use the default `local`.

### Visual Studio 2022
- Open the solution: `AutomationFrameworkRepo_v02.sln`
- Go to `Build > Build Solution`
- Then go to `Tests > Run All Tests`
 
### Command Line (dotnet)
From the home directory, execute the following to run only the API tests using the static setting in the `Base` file: `protected readonly string testEnvironment = "integration"` 
```bash
dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll
```
Results
```bash
$ dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --filter "Category=API"
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:01.32]     RestApi.RestApi.RestApiGetDataBackendServiceFailure [FAIL]
  Failed RestApi.RestApi.RestApiGetDataBackendServiceFailure [775 ms]
  Error Message:
   Assert.Equal() Failure: Strings differ
            ↓ (pos 1)
Expected: "OkieDokie"
Actual:   "OK"
            ↑ (pos 1)
  Stack Trace:
     at RestApi.RestApi.RestApiGetDataBackendServiceFailure() in C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02\Tests\RestApi.cs:line 84
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
  Standard Output Messages:
 Test Environment (RestApi): integration
 FAIL: The expected status was not detected: Assert.Equal() Failure: Strings differ
             ↓ (pos 1)
 Expected: "OkieDokie"
 Actual:   "OK"
             ↑ (pos 1)

Failed!  - Failed:     1, Passed:     1, Skipped:     0, Total:     2, Duration: 1 s - AutomationFrameworkRepo_v02.dll (net8.0)

```

#### Per Category
From the home directory, execute only the tests flagged as `Regression` and override `testEnvironment`.\
**Note**: additional debug can be displayed: `--logger "console;verbosity=detailed"`

```bash
export testEnvironment=development

dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --filter "Category=Regression" --logger "console;verbosity=info" 
```
Results
```bash
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 9 s - AutomationFrameworkRepo_v02.dll (net8.0)
```

## Automation Html Results 
Extent Html Reports are generated with date/timestamps in the `Reports` directory
