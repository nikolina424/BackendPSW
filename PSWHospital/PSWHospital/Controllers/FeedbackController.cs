using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using PSWHospital.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;


        public FeedbackController(IFeedbackService feedbackService, MyDbContext context)
        {

            _feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));
        }

      
        [HttpGet]
        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await _feedbackService.GetFeedbacksAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            return await _feedbackService.GetFeedback(id);
        }

        
        [HttpPost]     
        public void AddFeedback(FeedbackRequest feedbackRequest)
        {
            _feedbackService.AddFeedback(feedbackRequest);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            return await _feedbackService.DeleteFeedback(id);
        }

        [HttpPut]       
        public bool ShowHide(ShowRequest showRequest)
        {
            return _feedbackService.ShowHide(showRequest);
        }

    }
}
