using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Subutai.Repository.SqlRepository.Contexts;
using MachineLearning;
using Subutai.Domain.Model;



namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIMachineController : ControllerBase
    {
        private readonly SubutaiContext _subutaiContext;

        public AIMachineController(SubutaiContext subutaiContext)
        {
            _subutaiContext = subutaiContext;
        }
        [HttpGet("train")]
        public async Task<IActionResult> Train()
        {
            ModelTraining.TrainModel(_subutaiContext);
            await _subutaiContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("predict")]
        public async Task<IActionResult> Predict(UserEntity userEntity)
        {
            var user =_subutaiContext.Users.FirstOrDefault(x=>x.Id == userEntity.Id);

            var response = MLModelPredictor.PredictPerformance(_subutaiContext);

            user!.PerformanceRating = response;
            await _subutaiContext.SaveChangesAsync();
            return Ok(response);

        }

    }
}