using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Create a writer and open the file
            //TextWriter tw = new StreamWriter("C:/schedule.txt");

            // Create several arrays, days (ever used?), schedule, and openHours. 
            int[][] days = new int[7][];
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = new int[24];
            }

            int[][] schedule = new int[7][];
            for (int i = 0; i < days.Length; i++)
            {
                schedule[i] = new int[24];
            }

            int[][] openHours = new int[7][];
            for (int i = 0; i < days.Length; i++)
            {
                openHours[i] = new int[24];
            }

            List<Employee>employeeList = new List<Employee>();

            // Input variables for open/close hours
            int openSun = 12;
            int closeSun = 24;
            int openMon = 7;
            int closeMon = 24;
            int openTue = 7;
            int closeTue = 24;
            int openWed = 7;
            int closeWed = 24;
            int openThu = 7;
            int closeThu = 24;
            int openFri = 7;
            int closeFri = 24;
            int openSat = 9;
            int closeSat = 18;
            // Employee availability times. 
            // Input variables for employee 1 [morning guy]
            int emp1Sun1 = 0;
            int emp1Sun2 = 0;
            int emp1Mon1 = 7;
            int emp1Mon2 = 14;
            int emp1Tue1 = 7;
            int emp1Tue2 = 14;
            int emp1Wed1 = 7;
            int emp1Wed2 = 14;
            int emp1Thu1 = 7;
            int emp1Thu2 = 14;
            int emp1Fri1 = 7;
            int emp1Fri2 = 12;
            int emp1Sat1 = 0;
            int emp1Sat2 = 0;

            // Input variables for employee 3 [night guy]
            int emp3Sun1 = 14;
            int emp3Sun2 = 24;
            int emp3Mon1 = 14;
            int emp3Mon2 = 24;
            int emp3Tue1 = 14;
            int emp3Tue2 = 24;
            int emp3Wed1 = 14;
            int emp3Wed2 = 24;
            int emp3Thu1 = 14;
            int emp3Thu2 = 24;
            int emp3Fri1 = 14;
            int emp3Fri2 = 24;
            int emp3Sat1 = 0;
            int emp3Sat2 = 0;

            // Input variables for employee 5 [weekend mix guy]
            int emp5Sun1 = 7;
            int emp5Sun2 = 24;
            int emp5Mon1 = 5;
            int emp5Mon2 = 16;
            int emp5Tue1 = 5;
            int emp5Tue2 = 15;
            int emp5Wed1 = 1;
            int emp5Wed2 = 12;
            int emp5Thu1 = 1;
            int emp5Thu2 = 12;
            int emp5Fri1 = 1;
            int emp5Fri2 = 12;
            int emp5Sat1 = 7;
            int emp5Sat2 = 24;

            int maxShift = 10;
            int maxBreak = 1;

            //Make openHours array reflect input open hours variables. 
            for (int i = 0; i< openHours[0].Length; i++)
            {
                if (i >= (openSun - 1) && i <= closeSun - 1)
                    openHours[0][i] = 1;
                if (i >= (openMon - 1) && i <= closeMon - 1)
                    openHours[1][i] = 1;
                if (i >= (openTue - 1) && i <= closeTue - 1)
                    openHours[2][i] = 1;
                if (i >= (openWed - 1) && i <= closeWed - 1)
                    openHours[3][i] = 1;
                if (i >= (openThu - 1) && i <= closeThu)
                    openHours[4][i] = 1;
                if (i >= (openFri - 1) && i <= closeFri)
                    openHours[5][i] = 1;
                if (i >= (openSat - 1) && i <= closeSat)
                    openHours[6][i] = 1;
            }
            

            // Create availability for employee
            int[][] availability1 = new int[7][];
            for (int i = 0; i < availability1.Length; i++)
            {
                availability1[i] = new int[24];
            }
            int[][] availability2 = new int[7][];
            for (int i = 0; i < availability2.Length; i++)
            {
                availability2[i] = new int[24];
            }
            int[][] availability3 = new int[7][];
            for (int i = 0; i < availability3.Length; i++)
            {
                availability3[i] = new int[24];
            }
            int[][] availability4 = new int[7][];
            for (int i = 0; i < availability4.Length; i++)
            {
                availability4[i] = new int[24];
            }
            int[][] availability5 = new int[7][];
            for (int i = 0; i < availability5.Length; i++)
            {
                availability5[i] = new int[24];
            }

            //Make openHours array reflect input open hours variables. 
            for (int i = 0; i < availability1[0].Length; i++)
            {
                if (i >= (emp1Sun1 - 1) && i <= emp1Sun2 - 1)
                    availability1[0][i] = 1;
                if (i >= (emp1Mon1 - 1) && i <= emp1Mon2 - 1)
                    availability1[1][i] = 1;
                if (i >= (emp1Tue1 - 1) && i <= emp1Tue2 - 1)
                    availability1[2][i] = 1;
                if (i >= (emp1Wed1 - 1) && i <= emp1Wed2 - 1)
                    availability1[3][i] = 1;
                if (i >= (emp1Thu1 - 1) && i <= emp1Thu2)
                    availability1[4][i] = 1;
                if (i >= (emp1Fri1 - 1) && i <= emp1Fri2)
                    availability1[5][i] = 1;
                if (i >= (emp1Sat1 - 1) && i <= emp1Sat2)
                    availability1[6][i] = 1;
            }
            for (int i = 0; i < availability2[0].Length; i++)
            {
                if (i >= (emp3Sun1 - 1) && i <= emp3Sun2 - 1)
                    availability2[0][i] = 1;
                if (i >= (emp3Mon1 - 1) && i <= emp3Mon2 - 1)
                    availability2[1][i] = 1;
                if (i >= (emp3Tue1 - 1) && i <= emp3Tue2 - 1)
                    availability2[2][i] = 1;
                if (i >= (emp3Wed1 - 1) && i <= emp3Wed2 - 1)
                    availability2[3][i] = 1;
                if (i >= (emp3Thu1 - 1) && i <= emp3Thu2)
                    availability2[4][i] = 1;
                if (i >= (emp3Fri1 - 1) && i <= emp3Fri2)
                    availability2[5][i] = 1;
                if (i >= (emp3Sat1 - 1) && i <= emp3Sat2)
                    availability2[6][i] = 1;
            }
            for (int i = 0; i < availability3[0].Length; i++)
            {
                if (i >= (emp5Sun1 - 1) && i <= emp5Sun2 - 1)
                    availability3[0][i] = 1;
                if (i >= (emp5Mon1 - 1) && i <= emp5Mon2 - 1)
                    availability3[1][i] = 1;
                if (i >= (emp5Tue1 - 1) && i <= emp5Tue2 - 1)
                    availability3[2][i] = 1;
                if (i >= (emp5Wed1 - 1) && i <= emp5Wed2 - 1)
                    availability3[3][i] = 1;
                if (i >= (emp5Thu1 - 1) && i <= emp5Thu2)
                    availability3[4][i] = 1;
                if (i >= (emp5Fri1 - 1) && i <= emp5Fri2)
                    availability3[5][i] = 1;
                if (i >= (emp5Sat1 - 1) && i <= emp5Sat2)
                    availability3[6][i] = 1;
            }
            for (int i = 0; i < availability4[0].Length; i++)
            {
                if (i >= (15) && i <= 25)
                    availability4[0][i] = 1;
                if (i >= (18) && i <= 25)
                    availability4[1][i] = 1;
                if (i >= (18) && i <= 25)
                    availability4[2][i] = 1;
                if (i >= (18) && i <= 25)
                    availability4[3][i] = 1;
                if (i >= (0) && i <= 0)
                    availability4[4][i] = 1;
                if (i >= (16) && i <= 24)
                    availability4[5][i] = 1;
                if (i >= (0) && i <= 0)
                    availability4[6][i] = 1;
            }
            for (int i = 0; i < availability5[0].Length; i++)
            {
                if (i >= (11) && i <= 24)
                    availability5[0][i] = 1;
                if (i >= (10) && i <= 16)
                    availability5[1][i] = 1;
                if (i >= (16) && i <= 20)
                    availability5[2][i] = 1;
                if (i >= (10) && i <= 18)
                    availability5[3][i] = 1;
                if (i >= (6) && i <= 24)
                    availability5[4][i] = 1;
                if (i >= (6) && i <= 24)
                    availability5[5][i] = 1;
                if (i >= (0) && i <= 24)
                    availability5[6][i] = 1;
            }

            int employeeCount = 0;
            Employee zachadams = new Employee("Zach Adams", 7, availability3, false, employeeCount);
            Employee nichadams = new Employee("Nich Adams", 7, availability1, false, employeeCount);
            Employee remibarron = new Employee("Remi Barron", 7, availability3, false, employeeCount);
            Employee scottbigler = new Employee("Scott Bigler", 14, availability2, false, employeeCount);
            Employee jakebarton = new Employee("Jake Barton", 7, availability1, false, employeeCount);
            Employee ryanegan = new Employee("Ryan Egan", 7, availability4, false, employeeCount);
            Employee garylowe = new Employee("Gary Lowe", 7, availability2, false, employeeCount);
            Employee loganfrerer = new Employee("Logan Frerer", 7, availability5, false, employeeCount);
            Employee lexibelle = new Employee("Lexi Belle", 7, availability2, false, employeeCount);
            Employee peterwallace = new Employee("Peter Wallace", 14, availability1, false, employeeCount);
            employeeCount++;
            employeeList.Add(zachadams);
            employeeList.Add(nichadams);
            employeeList.Add(remibarron);
            employeeList.Add(scottbigler);
            employeeList.Add(jakebarton);
            employeeList.Add(ryanegan);
            employeeList.Add(peterwallace);
            employeeList.Add(garylowe);
            employeeList.Add(loganfrerer);
            employeeList.Add(lexibelle);


            int zach = zachadams.getBlocks();
            int scott = scottbigler.getBlocks();


              
            Schedule schedule1 = new Schedule(openHours, maxShift, maxBreak, employeeList);

            ScheduleGreed scheduleGreed1 = new ScheduleGreed(schedule1);
            Console.Out.WriteLine(scheduleGreed1.makeSchedule(0, 0));

            //ScheduleMaker scheduleMaker1 = new ScheduleMaker(schedule1, tw);
            
            //scheduleMaker1.makeSchedule(0, 0);

            //tw.Write(scheduleMaker1.makeSchedule(0, 22));
            //Console.Out.WriteLine(scheduleMaker1.makeSchedule(0, 23));

            //tw.Close();

            while(true)
            {
            }
            
        }
    }
}
