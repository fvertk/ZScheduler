using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class ScheduleGreed
    {
    
        public Schedule schedule;

        public ScheduleGreed(Schedule Pschedule)
        {
            schedule = Pschedule;
        }

        public String makeSchedule(int day, int block)
        {

            // Create a list of employees sorted by the size of their availability blocks. 
            // So if they have a large availability, they'll be added to the schedule last
            // and essentially given the worst schedule. X_x

            List<Employee>empDemand = new List<Employee>();
            List<Employee>tempEmp = new List<Employee>();
            
            foreach (Employee e in schedule.employeeList)
            {
                tempEmp.Add(e);
            }
            
            for (int i = 0; i < schedule.employeeList.Count; i++)
            {
                Employee lowest = new Employee();

                int j = 0;
                foreach (Employee e in tempEmp)
                {
                    if (j == 0)
                    {
                        lowest = e;
                    }
                    else if (e.getBlocks() < lowest.getBlocks())
                    {
                        lowest = e;
                        
                    }
                    j++;
                }
                empDemand.Add(lowest);
                tempEmp.Remove(lowest);
            }

            // Now it goes through the sorted empDemand and adds the employees to the schedule where they fit
            // PROVIDED that their max hours isn't met for that day. After the day, the max hours is reset. 
            int countBreak = 0;
            bool startedWork = false;
            bool alreadyWorked = false;
            foreach (Employee e in empDemand)
            {
                for (int i = 0; i < schedule.finalSchedule.Length; i++)
                {
                    for (int j = 0; j < schedule.finalSchedule[i].Length; j++)
                    {
                        if (schedule.openHours[i][j] == 1 && e.availability[i][j] == 1 && schedule.finalSchedule[i][j].Count < 3
                            && e.hoursAvTotal != 0 && alreadyWorked == false)
                        {
                            schedule.finalSchedule[i][j].Add(e);
                            e.hoursAvTotal--;
                            startedWork = true;
                        }
                        else if (startedWork == true)
                        {
                            countBreak++;
                        }
                        if (countBreak > 1)
                        {
                            alreadyWorked = true;
                        }
                    }
                    e.hoursAvTotal = 7;
                    startedWork = false;
                    alreadyWorked = false;
                    countBreak = 0;
                }
            }


            return schedule.printSchedule();
        }
    }
}
