# AutomationFrameworkRepo_v01

## 🚀 Overview
This repository showcases a basic test automation framework in **C#** utilizing:

- **.NET 8** for the core framework
- **RestSharp** for API testing
- **Selenium WebDriver** for UI automation
- **Extent Reports** for generating HTML reports
- **MySQL** for executing SQL test cases

### Key Highlights
- **5 Test Cases**: 2 API, 1 UI, and 2 SQL tests.
- **Intentional Failure**: One API test is designed to fail, showcasing how failures are reflected in reports.
- **SQL Initialization**: Spins up a MySQL DB with mock data and stored procedures for SQL testing.

---

## 📂 Project Structure
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

---

## ⚙️ Configuration
- **`Config/`**: Houses configuration files for MySQL, Selenium locators, and docker setup.
- **`Extent-Config.xml`**: Extent report customization.

---

## 📁 Source Code Overview
### `Base`
- Initializes the environment and Selenium WebDriver setup.

### `Fixtures`
- Manages test environment setup and teardown for database, reports, and configuration.

### `Helpers`
- Contains utility functions like Docker management with `DockerComposeHelper.cs`.

### `Reports`
- Auto-generates HTML reports using Extent Reports, saved in the `Reports` directory.

### `Tests`
- xUnit tests, categorized into API, UI, and SQL.

---

## ✅ Prerequisites
- **Docker Desktop** (Windows) must be installed and running.

---

## 🔄 Installation
1. Clone the repository:
```bash
git clone https://github.com/tdonaldson231/AutomationFrameworkRepo_v02.git
```
2. Navigate to the project directory:
```bash
cd AutomationFrameworkRepo_v02
```

---

## ▶️ Test Execution

### Environment Selection Precedence
1. Environment variable `testEnvironment` (highest priority)
2. Static value in the `Base` class (default: "dev")
3. If both are unset, defaults to `local`.

### Using Visual Studio 2022
1. Open `AutomationFrameworkRepo_v02.sln`
2. Build the solution via `Build > Build Solution`
3. Run all tests via `Tests > Run All Tests`

### Using Command Line (dotnet CLI)
Run all tests with default environment:
```bash
dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --logger "console;verbosity=info"
```

### Sample Result Output
```bash
VSTest version 17.12.0 (x64)
Starting test execution, please wait...
[xUnit.net 00:00:29.38]     RestApi.RestApi.RestApiGetDataBackendServiceFailure [FAIL]
  Failed RestApi.RestApi.RestApiGetDataBackendServiceFailure [236 ms]
  Error Message:
   Assert.Equal() Failure: Strings differ
            ↓ (pos 1)
Expected: "OkieDokie"
Actual:   "OK"
            ↑ (pos 1)
Failed!  - Failed: 1, Passed: 4, Total: 5
```

### Running Tests by Category
Run only `Regression` tests and override environment:
```bash
export testEnvironment=development
dotnet test bin/Debug/net8.0/AutomationFrameworkRepo_v02.dll --filter "Category=Regression" --logger "console;verbosity=detailed"
```

### Sample Filtered Result Output
```bash
Starting test execution, please wait...
Total tests: 3
     Passed: 3
 Total time: 37.22 Seconds
```

---

## 📄 Additional Notes
- **Extent Reports**: Automatically generated after every test run.
- **Mock Data**: Seeded into MySQL using `mock_data.sql` during test initialization.
- **Locators**: Defined in `Config/UserInterface/locators.json` for UI tests.

---

## 🛠 Troubleshooting
- **Docker Not Running**: Ensure Docker Desktop is running before executing tests.
- **Environment Variable Issues**: Verify `testEnvironment` is correctly set for dynamic environment selection.

---