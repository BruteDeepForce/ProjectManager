using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MachineLearning
{
    public class EmployeeData
    {
        [LoadColumn(1)]
        [ColumnName("CompletedProjects")]
        public float CompletedProjects { get; set; }

        [LoadColumn(2)]
        [ColumnName("CurrentWorkload")]
        public float CurrentWorkload { get; set; }

        [LoadColumn(3)]
        [ColumnName("TimeDifference")]
        public float TimeDifference { get; set; }

        [LoadColumn(4)]
        [ColumnName("Label")] // Bu satır önemli! label predict
         public float PerformanceRating { get; set; }
    }
}