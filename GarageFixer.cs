using System;

namespace GarageFixer
{
    public class MainMenu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("1. Flooring Cost Calculator");
            Console.WriteLine("2. Drywall Cost Calculator");
            Console.WriteLine("Enter your choice:");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    FlooringCalc();
                    break;
                case 2:
                    DrywallCalc();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void FlooringCalc()
        {
            Console.WriteLine("What is the price of one box of flooring?");
            decimal flooringPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("How many pieces of flooring are in one box?");
            decimal flooringPieces = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the length of the flooring in inches?");
            decimal flooringLength = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the width of the flooring in inches?");
            decimal flooringWidth = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the length of the floor in feet?");
            decimal floorLength = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the width of the floor in feet?");
            decimal floorWidth = Convert.ToDecimal(Console.ReadLine());

            // Get the square footage of the flooring per piece
            decimal flooringSqFt = flooringLength * flooringWidth / 144;
            Console.WriteLine("Flooring sq ft per flooring: " + flooringSqFt);

            // Get the total square footage of the flooring per box
            decimal totalFlooringSqFt = flooringSqFt * flooringPieces;
            Console.WriteLine("Total flooring sq ft per box: " + totalFlooringSqFt);

            // Get the square footage of the floor
            decimal floorSqFt = floorLength * floorWidth;
            Console.WriteLine("Floor sq ft: " + floorSqFt);

            // Get how many boxes needed to cover the floor
            decimal totalFlooring = floorSqFt / totalFlooringSqFt;

            // Get total cost of boxes
            decimal totalCost = totalFlooring * flooringPrice;

            // Add 5% or 10% more boxes for cutting, waste, and future repairs
            decimal fivePercent = totalFlooring * 0.05M + totalFlooring;
            decimal tenPercent = totalFlooring * 0.10M + totalFlooring;

            // Cost of 5% or 10% extra.
            decimal fivePercentCost = fivePercent * flooringPrice;
            decimal tenPercentCost = tenPercent * flooringPrice;

            Console.WriteLine(
                "You will need "
                    + totalFlooring
                    + " boxes of flooring to cover the area.\nThe total cost will be $"
                    + totalCost
                    + ".\nIf purchasing 5% extra for cutting, waste, and future repairs, you will need "
                    + fivePercent
                    + " boxes which will cost $"
                    + fivePercentCost
                    + ".\nIf purchasing 10% extra for cutting, waste, and future repairs, you will need "
                    + tenPercent
                    + " boxes which will cost $"
                    + tenPercentCost
                    + "."
            );
        }

        public static void DrywallCalc()
        {
            Console.WriteLine("How many walls will need drywalled?");
            int totalWalls = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the price of one piece of drywall?");
            decimal drywallPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the length of the drywall in feet?");
            decimal drywallLength = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the width of the drywall in feet?");
            decimal drywallWidth = Convert.ToDecimal(Console.ReadLine());

            decimal totalWallSqFt = 0;

            for (int i = 1; i <= totalWalls; i++)
            {
                Console.WriteLine("What is the height of the wall " + i + " in feet?");
                decimal wallHeight = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("What is the width of the wall  " + i + " in feet?");
                decimal wallWidth = Convert.ToDecimal(Console.ReadLine());

                decimal wallSqFt = wallHeight * wallWidth;
                totalWallSqFt += wallSqFt;
            }

            // Get the square footage of the drywall per sheet
            decimal drywallSqFt = drywallLength * drywallWidth;
            int roundedDrywallSqFt = (int)Math.Ceiling(drywallSqFt);
            Console.WriteLine("Drywall sq ft per sheet: " + roundedDrywallSqFt);

            // Get the square footage of the wall
            Console.WriteLine("Total wall sq ft: " + totalWallSqFt);

            // Get how many sheets needed to cover the wall
            decimal totalDrywall = totalWallSqFt / drywallSqFt;
            int roundedTotalDrywall = (int)Math.Ceiling(totalDrywall);

            // Get total cost of boxes
            decimal totalCost = roundedTotalDrywall * drywallPrice;

            // Add one or two sheets for cutting, waste, and future repairs
            decimal fivePercent = roundedTotalDrywall + 1;
            decimal tenPercent = roundedTotalDrywall + 2;

            // Cost of one or two sheets extra.
            decimal fivePercentCost = fivePercent * drywallPrice;
            decimal tenPercentCost = tenPercent * drywallPrice;

            Console.WriteLine(
                "You will need "
                    + roundedTotalDrywall
                    + " sheets of drywall to cover the area.\nThe total cost will be $"
                    + totalCost
                    + ".\nIf purchasing one sheet extra for cutting and waste, you will need "
                    + fivePercent
                    + " sheets which will cost $"
                    + fivePercentCost
                    + ".\nIf purchasing two sheet extra for cutting and waste, you will need "
                    + tenPercent
                    + " sheets which will cost $"
                    + tenPercentCost
                    + "."
            );
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu.ShowMenu();
        }
    }
}
