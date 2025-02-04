using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Repository.SqlRepository.Contexts;
using Microsoft.ML.Data;
using Microsoft.ML;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MachineLearning
{
    public static class MLModelPredictor
    {
        private static readonly string ModelPath = @"/Users/suleymantuysuzoglu/Downloads/employeePerformanceModel.zip";
        static float predict = 0.0f;
        public static float PredictPerformance(SubutaiContext subutaiContext, AuthenticationContext authenticationContext)
        {
             var mlContext = new MLContext();

            // Modeli yükle
            var trainedModel = mlContext.Model.Load(ModelPath, out var modelInputSchema);

            // Tahmin yapacak transformer
            var predictionEngine = mlContext.Model.CreatePredictionEngine<EmployeeData, PerformancePrediction>(trainedModel);

            var strategy = authenticationContext.Database.CreateExecutionStrategy();

           strategy.Execute(() =>
         {
             using (var transaction = authenticationContext.Database.BeginTransaction()) // Transaction başlat
             {
             try
             {
                foreach (var employee in authenticationContext.Users)
                {
                    var employeeInput = new EmployeeData
                    {
                        CompletedProjects = employee.CompletedProjects.HasValue ? employee.CompletedProjects.Value : 0,
                        CurrentWorkload = employee.CurrentWorkload.HasValue ? employee.CurrentWorkload.Value : 0.0f,
                        TimeDifference = (float)(employee.CompleteTaskTime!.Value-employee.ExpectTaskComplete!.Value).TotalDays
                    };

                    // Performans tahminini al
                    var prediction = predictionEngine.Predict(employeeInput);

                    // Tahmini veritabanına yaz
                    employee.PerformanceRating = prediction.PerformanceRating;
                    predict = prediction.PerformanceRating;
                }

                // Değişiklikleri kaydet ve commit yap
                authenticationContext.SaveChanges();
                transaction.Commit();
              }
              catch (Exception)
               {
                   transaction.Rollback(); // Hata olursa geri al
                throw;
               }
        }
    });

            Console.WriteLine("Performans değerleri veritabanına kaydedildi.");
            

            return predict;
        }
    }
}