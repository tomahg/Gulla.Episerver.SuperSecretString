# Gulla.Episerver.SuperSecretString

A custom Episerver property that will save its value as [Whitespace code](https://esolangs.org/wiki/Whitespace) in the database, so it's basicly invisible. In Episerver edit mode, or rendered on a page, the property will look exactly like any other property.

## Usage
Install the [NuGet package](https://www.nuget.org/packages/Gulla.Episerver.SuperSecretString/) package and add the backing type attribute to selected properties that holds super secret data like this.

``` csharp
[Display(Name = "Super secret string property")]
[BackingType(typeof(PropertySuperSecretString))]
public virtual string Secret { get; set; }
```

## Contribute
You are welcome to register an issue, or create a pull request, if you see something that should be improved.