using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Repository.SqlRepository.Contexts;
using Microsoft.ML.Data;
using Microsoft.ML;

namespace MachineLearning
{
    public static class MLModelPredictor
    {
        private static readonly string ModelPath = @"/Users/suleymantuysuzoglu/Downloads/employeePerformanceModel.zip";
        static float predict = 0.0f;
        public static float PredictPerformance(SubutaiContext subutaiContext)
        {
             var mlContext = new MLContext();

            // Modeli yükle
            var trainedModel = mlContext.Model.Load(ModelPath, out var modelInputSchema);

            // Tahmin yapacak transformer
            var predictionEngine = mlContext.Model.CreatePredictionEngine<EmployeeData, PerformancePrediction>(trainedModel);

            // Her çalışan için tahmin yap
            foreach (var employee in subutaiContext.Users)
            {
                var employeeInput = new EmployeeData
                {
                    ExperienceYears = employee.ExperienceYears.HasValue ? employee.ExperienceYears.Value : 0.0f,
                    CompletedProjects = employee.CompletedProjects.HasValue ? employee.CompletedProjects.Value : 0,
                    TaskEfficiency = employee.TaskEfficiency.HasValue ? employee.TaskEfficiency.Value : 0.0f,
                    CurrentWorkload = employee.CurrentWorkload.HasValue ? employee.CurrentWorkload.Value : 0.0f
                };

                // Performans tahminini al
                var prediction = predictionEngine.Predict(employeeInput);

                // Tahmin edilen değeri veritabanına kaydet
                employee.PerformanceRating = prediction.PerformanceRating;
                predict =  prediction.PerformanceRating;
            }

            // Veritabanında değişiklikleri kaydet
            subutaiContext.SaveChangesAsync();
            Console.WriteLine("Performans değerleri veritabanına kaydedildi.");

            return predict;
        }
    }
}