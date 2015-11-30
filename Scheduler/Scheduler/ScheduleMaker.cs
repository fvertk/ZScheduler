using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facet.Combinatorics;

namespace Scheduler
{
    class ScheduleMaker
    {
        List<String> scheduleStrings;
        String scheduleSegString;

        public int scheduleCount;
        public Schedule schedule;
        List<miniSchedule> miniSchedules;

        TextWriter tw;


        // Constructor for ScheduleMaker, simply takes in a schedule
        public ScheduleMaker(Schedule Pschedule, TextWriter Ptw)
        {
            miniSchedules = new List<miniSchedule>();

            schedule = Pschedule;
            scheduleStrings = new List<String>();
            scheduleSegString = "";

            //Bring in text writer from main class.
            tw = Ptw;
        }

        // Modifier for ScheduleMaker, runs the changes to the schedule recursively.
        // Initial hour of each schedule
        public String makeSchedule(int day, int hour)
        {
            List<Employee> avEmps = schedule.whoIsAvailable(day, hour);
            List<IList<Employee>>combinations = new List<IList<Employee>>();

            miniSchedule mini = new miniSchedule();
            miniSchedules.Add(mini);

            Combinations<Employee> empComb = new Combinations<Employee>(avEmps, 3);
            
            foreach (IList<Employee> emp in empComb)
            {
                combinations.Add(emp);
            }

            // If there are no combinations for this hour, but it's also an open hour, then the schedule FAILS!
            if (combinations.Count == 0)
            {

            }   
            
            foreach (IList<Employee> lineup in combinations)
            {
                schedule.finalSchedule[day][hour] = new List<Employee>();
                scheduleSegString = "Schedule " + scheduleCount + ":\r\n" + (hour + 1) + ":00 - ";
                scheduleCount++;

                for (int i = 0; i < lineup.Count; i++)
                {
                    Employee newEmp = lineup.ElementAt<Employee>(i);
                    schedule.finalSchedule[day][hour].Add(newEmp);
                    
                    if (newEmp.hoursWorkedToday == 0)
                    {
                        newEmp.isWorking = true;
                        newEmp.hoursWorkedToday = 1;
                        newEmp.hoursAvTotal -= 1; 
                    }
                    else
                    {
                        newEmp.hoursWorkedToday++;
                    }
                    
                    scheduleSegString += newEmp.name + " \r\n";
                }

                if ((hour + 1) < 24)
                {
                    scheduleSegString += "\r\n" + makeSchedule(day, hour + 1, scheduleSegString);
                }
                else
                {
                    scheduleSegString += "\r\n";
                }
                /*
                else if ((day + 1) < 7)
                {
                    schedule.empDayFlush();
                    hour = 0;
                    scheduleSegString += "\n\n";

                    if ((day + 1) == 0)
                    {
                        scheduleSegString += "\n\n Sunday: ";
                    }
                    if ((day + 1) == 1)
                    {
                        scheduleSegString += "\n\n Monday: ";
                    }
                    if ((day + 1) == 2)
                    {
                        scheduleSegString += "\n\n Tuesday: ";
                    }
                    if ((day + 1) == 3)
                    {
                        scheduleSegString += "\n\n Wednesday: ";
                    }
                    if ((day + 1) == 4)
                    {
                        scheduleSegString += "\n\n Thursday: ";
                    }
                    if ((day + 1) == 5)
                    {
                        scheduleSegString += "\n\n Friday: ";
                    }
                    if ((day + 1) == 6)
                    {
                        scheduleSegString += "\n\n Saturday: ";
                    }
                    scheduleSegString += "\n\n";
                    scheduleSegString += makeSchedule(day + 1, hour);
                }
                  */
                tw.Write(scheduleSegString);
                //Console.Out.WriteLine(scheduleSegString);
                
            }

            //scheduleStrings.Add(scheduleSegString);
            //Console.Out.WriteLine(scheduleSegString);
            return scheduleSegString;
        }

        // Modifier for ScheduleMaker, runs the changes to the schedule recursively. This one is called for all except the first hour.
        // Passes a scheduleString into a local string, so each call has its own individual schedule string. 
        public String makeSchedule(int day, int hour, String scheduleString)
        {

            List<Employee> avEmps = schedule.whoIsAvailable(day, hour);
            List<IList<Employee>> combinations = new List<IList<Employee>>();

            String funlocString = scheduleString;

            Combinations<Employee> empComb = new Combinations<Employee>(avEmps, 3);

            foreach (IList<Employee> emp in empComb)
            {
                combinations.Add(emp);
            }


            foreach (IList<Employee> lineup in combinations)
            {
                schedule.finalSchedule[day][hour] = new List<Employee>();
                String localscheduleString = scheduleString;
                localscheduleString += "\r\n" + (hour + 1) + ":00 - ";

                for (int i = 0; i < lineup.Count; i++)
                {
                    Employee newEmp = lineup.ElementAt<Employee>(i);
                    schedule.finalSchedule[day][hour].Add(newEmp);

                    if (newEmp.hoursWorkedToday == 0)
                    {
                        newEmp.isWorking = true;
                        newEmp.hoursWorkedToday = 1;
                        newEmp.hoursAvTotal -= 1;
                    }
                    else
                    {
                        newEmp.hoursWorkedToday++;
                    }

                    localscheduleString += newEmp.name + " \r\n";
                }

                if ((hour + 1) < 24)
                {
                    localscheduleString += "\r\n" + makeSchedule(day, hour + 1, localscheduleString);
                }
                else
                {
                    scheduleSegString += "\r\n\r\n";
                }
                /*
                else if ((day + 1) < 7)
                {
                    schedule.empDayFlush();
                    hour = 0;
                    scheduleSegString += "\n\n";

                    if ((day + 1) == 0)
                    {
                        scheduleSegString += "\n\n Sunday: ";
                    }
                    if ((day + 1) == 1)
                    {
                        scheduleSegString += "\n\n Monday: ";
                    }
                    if ((day + 1) == 2)
                    {
                        scheduleSegString += "\n\n Tuesday: ";
                    }
                    if ((day + 1) == 3)
                    {
                        scheduleSegString += "\n\n Wednesday: ";
                    }
                    if ((day + 1) == 4)
                    {
                        scheduleSegString += "\n\n Thursday: ";
                    }
                    if ((day + 1) == 5)
                    {
                        scheduleSegString += "\n\n Friday: ";
                    }
                    if ((day + 1) == 6)
                    {
                        scheduleSegString += "\n\n Saturday: ";
                    }
                    scheduleSegString += "\n\n";
                    scheduleSegString += makeSchedule(day + 1, hour);
                }
                  */
                tw.Write(localscheduleString);
                //Console.Out.WriteLine(localscheduleString);
                //funlocString = localscheduleString;

            }

            //scheduleStrings.Add(scheduleSegString);
            //Console.Out.WriteLine(scheduleSegString);
            return funlocString;
        }
    }
}
