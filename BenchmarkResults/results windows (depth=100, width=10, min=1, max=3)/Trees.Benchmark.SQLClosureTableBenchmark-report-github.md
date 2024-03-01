```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method    | nodeId | parentId | Mean     | Error     | StdDev    | Gen0   | Allocated |
|---------- |------- |--------- |---------:|----------:|----------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **1.050 ms** | **0.0201 ms** | **0.0168 ms** | **1.9531** |  **11.69 KB** |
| **HasAccess** | **1948**   | **1**        | **1.055 ms** | **0.0204 ms** | **0.0330 ms** | **1.9531** |  **11.69 KB** |
