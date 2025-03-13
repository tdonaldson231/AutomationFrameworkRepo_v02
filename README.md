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

## Structure
```bash
|-- AutomationFrameworkRepo_v02.csproj
|-- AutomationFrameworkRepo_v02.sln
|-- Config
|   |-- Sql
|   |   |-- README.md
|   |   |-- Src
|   |   |   `-- Config
|   |   |       `-- Sql
|   |   |           `-- mysql-init
|   |   |-- docker-compose.yml
|   |   `-- mysql-init
|   |       `-- mock_data.sql
|   `-- UserInterface
|       `-- locators.json
|-- Extent-Config.xml
|-- README.md
|-- Reports
|   `-- Extent_Reports_Example.html
|-- Src
|   |-- Config
|   |   `-- Sql
|   |-- Fixtures
|   |   |-- DatabaseFixture.cs
|   |   |-- ExtentReportsFixture.cs
|   |   |-- TestConfigFixture.cs
|   |   `-- WebDriverFixture.cs
|   |-- Helpers
|   |   `-- DockerComposeHelper.cs
|   |-- Lib
|   |   |-- Base.cs
|   |   `-- ExtentReportCollection.cs
|   |-- PageObjects
|   |   |-- AboutPage.cs
|   |   `-- HomePage.cs
|   `-- Utilities
|       `-- LocatorReader.cs
`-- Tests
    |-- Portal.cs
    |-- RestApi.cs
    |-- RunSettings
    |   |-- dev.runsettings
    |   `-- test.runsettings
    `-- Sql.cs
```
## Src
### Config
The Config directory is used to store configuration files that assist in setting up and managing various utilities needed for the project. These configuration files are integral in facilitating tasks such as automating tests with Selenium, seeding mock data into a SQL database, and configuring other project-related utilities.

### Base
The Base class serves as the foundational class for the automation framework within the project. It provides essential functionality such as setting up the environment and initializing a Selenium WebDriver for browser-based testing.

### Fixtures
Fixtures are used for setting up and tearing down the test environment. They provide the necessary context and resources to execute tests, ensuring that tests have the correct setup before running and that resources are cleaned up afterward.

### Helpers
Utility methods or classes designed to simplify repetitive tasks within the tests. They are used for operations that don't directly involve setting up or tearing down test data but instead offer support by providing commonly used functionality.

### Reports
Extent HTML Reports gather the results from all tests executed during a test pass and generate detailed reports, including date and timestamps, which are then saved to the `Reports` directory.

## Tests
Contains several types of classes that serve different objectives of testing such regression testing and other types of testing. The organization and content of the test directory depend on the testing framework being used (currently using xUnit) and the structure of the application.



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
From the home directory, execute the following to run all the tests using the default `testEnvironment` = "local" 
**Note**: additional debug can be displayed: `--logger "console;verbosity=detailed"`

```bash
dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --logger "console;verbosity=info"
```
Results
```bash
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:29.38]     RestApi.RestApi.RestApiGetDataBackendServiceFailure [FAIL]
  Failed RestApi.RestApi.RestApiGetDataBackendServiceFailure [236 ms]
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
 Test Environment (RestApi): local
 FAIL: The expected status was not detected: Assert.Equal() Failure: Strings differ
             ↓ (pos 1)
 Expected: "OkieDokie"
 Actual:   "OK"
             ↑ (pos 1)

Failed!  - Failed:     1, Passed:     4, Skipped:     0, Total:     5, Duration: 9 s - AutomationFrameworkRepo_v02.dll (net8.0)
```

#### Per Category
From the home directory, execute only the tests flagged as `Regression` and override `testEnvironment`.

```bash
export testEnvironment=development

dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --filter "Category=Regression" --logger "console;verbosity=detailed" 
```
Results
```bash
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02\bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.5.3.1+6b60a9e56a (64-bit .NET 8.0.14)
[xUnit.net 00:00:00.08]   Discovering: AutomationFrameworkRepo_v02
[xUnit.net 00:00:00.13]   Discovered:  AutomationFrameworkRepo_v02
[xUnit.net 00:00:00.13]   Starting:    AutomationFrameworkRepo_v02
Loading Extent Config from: C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02\Extent-Config.xml
Base Directory: C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02\bin\Debug\net8.0\
Project Path: C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02
Docker Compose Directory: C:\Users\toddd\source\repos\AutomationFrameworkRepo_v02\Config\Sql
  Passed Sql.Sql.SqlStoredProcedureCheckingScores [81 ms]
  Standard Output Messages:
 Test Environment (Sql): development
 Stored procedure executed and returned valid results.


Starting ChromeDriver 134.0.6998.88 (7e3d5c978c6d3a6eda25692cfac7f893a2b20dd0-refs/branch-heads/6998@{#1898}) on port 49452
Only local connections are allowed.
Please see https://chromedriver.chromium.org/security-considerations for suggestions on keeping ChromeDriver safe.
ChromeDriver was started successfully on port 49452.
  Passed RestApi.RestApi.RestApiGetDataBackendService [230 ms]
  Standard Output Messages:
 Test Environment (RestApi): development
 PASS: The expected status was detected from the backend service.


  Passed UserInterface.PortalTests.PortalVerifyTextOnAboutPage [891 ms]
  Standard Output Messages:
 Test Environment (PortalTests): development
 PASS: The expected text was found on the About page.


[xUnit.net 00:00:36.65]   Finished:    AutomationFrameworkRepo_v02

Test Run Successful.
Total tests: 3
     Passed: 3
 Total time: 37.2231 Seconds
```
