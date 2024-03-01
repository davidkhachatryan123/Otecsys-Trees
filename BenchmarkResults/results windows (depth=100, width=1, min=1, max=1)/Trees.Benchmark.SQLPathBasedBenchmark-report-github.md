```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method    | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|----------:|----------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **1.120 ms** | **0.0272 ms** | **0.0790 ms** | **1.100 ms** | **1.9531** |   **8.76 KB** |
| **HasAccess** | **50**     | **51**       | **1.091 ms** | **0.0217 ms** | **0.0624 ms** | **1.063 ms** | **1.9531** |   **9.03 KB** |
| **HasAccess** | **100**    | **1**        | **1.055 ms** | **0.0208 ms** | **0.0204 ms** | **1.050 ms** | **1.9531** |   **9.32 KB** |
| **HasAccess** | **100**    | **50**       | **1.103 ms** | **0.0247 ms** | **0.0724 ms** | **1.068 ms** | **1.9531** |   **9.32 KB** |
| **HasAccess** | **100**    | **99**       | **1.053 ms** | **0.0197 ms** | **0.0154 ms** | **1.050 ms** | **1.9531** |   **9.32 KB** |
