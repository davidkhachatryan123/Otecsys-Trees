```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId               | parentId             | Mean     | Error     | StdDev   | Gen0   | Gen1   | Allocated |
|---------- |--------------------- |--------------------- |---------:|----------:|---------:|-------:|-------:|----------:|
| **HasAccess** | **65e60(...)99ea3 [24]** | **65e60(...)99e9f [24]** | **770.4 μs** | **101.24 μs** | **293.7 μs** | **7.8125** | **3.9063** |  **51.21 KB** |
| **HasAccess** | **65e60(...)9ae9b [24]** | **65e60(...)99e9f [24]** | **843.3 μs** |  **96.39 μs** | **279.6 μs** | **7.8125** | **1.9531** |  **56.67 KB** |
