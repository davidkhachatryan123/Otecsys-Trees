# Otecsys Trees

This project's objective is to find the fastest way of getting ancestor of descendant from a tree structure. There're 3 solutions and the benchmarks for each one: Path based with MSSQL, Closure Table based with MSSQL and Elasticsearch based.

### Requirements

| Name   | Description |
| ------ | ----------- |
| Docker Desktop | Please, note that `docker-compose` is needed too and is included in the Docker Desktop installation. Docker Desktop is available for [Windows](https://docs.docker.com/desktop/install/windows-install/), [Mac](https://docs.docker.com/desktop/install/mac-install/) and [Linux](https://docs.docker.com/desktop/install/linux-install/). |
| .NET 8.0.2 | [Download .NET](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) from Microsoft's website |
| Entity Framework Core CLI 8.0.2 | dotnet tool install --global dotnet-ef |

## Getting Started

At first you sould copy repository and open terminal in project's directory. Than make sure you are in the **src** directory:

```
git clone https://github.com/davidkhachatryan123/Otecsys-Trees.git 
cd Otecsys-Trees/src
```

Make sure you have installed [Docker Desktop](https://docs.docker.com/docker-for-windows/install/) in your environment. After that, you can run the commands bellow and get started exploring application immediately.

```
docker-compose -f docker-compose.yml -f docker-compose.prod.override.yml up -d
```

You should migrate MSSQL database manualy from migrations of each project:

```
dotnet ef database update -p SQL.ClosureTable -s SQL.ClosureTable/SQL.ClosureTable.csproj

dotnet ef database update -p SQL.PathBased -s SQL.PathBased/SQL.PathBased.csproj
```

### Basic scenarios

The basic scenario can be run locally using docker-compose. Refer to these Wiki pages to Get Started:

- Docker compose setup (will be available soon)
- Tree structure generator (will be available soon)
- Tree test (will be available soon)
- Benchmark (will be available soon)

### Files structure overview

```
├── README.md                       -> Current doc file
├── elastic_queries.txt             -> Elasticsearch console queries
├── BenchmarkResults                -> All results of benchmarking
└── src                             -> Project sources
    ├── Common                      -> Shared logic
    ├── ElasticStack                -> Solution with Elasticsearch
    ├── SQL.ClosureTable            -> Solution based on Closure Table
    ├── SQL.PathBased               -> Solution based on Path logic
    ├── Trees.Generator             -> Tree structure generator
    ├── Trees.Test                  -> Functional tests with xUnit
    ├── Trees.Benchmark             -> Benchmarks
    ├── Trees.sln                   -> Solution file
    ├── docker-compose.dcproj       -> docker compose project file
    ├── docker-compose.yml          -> docker compose main
    ├── docker-compose.override.yml -> docker compose overrided
    └── docker-compose.debug.yml    -> docker compose for debugging
```

## Benchmark results

> Please visit wiki to explore more about benchmark results(comming soon, P.S. You can explore result files in BenchmarkResults directory).

### Environment

* **BenchmarkDotNet version**: v0.13.12
* **.NET version**: 8.0.201
* **Operating System**: macOS Sonoma 14.2.1
* **CPU**: Apple M1
* **Cores**: 8 logical and 8 physical cores

### Path based on MSSQL

| Method | nodeId | parentId | Mean | Error | StdDev| Median | Gen0 | Allocated |
|----------------- |------- |--------- |---------:|---------:|---------:|---------:|-------:|----------:|
| **HasAccess**        | **100**    | **1**        | **835.1 μs** | **25.95 μs** | **75.30 μs** | **812.4 μs** | **1.9531** |  **13.62 KB** |
| **HasAccess**        | **100**    | **99**       | **774.1 μs** | **18.25 μs** | **52.66 μs** | **763.2 μs** | **1.9531** |  **13.95 KB** |
| **HasAccess**        | **2**      | **1**        | **707.2 μs** | **17.05 μs** | **47.82 μs** | **695.7 μs** | **1.9531** |  **13.32 KB** |

### Closure Table based on MSSQL

| Method | nodeId | parentId | Mean | Error | StdDev | Gen0 | Allocated |
|-------------------- |------- |--------- |-----------:|----------:|----------:|-------:|----------:|
| **HasAccess** | **100**    | **1**        | **689.2 μs** | **13.74 μs** | **26.48 μs** | **1.9531** |  **12.91 KB** |
| **HasAccess** | **100**    | **99**       | **697.3 μs** | **13.84 μs** | **38.59 μs** | **1.9531** |  **12.96 KB** |
| **HasAccess** | **2**      | **1**        | **670.8 μs** | **17.21 μs** | **49.37 μs** | **1.9531** |  **12.97 KB** |

### Elasticsearch based on "Path hierarchy tokenizer"

| Method | nodeId | parentId | Mean | Error | StdDev | Gen0 | Allocated |
|-------------------- |------- |--------- |-----------:|----------:|----------:|-------:|----------:|
| **HasAccess**            | **100**    | **1**        |   **401.1 μs** |  **15.38 μs** |  **44.87 μs** | **0.9766** |  **11.02 KB** |
| **HasAccess**            | **100**    | **99**       |   **414.3 μs** |  **11.94 μs** |  **34.64 μs** | **1.4648** |  **11.02 KB** |
| **HasAccess**            | **2**      | **1**        |   **416.6 μs** |  **12.92 μs** |  **37.89 μs** | **1.4648** |   **9.77 KB** |


## Conclusion

### Path based

The results have shown us that it is the least effective method for retrieving data from the database. But if we use small and static(
without requiring frequent updates to nodes) trees, it's the most proper way because easy to add new nodes.

* **Pros**
  + Eeasy to run queries to find all descendants or ancestors of a node
  + Easy to add new nodes

* **Cons**
  + If structure changes frequiently, paths must be updated for all related nodes
  + The path will become excessively lengthy if we have a large tree

### Closure Table

Based on benchmarking results, it's a bit faster with trees that aren't very deep and more efficient with medium and large ones. It also isn't easy to update nodes because we should make changes on many rows depending on dept of current one.

* **Pros**
  + Quick accessing all descendants and ancestors of a node without needing to execute recursive queries
  + Suitable for medium and large hierarchical structures

* **Cons**
  + The expense of updating the Closure table when nodes are added or removed

### Elasticsearch

Reviewing all the results, it appears to be the quickest method for retrieving documents from the Elasticsearch index. It utilizes the "Path hierarchy tokenizer" to analyze documents. This solution closely resembles the "Path based" approach in terms of storing node logic. Additionally, the results indicate that it's the most efficient in terms of memory usage, which is advantageous for hosts with limited memory.

* **Pros**
  + It employs an Elasticsearch analyzer to achieve the quickest results
  + In the future, it can be utilized to generate data analytic reports or integrate advanced search logic

* **Cons**
  + Elasticsearch serves as a secondary database, necessitating the presence of a relational database to store primary data and synchronize relationships within the Elasticsearch index

