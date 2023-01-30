# BlazorWebAssemblyApp

Blazor WebAsembly App with Firebase authorization

## 参考にした記事

[ASP.NET Core Blazor Server でオレオレ認証を追加したい without Cookie](https://zenn.dev/okazuki/articles/blazor-oreore-auth-part3)
[その github](https://github.com/runceel/BlazorOreoreAuth)

## wwwroot/appsettings.json

Firebase の API キーとドメインの設定を記述します。

```JSON
{
  "FirebaseApiKey": "",
  "FirebaseAuthDomain": ""
}
```

※開発環境で分けたい場合は appsettings.Development.json に記述します。  
※本番環境用には appsettings.Production.json を作成します。

## 使用ライブラリ

-   [FirebaseAuthentication.net](https://www.nuget.org/packages/FirebaseAuthentication.net/4.0.1?_src=template)
