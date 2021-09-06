using Microsoft.AspNetCore.Mvc;
using Moq;
using PSWHospital.Models;
using PSWHospital.Repositories;
using PSWHospital.Services.impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests
{
    public class FeedbackTests
    {
        [Fact]
        public async Task GetFeedbackSuccessfully()
        {
            var feedbackRepository = new Mock<IFeedbackRepository>();
            var feedback = new Feedback() { FeedbackContent = "content" };

            feedbackRepository.Setup(f => f.GetFeedback(0)).ReturnsAsync(feedback);

            FeedbackService feedbackService = new FeedbackService(feedbackRepository.Object);

            ActionResult<Feedback> f = await feedbackService.GetFeedback(0);
            Assert.NotNull(f);

        }


        [Fact]
        public async Task GetFeedbackNull()
        {
            var feedbackRepository = new Mock<IFeedbackRepository>();
            var feedback = new Feedback() { FeedbackContent = "content" };

            feedbackRepository.Setup(f => f.GetFeedback(0)).ReturnsAsync(feedback);

            FeedbackService feedbackService = new FeedbackService(feedbackRepository.Object);

            ActionResult<Feedback> f = await feedbackService.GetFeedback(1);
            Assert.Null(f);

        }
    }
}
