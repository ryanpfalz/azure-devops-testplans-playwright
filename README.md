# azdo-testplans-playwright

---

| Page Type | Languages                                                  | Key Services                                                                               | Tools                      |
| --------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------ | -------------------------- |
| Sample    | .NET Core | Azure App Service <br> Azure DevOps (Pipelines, Releases, Test Plans) | Playwright |

---

# Running end-to-end Playwright tests in Azure DevOps with Test Plans

This sample codebase demonstrates how to 
<br>
This example should be viewed as a foundation for modification and expansion into more complex applications.

## Prerequisites

-   [An Azure Subscription](https://azure.microsoft.com/en-us/free/) - for hosting cloud infrastructure
-   [Az CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) - for deploying Azure infrastructure as code
-   [.NET Core](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - for web application and Playwright development

## Running this sample

### _*Setting Up the Cloud Infrastructure*_
-   Run the script `Devops/Infrastructure/env.ps1`, passing in your desired resource names as parameters.
-   This will create a [Resource Group](https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/manage-resource-groups-cli#what-is-a-resource-group), [App Service Plan](https://learn.microsoft.com/en-us/azure/app-service/overview-hosting-plans), and [App Service](https://learn.microsoft.com/en-us/azure/app-service/overview).

#### Web Application

### _*Setting up Playwright*_

### _*Setting up Azure DevOps*_

#### _*Build Pipeline*_
The `Devops/Build/webapp-tests-ci.yml` file builds the .NET Web Application in the repository and publishes the binaries to an artifact along with the Playwright tests.
Learn about how to create a YAML build pipeline [here](https://learn.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=java%2Ctfs-2018-2%2Cbrowser).

#### _*Release Pipeline*_

### _*Executing Playwright Tests with Test Plans*_

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
- [How to test web applications with Playwright and C# .NET - _blog_](https://www.twilio.com/blog/test-web-apps-with-playwright-and-csharp-dotnet)
- [Run Playwright .NET tests in Azure DevOps pipelines](https://syrett.blog/how-to-run-playwright-net-tests-in-azure-devops-pipelines/)