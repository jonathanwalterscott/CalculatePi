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
            pi.NumberOfIterations = options.Iterations;
            var result = pi.Calculate();
            Console.WriteLine($"Result = [{result}]");
        }
    }
}
