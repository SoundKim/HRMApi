using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServiceAsync feedbackServiceAsync;

        public FeedbackController(IFeedbackServiceAsync _feedbackServiceAsync)
        {
            feedbackServiceAsync = _feedbackServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await feedbackServiceAsync.AddFeedbackAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await feedbackServiceAsync.GetAllFeedbacksAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await feedbackServiceAsync.GetFeedbackByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This feedback doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await feedbackServiceAsync.GetFeedbackByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This feedback doesn't exist!");
            }

            await feedbackServiceAsync.DeleteFeedbackAsync(id);
            return Ok("Deleted");
        }

    }
}
