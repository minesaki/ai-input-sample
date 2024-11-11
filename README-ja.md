[README in English](https://github.com/minesaki/ai-input-sample/blob/master/README.md)

# AI Input Sample

[.NET Smart Components](https://github.com/dotnet/smartcomponents/tree/main) を使用した、AIによる入力支援機能を実装したサンプルWebアプリ

## 前提

- .NET 8
- OpenAI API アカウント (1実行あたり$0.01未満)
  - Azure OpenAI API も使用可能

## 内容

- Smart Paste
  - クリップボードのテキストを使ったフォームへの入力を支援
  - 以下のようなケースでも使用可能
    - テキストが整形されていない、必要な情報が欠けている、余分な情報を含んでいる
    - フォームが多数の項目、あるいは多数の種類の項目（テキストボックス、コンボボックス、ラジオボタン等）を持っている
  - 非常に簡単に実装可能で、既存のフォームへの導入も容易
    - フロントエンド: フォーム部分に `<SmartPasteButton>` を追加
    - バックエンド: Program.csに `builder.Services.AddSmartComponents().WithInferenceBackend<OpenAIInferenceBackend>();` を追加
- (他の例を追加中)

## 実行方法

### .envファイルを作る
以下の内容で、.envファイルをプロジェクトのルートに配置してください。
```
SmartComponents__ApiKey=<Your API Key>
SmartComponents__DeploymentName=<Model Name>  # 例: gpt-4o-mini

# Azure OpenAI を使う場合、以下のコメントアウトを解除して値を指定してください。
# SmartComponents__Endpoint=<Your Azure OpenAI Endpoint>  # 例: https://YOUR_ACCOUNT.openai.azure.com/
```

### 実行
``` sh
dotnet run
```

## 備考

現在、.NET Smart Components は.NET6以上の、Blazor/MVC/Razor Pagesでサポートされています。

メモ（このプロジェクトの生成時に実行したコマンド）
``` sh
# プロジェクト生成
dotnet new blazor --use-program-main
dotnet new gitignore

# SmartComponents追加
dotnet add package SmartComponents.Inference.OpenAI --version 0.1.0-preview10148
dotnet add package SmartComponents.AspNetCore --version 0.1.0-preview10148
dotnet add package SmartComponents.LocalEmbeddings --version 0.1.0-preview10148

# その他のパッケージ追加
dotnet add package DotNetEnv
```