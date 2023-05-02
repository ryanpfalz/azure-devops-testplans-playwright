# azdo-testplans-playwright

---

| Page Type | Languages                                                  | Key Services                                                                               | Tools                      |
| --------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------ | -------------------------- |
| Sample    | .NET Core | Azure App Service <br> Azure DevOps (Pipelines, Releases, Test Plans) | Playwright <br> Visual Studio |

---

# Running end-to-end Playwright tests in Azure DevOps with Test Plans

This sample codebase demonstrates how to set up and run automated Playwright tests in Azure DevOps using Test Plans against a web application running on App Service in Azure.
<br>
This example should be viewed as a foundation for modification and expansion into more complex applications.

## Prerequisites

-   [An Azure Subscription](https://azure.microsoft.com/en-us/free/) - for hosting cloud infrastructure
-   [Azure DevOps with Test Plans licensing](https://azure.microsoft.com/en-us/products/devops/test-plans) - for managing and running automated tests 
-   [Az CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) - for deploying Azure infrastructure as code
-   [.NET Core](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - for web application and Playwright development
-   [Visual Studio](https://visualstudio.microsoft.com/) - 

## Running this sample

### Setting Up the Cloud Infrastructure
-   Run the script `Devops/Infrastructure/env.ps1`, passing in your desired resource names as parameters.
-   This will create a [Resource Group](https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/manage-resource-groups-cli#what-is-a-resource-group), [App Service Plan](https://learn.microsoft.com/en-us/azure/app-service/overview-hosting-plans), and [App Service](https://learn.microsoft.com/en-us/azure/app-service/overview).


### Setting up Playwright

Choose your framework (in my case I did dotnet add package Microsoft.Playwright.Nunit)

To test locally, need to start process on localhost port, then run test (in CD, the app would already be running at the URL)

This guide is setup to use appsettings to drive the URL being visited


### Setting up Azure DevOps

#### Build Pipeline
The `Devops/Build/webapp-tests-ci.yml` file builds the .NET Web Application in the repository and publishes the binaries to an artifact along with the Playwright tests.
Learn about how to create a YAML build pipeline [here](https://learn.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=java%2Ctfs-2018-2%2Cbrowser).

Note that the build agent in this guide runs on Windows OS.



#### Release Pipeline

Note that the release agent in this guide runs on Windows OS.

##### Service Connection
Follow [this guide](https://learn.microsoft.com/en-us/azure/devops/pipelines/library/service-endpoints?view=azure-devops&tabs=yaml) to create a service connection to your Azure subscription.

##### Release stages and tasks
- #6 of https://learn.microsoft.com/en-us/azure/devops/test/run-automated-tests-from-test-hub?view=azure-devops#set-up-your-environment
- Need to run bin/Debug/netX/playwright.ps1 install   to ensure proper browsers are installed

- If running linked to test plans, need to choose 'test run', otherwise if running directly in CD, choose 'test assemblies' (https://stackoverflow.com/questions/56775384/invalid-on-demand-test-run-run-id-0-error-when-running-pipeline-test)

- Variable replacement

##### Web Application Deployment
Running the 'Deploy' stage of the Release pipeline will deploy the web application to the App Service.

### Executing Playwright Tests with Test Plans
Need to create test associations
Need to publish test binary dlls in CI
Need to configure vstest in CD for 'test run'
Need to launch from test plans UI

#### Setting up the Test Plan, Suite, and Case
https://learn.microsoft.com/en-us/azure/devops/test/create-a-test-plan?view=azure-devops#create-a-test-plan

Associate test(s) with backlog tasks so results are reported back to boards

##### Defining an automated test
- In test plan settings: https://learn.microsoft.com/en-us/azure/devops/test/run-automated-tests-from-test-hub?view=azure-devops#set-up-your-environment



##### Link a test in Visual Studio to a Test Plan
- Click all the way down to the test case
https://learn.microsoft.com/en-us/azure/devops/test/associate-automated-test-with-test-case?view=azure-devops
#### Running the test
- Run in test plans (choose run for web application)
https://learn.microsoft.com/en-us/azure/devops/test/run-automated-tests-from-test-hub?view=azure-devops#run-the-automated-tests
## Quality in the Development Lifecycle
![Continuous Quality Development Cycle](./Docs/ContinuousQuality.png)
Test automation is a critical aspect of software development that can help improve the speed and quality of testing. Automated tests can be run quickly and frequently; however, test automation is only a small part of the continuous quality cycle. Continuous quality involves a holistic approach to quality assurance that also includes manual testing, code reviews, vulnerability checks, and several other quality checks throughout the development process. By combining these different approaches, teams can ensure that software is not only functional, but also reliable, maintainable, and user-friendly.

The diagram above shows an example of where in the development lifecycle test automation with Playwright via Test Plans could be created and executed: The tests may be written during feature development and then run on the QA environment.

## Potential Use Cases
Playwright has out-of-the-box support for all modern browsers, and can be run locally as well as in build and release pipelines. Its modern automation capabilities make it a great candidate for running tests in scenarios like: 
- End-to-end automated UI testing
- Regression testing
- Headless browser testing

Read more about "Why Playwright?" [here](https://playwright.dev/docs/why-playwright).


## Additional Resources
- [How to test web applications with Playwright and C# .NET - blog](https://www.twilio.com/blog/test-web-apps-with-playwright-and-csharp-dotnet)
- [Run Playwright .NET tests in Azure DevOps pipelines - blog](https://syrett.blog/how-to-run-playwright-net-tests-in-azure-devops-pipelines/)
- [UI testing considerations](https://learn.microsoft.com/en-us/azure/devops/pipelines/test/ui-testing-considerations?view=azure-devops&tabs=mstest)