```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method    | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|----------:|----------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **1.063 ms** | **0.0211 ms** | **0.0370 ms** | **1.047 ms** | **1.9531** |   **8.67 KB** |
| **HasAccess** | **50**     | **51**       | **1.072 ms** | **0.0214 ms** | **0.0526 ms** | **1.051 ms** | **1.9531** |   **8.67 KB** |
| **HasAccess** | **100**    | **1**        | **1.087 ms** | **0.0216 ms** | **0.0606 ms** | **1.056 ms** | **1.9531** |   **8.67 KB** |
| **HasAccess** | **100**    | **50**       | **1.132 ms** | **0.0309 ms** | **0.0895 ms** | **1.111 ms** | **1.9531** |   **8.78 KB** |
| **HasAccess** | **100**    | **99**       | **1.103 ms** | **0.0249 ms** | **0.0708 ms** | **1.077 ms** | **1.9531** |   **8.67 KB** |
