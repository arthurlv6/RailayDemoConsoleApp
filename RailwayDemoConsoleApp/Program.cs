using System;
using System.Threading.Tasks;

namespace RailwayDemoConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //await Task.Delay(100);
            string canBeAnyType = "";
            var maybe = Maybe.Ok(canBeAnyType); //convert anytime to Maybe type.

            var result = maybe.Railway(r => Method1(r))
                .Railway(r => Method2(r))
                .Railway(r => Method3(r));

            if (result.IsFailure)
                Console.WriteLine("Failed");
            else
                Console.WriteLine("Success");

            var resultAsync = await (await (await maybe
                .RailwayAsync(async r => await Method1Async(r)))
                .RailwayAsync(async r => await Method2Async(r)))
                .RailwayAsync(async r => await Method3Async(r));


            if (resultAsync.IsFailure)
                Console.WriteLine("async Failed");
            else
                Console.WriteLine("async Success");

            Console.ReadLine();
        }

        public static Maybe<string> Method1(Maybe<string> maybe)
        {
            if (maybe.Value.Length > 1)
                return maybe;

            return Maybe.Fail<string>("Failed");
        }
        public static Maybe<string> Method2(Maybe<string> maybe)
        {
            if (maybe.Value.Length > 1)
                return maybe;

            return Maybe.Fail<string>("Failed");
        }
        public static Maybe<string> Method3(Maybe<string> maybe)
        {
            if (maybe.Value.Length > 1)
                return maybe;

            return Maybe.Fail<string>("Failed");
        }

        public static async Task<Maybe<string>> Method1Async(Maybe<string> maybe)
        {
            await Task.Delay(100);
            if (maybe.Value.Length > 1)
                return maybe;

            return Maybe.Fail<string>("Failed");
        }
        public static async Task<Maybe<string>> Method2Async(Maybe<string> maybe)
        {
            await Task.Delay(100);
            if (maybe.Value.Length > 1)
                return maybe;

            return Maybe.Fail<string>("Failed");
        }
        public static async Task<Maybe<string>> Method3Async(Maybe<string> maybe)
        {
            await Task.Delay(100);
            if (maybe.Value.Length > 1)
                return maybe;

            return Maybe.Fail<string>("Failed");
        }
    }
}
