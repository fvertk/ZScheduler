using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class miniSchedule
    {
        public bool success = true;
        public List<Employee>[][] schedule;

        public miniSchedule()
        {
            schedule = new List<Employee>[7][];
            for (int i = 0; i < schedule.Length; i++)
            {
                schedule[i] = new List<Employee>[24];
            }
        }

    }
}
