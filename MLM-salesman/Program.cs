using MLM_salesman;

class Program
{
    static void Main(string[] args)
    {
        int totalSimulations = 10;
        int totalRuntime = 0;

        for (int simulation = 0; simulation < totalSimulations; simulation++)
        {
            int totalTime = 0;
            Neighborhood neighborhood = new Neighborhood(6, 5);

            while (!neighborhood.AllHousesAreSalesmen())
            {
                neighborhood.Update();
                totalTime++;
            }

            Console.WriteLine($"Simulation {simulation + 1}: took {totalTime} hours for the entire neighborhood to become salesmen.");
            totalRuntime += totalTime;
        }

        double averageTime = (double)totalRuntime / totalSimulations;
        Console.WriteLine($"Average time over {totalSimulations} simulations: {averageTime} hours");

    }
}