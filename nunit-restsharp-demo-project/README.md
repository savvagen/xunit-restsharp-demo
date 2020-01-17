## Generate Allure report

1. Edit `allureConfig.json` to generate reports to project directory:
``` 
"allure": {
    "directory": "../../../allure-results",
    ...
  },

```
2. Copy `allureConfig.json` to <project_dir>/bin/Debug/netcoreapp3.1/
3. Run tests
4. When `allure-results` folder was generated generate report with command:
 ``` 
cd <project dir>
allure generate -c
```
5. To save history trend about tests copy `allure-report/history` folder to `allure-results/history` and regenerate report again.
