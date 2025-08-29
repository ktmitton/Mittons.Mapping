// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Mittons.Mapping.Benchmarks.Extensions;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<VarIntMemoryExtensionsBenchmarks>();
