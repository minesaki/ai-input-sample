[日本語で読む](https://github.com/minesaki/ai-input-sample/blob/master/README-ja.md)

# AI Input Sample

Sample web application that uses [.NET Smart Components](https://github.com/dotnet/smartcomponents/tree/main) for AI-supported user input.

## Prerequisites

- .NET 8
- OpenAI API account (< $0.01 at one execution)
  - Azure OpenAI API is also available

## Contents

- Smart Paste
  - supports filling in the form using text data in clipboard.
  - available even in such cases:
    - text data is not well-formed, lacks some info, has unnecessary info
    - form has many columns or many types of columns (textbox, combobox, radio button, etc)
  - supports easy implementation. Introducing it to existing form is also straightforward.
    - Frontend: Put `<SmartPasteButton>` into the form section
    - Backend: Put `builder.Services.AddSmartComponents().WithInferenceBackend<OpenAIInferenceBackend>();` into Program.cs
- (Adding other samples)

## How to run

### Create .env file
Place .env file with the following contents in the project root.
```
SmartComponents__ApiKey=<Your API Key>
SmartComponents__DeploymentName=<Model Name>  # e.g. gpt-4o-mini

# Uncomment and set the value if you are using Azure OpenAI
# SmartComponents__Endpoint=<Your Azure OpenAI Endpoint>  # e.g. https://YOUR_ACCOUNT.openai.azure.com/
```

### Run
``` sh
dotnet run
```

## Note

Currently, .NET Smart Components are available on .NET 6+, for Blazor, MVC, and Razor Pages.

Memo (commands executed to create this project)
``` sh
# Create project
dotnet new blazor --use-program-main
dotnet new gitignore

# Add SmartComponents
dotnet add package SmartComponents.Inference.OpenAI --version 0.1.0-preview10148
dotnet add package SmartComponents.AspNetCore --version 0.1.0-preview10148
dotnet add package SmartComponents.LocalEmbeddings --version 0.1.0-preview10148

# Add additional packages
dotnet add package DotNetEnv
```