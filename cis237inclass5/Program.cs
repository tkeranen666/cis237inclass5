﻿using System;
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
        }
    }
}
