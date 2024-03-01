```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method           | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|----------------- |------- |--------- |---------:|----------:|----------:|---------:|-------:|----------:|
| **HasAccess**        | **2**      | **1**        | **1.065 ms** | **0.0194 ms** | **0.0466 ms** | **1.045 ms** | **1.9531** |  **11.89 KB** |
| HasAccessOnlySQL | 2      | 1        | 1.039 ms | 0.0174 ms | 0.0171 ms | 1.036 ms | 3.9063 |  12.62 KB |
| **HasAccess**        | **50**     | **51**       | **1.345 ms** | **0.0797 ms** | **0.2337 ms** | **1.303 ms** | **3.9063** |  **12.15 KB** |
| HasAccessOnlySQL | 50     | 51       | 1.610 ms | 0.1039 ms | 0.3030 ms | 1.597 ms | 3.9063 |  12.88 KB |
| **HasAccess**        | **100**    | **1**        | **1.733 ms** | **0.1674 ms** | **0.4909 ms** | **1.685 ms** | **3.9063** |  **12.44 KB** |
| HasAccessOnlySQL | 100    | 1        | 1.338 ms | 0.0262 ms | 0.0565 ms | 1.319 ms | 3.9063 |  13.47 KB |
| **HasAccess**        | **100**    | **50**       | **1.272 ms** | **0.0334 ms** | **0.0941 ms** | **1.267 ms** | **3.9063** |  **12.44 KB** |
| HasAccessOnlySQL | 100    | 50       | 1.055 ms | 0.0199 ms | 0.0204 ms | 1.051 ms | 3.9063 |  13.18 KB |
| **HasAccess**        | **100**    | **99**       | **1.054 ms** | **0.0210 ms** | **0.0225 ms** | **1.047 ms** | **3.9063** |  **12.44 KB** |
| HasAccessOnlySQL | 100    | 99       | 1.057 ms | 0.0194 ms | 0.0172 ms | 1.054 ms | 3.9063 |  13.46 KB |
