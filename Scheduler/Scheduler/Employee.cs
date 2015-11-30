using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class Employee
    {
        public String name;
        public int hoursAvTotal;
        public int[][] availability;
        public int hoursWorkedToday;
        public bool hasWorkedToday;
        public bool isWorking;
        public int idNum;


        public Employee(String Pname, int PHoursAvTotal, int[][] Pavailability, bool PhasWorkedToday, int PidNum)
        {
            name = Pname;

            hoursAvTotal = PHoursAvTotal;
            availability = Pavailability;
            hasWorkedToday = PhasWorkedToday;
            idNum = PidNum;
            hoursWorkedToday = 0;
            isWorking = false;
        }

        public Employee()
        {
            
        }

        public int getBlocks()
        {
            int blockCount = 0;

            for (int i = 0; i < availability.Length; i++)
            {
                for (int j = 0; j < availability[i].Length; j++)
                {
                    if (availability[i][j] == 1)
                    {
                        blockCount++;
                    }
                }
            }

            return blockCount;
        }
    }
}
