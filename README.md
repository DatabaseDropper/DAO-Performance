# DAO Performance
 
Comparison between EF Core and Dapper when loading N objects from database to memory.

Benchmarking Tool: BenchmarkDotNet

# How To Run It

	cd src
	dotnet run -c Release

# Sample Results

* 400 000 rows

		BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
		AMD Athlon 200GE with Radeon Vega Graphics, 1 CPU, 4 logical and 2 physical cores
		.NET Core SDK=5.0.100
			[Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
			DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
			
	|       Method |    Mean |    Error |   StdDev |
	|------------- |--------:|---------:|---------:|
	| DapperGetAll | 1.255 s | 0.0278 s | 0.0802 s |
	| EFCoreGetAll | 3.315 s | 0.0602 s | 0.0563 s |


		// * Hints *
		
			Outliers
			Program.DapperGetAll: Default -> 4 outliers were removed (1.54 s..1.82 s)
			Program.EFCoreGetAll: Default -> 1 outlier  was  detected (3.16 s)
  
		* Legends *
			Mean   : Arithmetic mean of all measurements
			Error  : Half of 99.9% confidence interval
			StdDev : Standard deviation of all measurements
			1 s    : 1 Second (1 sec)
			
* 40 000 rows


	|       Method |     Mean |    Error |   StdDev |   Median |
	|------------- |---------:|---------:|---------:|---------:|
	| DapperGetAll | 120.3 ms |  3.93 ms | 11.22 ms | 117.5 ms |
	| EFCoreGetAll | 315.0 ms | 11.53 ms | 32.89 ms | 304.2 ms |

		// * Hints *
		
			Outliers
			  Program.DapperGetAll: Default -> 6 outliers were removed (158.67 ms..297.74 ms)
			  Program.EFCoreGetAll: Default -> 6 outliers were removed (428.65 ms..552.69 ms)

		// * Legends *
			  Mean   : Arithmetic mean of all measurements
			  Error  : Half of 99.9% confidence interval
			  StdDev : Standard deviation of all measurements
			  Median : Value separating the higher half of all measurements (50th percentile)
			  1 ms   : 1 Millisecond (0.001 sec)
