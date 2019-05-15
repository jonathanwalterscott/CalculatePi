using System;
using CommandLine;
using CalculatePi.Library;

namespace CalculatePi.CLI
{

    public class CalculatePi_CLI_Options
    {
        [Option('i', "iterations", Required = true)]
        public int Iterations { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var arguments = Parser.Default.ParseArguments<CalculatePi_CLI_Options>(args);
            arguments.WithParsed<CalculatePi_CLI_Options>(options => Run(options));
        }

        static void Run(CalculatePi_CLI_Options options)
        {
            var pi = new Gregory_Leibniz();
            var stopWatch = new System.Diagnostics.Stopwatch();
            pi.NumberOfIterations = options.Iterations;
            stopWatch.Start();
            var result = pi.Calculate();
            stopWatch.Stop();
            Console.WriteLine($"Result = [{result}] achieved in {stopWatch.ElapsedMilliseconds}ms");
        }
    }
}
