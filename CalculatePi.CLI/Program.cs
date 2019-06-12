using System;
using CommandLine;
using CalculatePi.Library;

namespace CalculatePi.CLI
{

    public class CalculatePi_CLI_Options
    {
        [Option('i', "iterations", Required = true)]
        public int Iterations { get; set; }

        [Option('m', "model", Required = true)]
        public string Model { get; set; }
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
            IIterativeMethod pi;
            if (options.Model == "Gregory_Leibniz")
            {
                pi = new Gregory_Leibniz();
            }
            else if (options.Model == "Nilikantha")
            {
                pi = new Nilikantha();
            }
            else
            {
                throw new Exception($"Unknown model [{options.Model}]");
            }
            pi.NumberOfIterations = options.Iterations;
            var result = pi.Calculate();
            Console.WriteLine($"Result = [{result}]");
        }
    }
}
