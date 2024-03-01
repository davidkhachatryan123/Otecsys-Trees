```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method           | nodeId | parentId | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------- |------- |--------- |---------:|----------:|----------:|-------:|----------:|
| **HasAccess**        | **2**      | **1**        | **1.053 ms** | **0.0154 ms** | **0.0129 ms** | **1.9531** |  **11.89 KB** |
| HasAccessOnlySQL | 2      | 1        | 1.047 ms | 0.0179 ms | 0.0150 ms | 3.9063 |  12.62 KB |
| **HasAccess**        | **1948**   | **1**        | **1.061 ms** | **0.0205 ms** | **0.0192 ms** | **3.9063** |  **12.73 KB** |
| HasAccessOnlySQL | 1948   | 1        | 1.064 ms | 0.0126 ms | 0.0111 ms | 3.9063 |  13.67 KB |
