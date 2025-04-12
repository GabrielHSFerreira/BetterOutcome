# BetterOutcome

[![CI/CD](https://github.com/GabrielHSFerreira/BetterOutcome/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/GabrielHSFerreira/BetterOutcome/actions/workflows/ci-cd.yml)

*The word "outcome" is a noun that means the result or effect of an action, situation, or event. It can also refer to a conclusion reached through logical thinking.*

The BetterOutcome library aims to provide a simple and object-oriented Option implementation for C# (slightly inspired by Rust's implementation).

## Quickstart

First of all, install the package.

`dotnet add package BetterOutcome`

In this simple example, Option is used to wrap the result of a Customer query endpoint and return Ok or NotFound accordingly.

```csharp
[HttpGet("{id:int}")]
public IActionResult Get(int id)
{
    var result = GetCustomer(id);

    return result switch
    {
        Some<Customer> customer => Ok(customer.Value),
        _ => NotFound() // the operator _ can match the None<Customer> case
    };
}

private static Option<Customer> GetCustomer(int id)
{
    return Option<Customer>.CreateFromValue(_customers.GetValueOrDefault(id));
}
```
