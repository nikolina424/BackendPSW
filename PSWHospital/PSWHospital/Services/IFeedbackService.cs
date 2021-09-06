using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Services
{
    public interface IFeedbackService
    {
        Task<ActionResult<Feedback>> DeleteFeedback(int id);
        void AddFeedback(FeedbackRequest feedbackRequest);
        Task<ActionResult<Feedback>> GetFeedback(int id);
        Task<List<Feedback>> GetFeedbacksAsync();
        bool ShowHide(ShowRequest showRequest);
    }
}
