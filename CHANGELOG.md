# Changelog

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
