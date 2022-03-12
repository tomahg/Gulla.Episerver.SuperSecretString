# Gulla.Episerver.SuperSecretString

:warning: **This addon were published for April Fools Day (April 1st) 2021: While the Whitespace language being used is very real, and the addon saves string as Whitespace code in your database, this is probably not a good idea for actual security measures.**

A custom Episerver property that will save its value as [Whitespace code](https://esolangs.org/wiki/Whitespace) in the database, so it's basicly invisible. In Episerver edit mode, or rendered on a page, the property will look exactly like any other property.

More information in [this blog post](https://www.gulla.net/en/blog/hiding-secrets-in-episerver/).

## Usage
Install the [NuGet package](https://www.nuget.org/packages/Gulla.Episerver.SuperSecretString/) package and add the backing type attribute to selected properties that holds super secret data like this. The addon is intended as a joke, and a proof of concept, not for production use.

``` csharp
[Display(Name = "Super secret string property")]
[BackingType(typeof(PropertySuperSecretString))]
public virtual string Secret { get; set; }
```

## Contribute
You are welcome to register an issue, or create a pull request, if you see something that should be improved.