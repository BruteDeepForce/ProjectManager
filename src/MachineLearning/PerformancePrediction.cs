using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MachineLearning
{
    public class PerformancePrediction
    {
        [ColumnName("Score")] // Tahmin edilen değer
        public float PerformanceRating { get; set; }
    }
}