using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make new instance of the Cars Collection
            CarsTKeranenEntities CarTestEntities = new CarsTKeranenEntities();

            //*************************************
            //List out all of the cars in the table
            //*************************************

            Console.WriteLine("Print the list");

            foreach (Car car in CarTestEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

            //**************************************************************
            //Find a specific one by any property
            //**************************************************************

            // Call the where method on the table Cars and pass in a lambda expressiong
            // for the criteria we are looking for. There is nothing special about the word
            // car in the part that reads: car => car.id == "V0....". It could be any characters we
            // want it to be. It is just a variable name for the current car we are considering 
            // in the expression against each of them. When the result if finally true, it will return
            // that car.
            Car carToFind = CarTestEntities.Cars.Where(car => car.id == "V0LCD1814").First();

            // We can look for a specific model from the database. With a where clause based on any
            // criteria we want we can narrow it down. Here we are doing it with the car's model
            // instead of its ID.
            Car otherCarToFind = CarTestEntities.Cars.Where(car => car.model == "Challenger").First();

            // Print them out
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Find 2 specific cars:");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);
            Console.WriteLine(otherCarToFind.id + " " + otherCarToFind.make + " " + otherCarToFind.model);

            //**************************************************************
            // Find a car based on the primary id
            // *************************************************************

            // pull out a car from the table based on the id which is the primary key.
            // If the record doesn't exist in the database, it will return null
            Car foundCar = CarTestEntities.Cars.Find("V0LCD1814");

            //Print it out
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Print out a found car using the find method");

            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);

            //************************************************************
            //Add new car to database
            //**************************************************************

            // make an instance of a new car
            Car newCarToAdd = new Car();

            //Assign properties to the parts of the model
            newCarToAdd.id = "88888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2016";
            newCarToAdd.type = "Car";

            // Add the new car to the cars collection
            CarTestEntities.Cars.Add(newCarToAdd);

            //This method call actually does the work of saving the changes to the database
            CarTestEntities.SaveChanges();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Just added a new car. Going to fetch it and print it to verify.");
            carToFind = CarTestEntities.Cars.Find("88888");
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);
            
            //********************************************************************
            // How to do an update
            // ********************************************************************


            //Get a car out of the database that we would like to update
            Car carToFindForUpdate = CarTestEntities.Cars.Find("V0LCD1814");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("About to do an update on a car.");
            Console.WriteLine(carToFindForUpdate.id + " " + carToFindForUpdate.make + " " + carToFindForUpdate.model);
            Console.WriteLine("Doing update now");

            // Update some of the properties of the car we found. Don't need to update all of
            // them if we don't want to. I choose these 4.

            carToFindForUpdate.make = "Nissan";
            carToFindForUpdate.model = "GT-RRRRRRR";
            carToFindForUpdate.horsepower = 1250;
            carToFindForUpdate.cylinders = 16;

            // Save the changes to the database. Since when we pulled out the one to update, all
            // we were really doing was getting a reference to the one in the collection we
            // wanted to update. There is no need to 'put' the car back into the cars collection.
            // It is still there. 
            CarTestEntities.SaveChanges();


            carToFindForUpdate = CarTestEntities.Cars.Find("88888");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Outputting the updated car that was retreived from the database.");
            Console.WriteLine(carToFindForUpdate.id + " " + carToFindForUpdate.make + " " + carToFindForUpdate.model);
            Console.WriteLine("Doing update now");

            //**********************************************
            //how to do a delete
            //**********************************************

            // Get a car out of the database that we would like to delete
            Car carToFindForDelete = CarTestEntities.Cars.Find("88888");

            // Remove the Car from the cars collection
            CarTestEntities.Cars.Remove(carToFindForDelete);

            // Save the changes to the database
            CarTestEntities.SaveChanges();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleted the added car. Looking to see if it is still in the DB");

            // try to get the car out of the database and print it out
            try
            {
                carToFindForDelete = CarTestEntities.Cars.Find("88888");
                Console.WriteLine(carToFindForDelete.id + " " + carToFindForDelete.make + " " + carToFindForDelete.model);
            }
            catch (Exception e)
            {
                Console.WriteLine("The model you are looking for does not exist " + e.ToString() + e.StackTrace);
            }

            // Also going to see if we can do a test for null instead of a try catch
            if (carToFindForDelete == null)
            {
                Console.WriteLine("Yes we can do a test for a null as well.");
            }
        }
        static bool myFunc(Car car)
        {
            return car.model == "Challenger";
        }
        
    }
}
