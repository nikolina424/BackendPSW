using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSWHospital.Adapters;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories.impl
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly MyDbContext dbContext;

        public FeedbackRepository(MyDbContext context)
        {
            this.dbContext = context;

        }
        public void AddFeedback(FeedbackRequest feedbackRequest)
        {
            Patient patient = dbContext.Patients.SingleOrDefault(patient => patient.Id == feedbackRequest.PatientId);
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(feedbackRequest, patient);
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
        }

        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            var feedback = await dbContext.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            dbContext.Feedbacks.Remove(feedback);
            await dbContext.SaveChangesAsync();

            return feedback;
        }

        private ActionResult<Feedback> NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            return await dbContext.Feedbacks.FindAsync(id);
        }

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await dbContext.Feedbacks.ToListAsync();
        }

        public bool ShowHide(ShowRequest showRequest)
        {
            if (showRequest.Id <= 0)
            {
                return false;
            }
            Feedback feedback = dbContext.Feedbacks.SingleOrDefault(feedback => feedback.Id == showRequest.Id);
            if (feedback == null)
            {
                return false;
            }
            else
            {
                feedback.ShowOnFront = showRequest.ShowOnFront;
                dbContext.SaveChanges();
                FeedbackAdapter.FeedbackToFeedbackDto(feedback);
                return true;
            }
        }
    }
}
