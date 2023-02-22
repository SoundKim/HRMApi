using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewStatusController : ControllerBase
    {
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;

        public InterviewStatusController(IInterviewStatusServiceAsync _interviewStatusServiceAsync)
        {
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewStatusServiceAsync.AddInterviewStatusAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewStatusServiceAsync.GetAllInterviewStatussAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewStatusServiceAsync.GetInterviewStatusByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This interview status doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await interviewStatusServiceAsync.GetInterviewStatusByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This interview status doesn't exist!");
            }

            await interviewStatusServiceAsync.DeleteInterviewStatusAsync(id);
            return Ok("Deleted");
        }

    }
}
