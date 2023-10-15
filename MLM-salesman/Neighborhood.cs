using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM_salesman
{
    public class Neighborhood
    {
        // List to store the houses in the neighborhood
        public List<House> houses;
        public Random random;
        // Number of columns in the neighborhood grid
        public int Cols;
        // Number of rows in the neighborhood grid
        public int Rows;


        public Neighborhood(int rows, int cols)
        {
            houses = new List<House>();
            Cols = cols;
            Rows = rows;


            random = new Random();
            // Create and populate the neighborhood with houses
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var house = new House();
                    // Set the X row coordinate of the house
                    // Set the Y column coordinate of the house
                    house.X = i;
                    house.Y = j;
                    // Add the house to the list
                    houses.Add(house);
                    //Console.WriteLine(house);
                }
            }

            PlaceInitialSalesman();
        }
        public void PlaceInitialSalesman()
        {
            // Salesman in the top-left corner
            houses[0].ConvertToSalesman();

        }



        public void Update()
        {
            List<House> activeSalesmen = new List<House>();

            // salesmen to a separate list to avoid modifying the original list while iterating
            activeSalesmen.AddRange(GetSalesmen());

            foreach (House salesman in activeSalesmen)
            {
                for (int i = 0; i < salesman.SalesmanCount; i++)
                {
                    int direction = random.Next(4); // 0 for up, 1 for right, 2 for down, 3 for left
                    int newRow = salesman.X;
                    int newCol = salesman.Y;

                    switch (direction)
                    {
                        case 0: // Up
                            newRow = Math.Max(0, newRow - 1);
                            break;
                        case 1: // Right
                            newCol = Math.Min(houses.Count - 1, newCol + 1);
                            break;
                        case 2: // Down
                            newRow = Math.Min(houses.Count - 1, newRow + 1);
                            break;
                        case 3: // Left
                            newCol = Math.Max(0, newCol - 1);
                            break;
                    }

                    //  Calculate the one-dimensional index for the new coordinates
                    int newIndex = newRow * Cols + newCol;

                    // Check if the new coordinates are within the bounds of the neighborhood
                    if (newIndex >= 0 && newIndex < houses.Count)
                    {
                        if (!houses[newIndex].GetIsSalesman())
                        {
                            houses[newIndex].ConvertToSalesman();
                        }
                    }
                }
            }
        }


        public bool AllHousesAreSalesmen()
        {
            return houses.All(house => house.GetIsSalesman());
        }

        public IEnumerable<House> GetSalesmen()
        {
            return houses.Where(house => house.GetIsSalesman());
        }
    }
}
