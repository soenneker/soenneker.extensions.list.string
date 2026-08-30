[![](https://img.shields.io/nuget/v/Soenneker.Extensions.List.String.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.List.String/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.string/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.string/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.List.String.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.List.String/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.string/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.string/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.List.String
Replaces an ordinal substring across every string in a list, in place.

## Installation

```bash
dotnet add package Soenneker.Extensions.List.String
```

## Usage

```csharp
using Soenneker.Extensions.List.String;

var paths = new List<string>
{
    "/v1/customers",
    "/v1/orders"
};

paths.Replace("/v1/", "/v2/");

// paths is now ["/v2/customers", "/v2/orders"]
```

`Replace()` calls ordinal, case-sensitive string replacement on every element and replaces all occurrences within each string. The list is mutated; no new list is returned. Elements that do not contain the old value retain their existing string instance.

Comparison is not culture-aware:

```csharp
var values = new List<string> {"File", "file"};
values.Replace("file", "document");

// ["File", "document"]
```

A null list, `oldValue`, or `newValue` throws `ArgumentNullException`. An empty list, an empty `oldValue`, or equal old/new values is a no-op. Although the list type is non-nullable, a runtime null element is skipped rather than throwing.

This overload does not accept a `StringComparison`. Use an explicit loop when case-insensitive or culture-specific replacement is required.
