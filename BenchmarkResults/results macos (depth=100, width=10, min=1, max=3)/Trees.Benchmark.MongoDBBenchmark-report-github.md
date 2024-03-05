```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId               | parentId             | Mean     | Error   | StdDev  | Gen0   | Allocated |
|---------- |--------------------- |--------------------- |---------:|--------:|--------:|-------:|----------:|
| **HasAccess** | **65e60(...)99ea3 [24]** | **65e60(...)99e9f [24]** | **267.7 μs** | **5.35 μs** | **8.01 μs** | **4.3945** |  **28.56 KB** |
| **HasAccess** | **65e60(...)9ae9b [24]** | **65e60(...)99e9f [24]** | **275.3 μs** | **5.44 μs** | **4.54 μs** | **5.3711** |  **34.25 KB** |
