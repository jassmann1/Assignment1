using ModernAppliances.Entities.Abstract;
using ModernAppliances.Entities;
using ModernAppliances.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernAppliances.Entities
{
    internal class Vacuum : Appliance
    {
        // Other properties and methods...

        public int Voltage { get; set; }  

        // Other properties and methods...
    }
}

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.Write("Enter the item number of an appliance: ");
            long itemNumber;
            if (!long.TryParse(Console.ReadLine(), out itemNumber))
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            Appliance? foundAppliance = null;

            foreach (var appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.Write("Enter brand to search for: ");
            string? brand = Console.ReadLine();
            var found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                {
                    found.Add(appliance);
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refrigerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");
            Console.Write("Enter number of doors: ");

            int numOfDoors;
            if (!int.TryParse(Console.ReadLine(), out numOfDoors))
            {
                Console.WriteLine("Invalid number of doors.");
                return;
            }

            var found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Refrigerator refrigerator)
                {
                    if (numOfDoors == 0 || refrigerator.Doors == numOfDoors)
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");
            Console.Write("Enter grade: ");

            string? gradeInput = Console.ReadLine();
            string? grade = gradeInput switch
            {
                "0" => "Any",
                "1" => "Residential",
                "2" => "Commercial",
                _ => null
            };


            if (grade == null)
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");
            Console.Write("Enter voltage: ");

            int voltageInput;
            if (!int.TryParse(Console.ReadLine(), out voltageInput) || (voltageInput != 0 && voltageInput != 18 && voltageInput != 24))
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    if ((grade == "Any" || vacuum.Grade.Equals(grade, StringComparison.OrdinalIgnoreCase)) &&
                        (voltageInput == 0 || vacuum.Voltage == voltageInput))
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            Console.Write("Enter room type: ");

            string? roomTypeInput = Console.ReadLine();
            //Validate input to ensure it's not null or empty
            if(string.IsNullOrEmpty(roomTypeInput))
            {
                Console.WriteLine("invalid option.");
                return;
            }
            //Using switch expression with pattern matching for roomTypeInput
            char roomType = roomTypeInput switch
            {
                "0" => 'A',
                "1" => 'K',
                "2" => 'W',
                _ => 'I'
            };

            if (roomType == 'I')
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Microwave microwave)
                {
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");
            Console.Write("Enter sound rating: ");

            string? soundRatingInput = Console.ReadLine();
            if (soundRatingInput == null)
            {
                Console.WriteLine("Input cannot be null.");

                string? soundRating = soundRatingInput switch
                {
                    "0" => "Any",
                    "1" => "Qt",
                    "2" => "Qr",
                    "3" => "Qu",
                    "4" => "M",
                    _ => null
                };

                if (soundRating == null)
                {
                    Console.WriteLine("Invalid option.");
                    return;
                }

                // Rest of the method logic


                if (soundRating == null)
                {
                    Console.WriteLine("Invalid option.");
                    return;
                }

                var found = new List<Appliance>();

                foreach (var appliance in Appliances)
                {
                    if (appliance is Dishwasher dishwasher)
                    {
                        if (soundRating == "Any" || dishwasher.SoundRating.Equals(soundRating, StringComparison.OrdinalIgnoreCase))
                        {
                            found.Add(appliance);
                        }
                    }
                }

                DisplayAppliancesFromList(found, 0);
            }
        }
        

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.Write("Enter type of appliance: ");

            int applianceType;
            if (!int.TryParse(Console.ReadLine(), out applianceType) || applianceType < 0 || applianceType > 4)
            {
                Console.WriteLine("Invalid appliance type.");
                return;
            }

            Console.Write("Enter number of appliances: ");
            int num;
            if (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
            {
                Console.WriteLine("Invalid number of appliances.");
                return;
            }

            var found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                switch (applianceType)
                {
                    case 0:
                        found.Add(appliance);
                        break;
                    case 1:
                        if (appliance is Refrigerator)
                            found.Add(appliance);
                        break;
                    case 2:
                        if (appliance is Vacuum)
                            found.Add(appliance);
                        break;
                    case 3:
                        if (appliance is Microwave)
                            found.Add(appliance);
                        break;
                    case 4:
                        if (appliance is Dishwasher)
                            found.Add(appliance);
                        break;
                }
            }
        }

    }
}