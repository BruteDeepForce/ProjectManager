using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Subutai.Repository.SqlRepository.Contexts;
using MachineLearning;
using Subutai.Domain.Model;
using Microsoft.AspNetCore.Identity;



namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIMachineController : ControllerBase
    {
        private readonly SubutaiContext _subutaiContext;
        private readonly AuthenticationContext _authenticationContext;

        public AIMachineController(SubutaiContext subutaiContext, AuthenticationContext authenticationContext)
        {
            _subutaiContext = subutaiContext;
            _authenticationContext = authenticationContext;
        }
        [HttpGet("train")]
        public async Task<IActionResult> Train()
        {
            ModelTraining.TrainModel(_authenticationContext);
            await _subutaiContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("predict")]
        public async Task<IActionResult> Predict(UserEntity userEntity)
        {
            var user =_authenticationContext.Users.FirstOrDefault(x=>x.Id == userEntity.Id);

            var response = MLModelPredictor.PredictPerformance(_subutaiContext, _authenticationContext);

            user!.PerformanceRating = response;
            await _subutaiContext.SaveChangesAsync();
            return Ok();
        }
    }
}