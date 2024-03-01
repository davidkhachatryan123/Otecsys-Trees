```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method    | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|----------:|----------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **1.026 ms** | **0.0108 ms** | **0.0085 ms** | **1.025 ms** | **1.9531** |  **11.69 KB** |
| **HasAccess** | **50**     | **51**       | **1.024 ms** | **0.0172 ms** | **0.0177 ms** | **1.018 ms** | **1.9531** |  **11.69 KB** |
| **HasAccess** | **100**    | **1**        | **1.045 ms** | **0.0193 ms** | **0.0389 ms** | **1.029 ms** | **1.9531** |  **11.69 KB** |
| **HasAccess** | **100**    | **50**       | **1.042 ms** | **0.0205 ms** | **0.0419 ms** | **1.021 ms** | **1.9531** |  **11.69 KB** |
| **HasAccess** | **100**    | **99**       | **1.035 ms** | **0.0178 ms** | **0.0175 ms** | **1.030 ms** | **1.9531** |  **11.69 KB** |
