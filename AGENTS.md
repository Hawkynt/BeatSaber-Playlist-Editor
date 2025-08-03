# AGENTS.md

## 🧠 Language & Runtime Targets

- **C# Version**: Latest stable (Assume all compiler features can be used when Hawkynt's Extensions or Backports are referenced via NuGet, regardless of runtime compatibility)
- **.NET Runtime**:
  - Regular projects: **.NET 9**
  - Polyfills/backports: **.NET Framework 2.0 compatibility**
- **Top-level statements**: ✅ Allowed
- **Global usings**: ❌ Forbidden
- **File-scoped namespaces**: ✅ Preferred

## 🧱 Code Style

- **Indentation**: 2 spaces (no tabs)
- **Braces**: K&R (1TBS), omit wherever possible (e.g. one-line constructs, multi-line cases without variable declarations)
- **Line endings**: LF
- **Blank lines**: Never more than one contiguous blank line, always before `return` and after control blocks (e.g. `if-else`, `if`, `switch`, `for`, `foreach`)
- **Naming**: As per .NET conventions, with:
  - Prefixes:
    - `T`: Type parameters
    - `I`: Interfaces
    - `A`: Abstract base classes
    - `_`: Private fields, methods, events, properties
  - `PascalCase` for types, enums, structs, classes, methods, properties, events and `public` fields when `static readonly`.
  - `camelCase` for locals, parameters, method arguments.
  - `ALL_CAPS` for constants and `private` quasi constants (`static readonly`).
  - `@this`: first parameter in extension methods
  - `NativeMethods`: private nested classes where all P/Invoke members reside
- **Operator spacing**: Space around operators, never before postfix/prefix operators.
- **Syntax spacing**: When breaking long expressions, prefer breaking after operators or commas.
- **Attribute formatting**:
  - Place each attribute on its own line unless it's trivially short.
  - Inline parameter attributes only if there's exactly one.
- **Switch Statements**:
  - Always use braces for multi-line case blocks.
  - Indent blocks inside case, align case and default with switch.
- **LINQ**: Multi-line expressions should break after key LINQ keywords and align naturally.

## 🛠️ Preferred Language Constructs

Prefer the most modern, expressive, and efficient options:

### 🧾 Types & Declarations

- Use `record` / `record struct` / `readonly struct` when immutability makes sense.
- Use `readonly`, `const`, `init`, `sealed`, `field` where applicable.
- Use `enum` over constants for well-defined symbolic sets.
- Use `ref struct` where applicable.

### ⛏ Performance Constructs

- Use:
  - `Span<T>`, `ReadOnlySpan<T>`
  - `stackalloc` for small buffer allocations
  - `ArrayPool<T>.Shared` for large or frequent allocations
  - `Unsafe`, `BitOperations`, SIMD (`Vector<T>`) if applicable
- Avoid:
  - Heap allocations in tight loops or hot paths
  - Large Object Heap allocations (`>85k`)
  - Boxing of value types
  - Late-bound dispatch
- Use **`readonly` fields**, **`in` parameters**, and **`scoped` locals** to avoid copies.
- Consider **vectorization** for operations on numeric arrays (via `System.Numerics.Vector<T>`).
- Exploit larger (e.g. `ushort`, `uint`, `ulong`, `Vector128`, `Vector256`, `Vector512` instead of single bytes) register types (block processing) when applicable
- Use **bit hacks and shifts** with **comments explaining them**.

### 🧙 Syntax Preferences

- **Prefer**:
  - Prefix/postfix increment (`++i` instead of `i++`) where possible
  - `var` when the type is obvious or irrelevant
  - `new()` for implicit construction
  - when a line would be applicable to `var` and `new`, prefer `new` and, specifying the type directly e.g.

  ```csharp
  // Instead of:
  var list = new List<string>();

  // Prefer:
  List<string> list = new();

  // Best:
  List<string> list = [];
  ```

  - Collection, Array and object initializers
  - Expression-bodied members
  - Primary constructors, re-use the parameters without separate backing fields, when they are not converted or modified later
  - Switch expressions over statements
  - Ternary operator (`condition ? a : b`) over `if` where concise
  - Tuples & deconstruction over out-parameters
  - `yield return` for lazy sequences
  - `??`, `??=`, `!`, and `?.` for null handling
  - Local functions and closures over nested private methods
  - `async/await`, `Task`, `ValueTask` over blocking calls

### 🧪 Testing & Assertions

- Framework: **NUnit**
- Assertions: **Non-FluentAssertions**
- Coverage:
  - Min 80% (services/logic)
  - Controllers and entry points covered indirectly
- Use `[TestCase]` or `[TestCaseSource]` for param variations
- Do not test implementation details (focus on behavior)

```csharp
[Test]
public void CanAdd() {
  var sut = new Calculator();
  var result = sut.Add(2, 3);
  Assert.That(result, Is.EqualTo(5));
}
```

## 🔒 Argument Validation

- Use guard clauses immediately on method entry
- Validate parameters in declared order
- Prefer centralized guard methods:
  - `Guard.Against.Null(...)`
  - `Guard.Against.RangeViolation(...)`
  - `AlwaysThrow.ExceptionName(...)`
- No duplicate validation in private/internal methods
- Use throw-helpers to allow inlining

  ```csharp
  [MethodImpl(MethodImplOptions.NoInlining)]
  private static void ThrowIfInvalidArg(string name) => throw new ArgumentException(...);
  ```

## 📏 Style Requirements

- No magic numbers – constants or `readonly static` fields only.
- Use `nameof(...)` for argument checks and error messages.
- Local function preferred over private method when scope is internal to another method.
- Use `Span<char>/ReadOnlySpan<char>` for string parsing/processing when performance matters.
- Use `ConfigureAwait(false)` for libraries or non-UI apps.
- No `async void` unless event handler.

## 🔬 Tooling

- Must pass:
  - `dotnet build`
  - `dotnet test`
  
## 🔁 PR Rules

- Include:
  - What changed & why
  - Benchmarks if performance-related
  - Coverage or tests added
- ✅ CI must be green
- ✅ At least 1 reviewer
- ❌ No direct pushes to `main`, `master` or `trunk`
- keep linear history

## 🔐 Deployment

- All secrets are managed by:
  - `.env` files (dev only)
- Docker builds use `--no-cache`, multi-stage, non-root users and distroless base images if possible.
- Deployment targets:
  - `/bin` folder
  - NuGet (.nupkg) or container image depending on project type

## 🧠 Bonus Reading

The Agent is expected to be aware of:

- Bounds-check elimination
- Tail calls vs recursion
- Cache blocking and loop unrolling, Duff's device, T4-templates
- Unsafe memory tricks and stack discipline, pre-allocation, pooling
- Branchless programming patterns
