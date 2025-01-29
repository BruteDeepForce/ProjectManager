using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MachineLearning
{
    public class EmployeeData
    {
        [LoadColumn(0)]
        [ColumnName("ExperienceYears")]
        public float ExperienceYears { get; set; }

        [LoadColumn(1)]
        [ColumnName("CompletedProjects")]
        public float CompletedProjects { get; set; }

        [LoadColumn(2)]
        [ColumnName("TaskEfficiency")]
        public float TaskEfficiency { get; set; }

        [LoadColumn(3)]
        [ColumnName("CurrentWorkload")]
        public float CurrentWorkload { get; set; }

        [LoadColumn(4), ColumnName("Label")] // Bu satır önemli!
         public float PerformanceRating { get; set; }
    }
}