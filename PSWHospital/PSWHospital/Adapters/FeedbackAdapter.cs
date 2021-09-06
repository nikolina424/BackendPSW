using PSWHospital.DTOs.Requests;
using PSWHospital.Models;

namespace PSWHospital.Adapters
{
    public class FeedbackAdapter
    {
        public static Feedback FeedbackDtoToFeedback(FeedbackRequest feedbackRequest, Patient patient)
        {
            Feedback feedback = new Feedback();
            feedback.FeedbackContent = feedbackRequest.FeedbackContent;
            feedback.ShowOnFront = feedbackRequest.ShowOnFront;
            feedback.Patient = patient;
            feedback.PatientId = patient.Id;
            feedback.UsersFirstName = patient.FirstName;
            feedback.UsersLastName = patient.LastName;
            return feedback;
        }

        public static FeedbackRequest FeedbackToFeedbackDto(Feedback feedback)
        {
            FeedbackRequest feedbackRequest = new FeedbackRequest();
            feedbackRequest.FeedbackContent = feedback.FeedbackContent;
            feedbackRequest.ShowOnFront = feedback.ShowOnFront;
            feedbackRequest.PatientId = feedback.PatientId;
            feedbackRequest.UsersFirstName = feedback.UsersFirstName;
            feedbackRequest.UsersLastName = feedback.UsersLastName;
            return feedbackRequest;
        }

        public static FeedbackRequest Show(Feedback feedback)
        {
            FeedbackRequest feedbackRequest = new FeedbackRequest();
            feedbackRequest.FeedbackContent = feedback.FeedbackContent;
            feedbackRequest.ShowOnFront = feedback.ShowOnFront;
            feedbackRequest.PatientId = feedback.PatientId;
            feedbackRequest.UsersFirstName = feedback.UsersFirstName;
            feedbackRequest.UsersLastName = feedback.UsersLastName;
            return feedbackRequest;
        }




    }
}
