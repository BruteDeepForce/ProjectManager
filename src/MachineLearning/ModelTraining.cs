﻿using Microsoft.ML;
using Microsoft.ML.Data;
using Subutai.Repository.SqlRepository.Contexts;


namespace MachineLearning;

public static class ModelTraining
{
    private static readonly string ModelPath = @"/Users/suleymantuysuzoglu/Downloads/employeePerformanceModel.zip";

    public static string TrainModel(AuthenticationContext authenticationContext)
        {
            var mlContext = new MLContext();

            // Verileri DbContext'ten al ve float'a çevir
            var employeeData = authenticationContext.Users.Where(u => u.CompleteTaskTime.HasValue && u.CurrentWorkload.HasValue)
                .Select(e => new EmployeeData
                {
                    CompletedProjects = e.CompletedProjects.HasValue ? e.CompletedProjects.Value : 0,
                    CurrentWorkload = e.CurrentWorkload.HasValue ? e.CurrentWorkload.Value : 0.0f,
                    PerformanceRating = e.PerformanceRating.HasValue ? e.PerformanceRating.Value : 0.0f,
                    TimeDifference = (float)(e.CompleteTaskTime!.Value-e.ExpectTaskComplete!.Value).TotalDays
                }).ToList();

            // Verileri IDataView formatına dönüştür
            IDataView trainingData = mlContext.Data.LoadFromEnumerable(employeeData);

            // Pipeline oluştur (Özellikleri birleştir + Modeli seç)
            var pipeline = mlContext.Transforms.Concatenate("Features", "TimeDifference", "CompletedProjects", "CurrentWorkload")
                .Append(mlContext.Regression.Trainers.Sdca());

            // Modeli eğit
            Console.WriteLine("Model eğitiliyor...");
            var model = pipeline.Fit(trainingData);

            // Modeli kaydet
            mlContext.Model.Save(model, trainingData.Schema, ModelPath);
            Console.WriteLine($"Model kaydedildi: {ModelPath}");

            return "success";
    }

}
