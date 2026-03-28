# Changelog

## 0.3.0 (2026-03-27)

- Expand to 50+ ISO 4217 currencies (was 10)
- Add rounding modes (bankers, away from zero, towards zero)
- Add percentage and tax calculation methods
- Add Round method with configurable decimal places

## 0.2.5 (2026-03-26)

- Add Sponsor badge to README
- Fix License section format

## 0.2.4 (2026-03-21)

- Fix version numbering to supersede previously published 0.2.3

## 0.1.6 (2026-03-20)

- Align README and csproj descriptions

## 0.1.5 (2026-03-20)

- Add `Parse` and `TryParse` methods for creating Money from formatted strings
- Add `Convert` method for currency conversion with explicit exchange rates
- Add `Divide` method for splitting money into equal parts with remainder distribution
- Add Development section to README
- Expand README with arithmetic, formatting, allocation, and comparison examples
- Add GenerateDocumentationFile, RepositoryType, LangVersion, and TreatWarningsAsErrors to csproj

## 0.1.1 (2026-03-10)

- Fix README path in csproj so README displays on nuget.org

## 0.1.0 (2026-03-10)

- Initial release
- `Currency` value type with code, symbol, and decimal places
- `Currencies` with 10 pre-defined ISO 4217 currencies
- `Money` value type backed by `long` minor units
- `Money.Of` factory from `decimal`
- Arithmetic: `Add`, `Subtract`, `Multiply`, `Negate`, `Abs`
- `Allocate` — proportional distribution with remainder handling
- `ToDecimal`, `Format` display helpers
- Comparison operators and `IComparable<Money>`
