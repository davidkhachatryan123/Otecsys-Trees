```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **600.6 μs** | **11.95 μs** | **29.08 μs** | **1.9531** |  **12.89 KB** |
| **HasAccess** | **1905**   | **1**        | **619.2 μs** | **11.34 μs** | **22.38 μs** | **1.9531** |  **12.88 KB** |
