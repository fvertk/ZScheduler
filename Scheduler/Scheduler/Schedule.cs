using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class Schedule
    {
        public int[][] openHours;
        public int[][] howManyEmp;
        public int maxShift;
        public int maxBreak;
        public List<Employee> employeeList;
        public List<Employee>[][] finalSchedule;


        public Schedule(int[][] PopenHours, int PmaxShift, int PmaxBreak, List<Employee> PemployeeList)
        {
            openHours = PopenHours;
            maxShift = PmaxShift;
            maxBreak = PmaxBreak;
            employeeList = PemployeeList;

            howManyEmp = new int[7][];
            for (int i = 0; i < howManyEmp.Length; i++)
            {
                howManyEmp[i] = new int[24];
            }

            finalSchedule = new List<Employee>[7][];
            for (int i = 0; i < finalSchedule.Length; i++)
            {
                finalSchedule[i] = new List<Employee>[24];
            }

            for (int i = 0; i < finalSchedule.Length; i++)
            {
                for (int j = 0; j < finalSchedule[i].Length; j++)
                {
                    finalSchedule[i][j] = new List<Employee>();
                }
            }
        }

        //Collects available employees in a list for a certain hour. 
        public List<Employee> whoIsAvailable(int day, int hour)
        {
            List<Employee> avEmps = new List<Employee>();
            foreach (Employee emp in employeeList)
            {
                // If employee is available at this time and he still has time left to work 
                if (emp.availability[day][hour] == 1 && emp.hoursAvTotal != 0)
                {
                    // If employee has worked today AND isn't working, then don't continue. (don't want two shifts in one day)
                    if (!(emp.hasWorkedToday == true && emp.isWorking == false))
                    {
                        // Lastly, we want to make sure that the employee hasn't already worked the max shift possible. 
                        if (emp.hoursWorkedToday <= maxShift)
                        {
                            avEmps.Add(emp);
                        }
                    }
                }

                    
            }
            return avEmps;
        }

        //Collects available employees in a list for a certain day 
        public List<Employee> whoIsAvailableDay(int day)
        {
            List<Employee> avEmps = new List<Employee>();

            foreach (Employee emp in employeeList)
            {
                bool works = false;
                for (int i = 0; i < emp.availability[0].Length; i++)
                {

                    if (emp.availability[day][i] == 1)
                    {
                        works = true;
                    }
                }

                if (works == true)
                {
                    avEmps.Add(emp);
                }
            }

            return avEmps;
        }

        public void empDayFlush()
        {
            foreach (Employee emp in employeeList)
            {
                emp.hoursWorkedToday = 0;
                emp.hasWorkedToday = false;
                emp.isWorking = false;
            }
        }

        // Prints out the schedule.
        public String printSchedule()
        {
            String scheduleToString ="Here is your business schedule: ";
            for (int i=0; i< finalSchedule.Length; i++)
            {
                if (i == 0)
                {
                    scheduleToString += "\n\n Sunday: ";
                }
                if (i == 1)
                {
                    scheduleToString += "\n\n Monday: ";
                }
                if (i == 2)
                {
                    scheduleToString += "\n\n Tuesday: ";
                }
                if (i == 3)
                {
                    scheduleToString += "\n\n Wednesday: ";
                }
                if (i == 4)
                {
                    scheduleToString += "\n\n Thursday: ";
                }
                if (i == 5)
                {
                    scheduleToString += "\n\n Friday: ";
                }
                if (i == 6)
                {
                    scheduleToString += "\n\n Saturday: ";
                }
                for (int j=0; j< finalSchedule[i].Length; j++)
                {
                    scheduleToString += "\n " + (j + 1) + ":00 - ";

                    if (finalSchedule[i][j] != null)
                    {
                        if (finalSchedule[i][j].Count != 0)
                        {
                            foreach (Employee emp in finalSchedule[i][j])
                            {
                                scheduleToString += emp.name + " ";
                            }
                        }
                    }
                }
            }

            return scheduleToString;
        }

    }
}
