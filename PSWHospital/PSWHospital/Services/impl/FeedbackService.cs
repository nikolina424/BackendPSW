using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using PSWHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Services.impl
{

    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
        }
        public void AddFeedback(FeedbackRequest feedbackRequest)
        {
            _feedbackRepository.AddFeedback(feedbackRequest);
        }

        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            return await _feedbackRepository.DeleteFeedback(id);
        }

        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            return await _feedbackRepository.GetFeedback(id);
        }

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await _feedbackRepository.GetFeedbacksAsync();
        }

        public bool ShowHide(ShowRequest showRequest)
        {
            return _feedbackRepository.ShowHide(showRequest);
        }
    }
}
