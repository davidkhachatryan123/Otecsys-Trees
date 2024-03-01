```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method    | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|----------:|----------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **1.071 ms** | **0.0213 ms** | **0.0501 ms** | **1.046 ms** | **1.9531** |   **8.67 KB** |
| **HasAccess** | **1919**   | **1**        | **1.049 ms** | **0.0156 ms** | **0.0242 ms** | **1.041 ms** | **1.9531** |   **8.67 KB** |
