using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PSWHospital.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            using var hmac = new HMACSHA512();
            modelBuilder.Entity<Patient>()
                .HasData(new Patient { Id = 1, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), IdGeneralPractitioner = 5, PasswordSalt = hmac.Key, UserName = "patient1@gmail.com", UserType = Models.User.UserTypes.PATIENT, FirstName = "Marina", LastName = "Ivankovic", IsDeleted = false, CanceledExamination = 3 },
                         new Patient { Id = 2, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), IdGeneralPractitioner = 6, PasswordSalt = hmac.Key, UserName = "patient2@gmail.com", UserType = Models.User.UserTypes.PATIENT, FirstName = "Marko", LastName = "Markovic", IsDeleted = false, CanceledExamination = 4 },
                         new Patient { Id = 3, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), IdGeneralPractitioner = 7, PasswordSalt = hmac.Key, UserName = "patient3@gmail.com", UserType = Models.User.UserTypes.PATIENT, FirstName = "Ivan", LastName = "Ivanic", IsDeleted = false, CanceledExamination = 0 },
                         new Patient { Id = 4, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), IdGeneralPractitioner = 8, PasswordSalt = hmac.Key, UserName = "patient4@gmail.com", UserType = Models.User.UserTypes.PATIENT, FirstName = "Jovan", LastName = "Jovanic", IsDeleted = false, CanceledExamination = 0 }
                );

            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor { Id = 5, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "generalpractitioner1@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Dusan", LastName = "Sisarica", DoctorType = Doctor.DoctorTypes.GENERAL_PRACTITIONER },
                    new Doctor { Id = 6, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "generalpractitioner2@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Dajana", LastName = "Erceg", DoctorType = Doctor.DoctorTypes.GENERAL_PRACTITIONER },
                    new Doctor { Id = 7, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "generalpractitioner3@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Zorana", LastName = "Vlaskalic", DoctorType = Doctor.DoctorTypes.GENERAL_PRACTITIONER },
                    new Doctor { Id = 8, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "generalpractitioner4@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Stefan", LastName = "Simic", DoctorType = Doctor.DoctorTypes.GENERAL_PRACTITIONER },
                    new Doctor { Id = 9, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "generalpractitioner5@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Uros", LastName = "Popovic", DoctorType = Doctor.DoctorTypes.GENERAL_PRACTITIONER },
                    new Doctor { Id = 10, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "neurologist1@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Jovan", LastName = "Jenjic", DoctorType = Doctor.DoctorTypes.NEUROLOGIST },
                    new Doctor { Id = 11, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "neurologist2@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Jana", LastName = "Tatalovic", DoctorType = Doctor.DoctorTypes.NEUROLOGIST },
                    new Doctor { Id = 12, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "neurologist3@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Nikola", LastName = "Petrovic", DoctorType = Doctor.DoctorTypes.NEUROLOGIST },
                    new Doctor { Id = 13, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "neurologist4@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Stefan", LastName = "Stupar", DoctorType = Doctor.DoctorTypes.NEUROLOGIST },
                    new Doctor { Id = 14, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "dermatologist1@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Marija", LastName = "Jovanic", DoctorType = Doctor.DoctorTypes.DERMATOLOGIST },
                    new Doctor { Id = 15, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "dermatologist2@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Teodora", LastName = "Milic", DoctorType = Doctor.DoctorTypes.DERMATOLOGIST },
                    new Doctor { Id = 16, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "dermatologist3@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Anastasja", LastName = "Rinic", DoctorType = Doctor.DoctorTypes.DERMATOLOGIST },
                    new Doctor { Id = 17, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "dermatologist4@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Zoran", LastName = "Kosic", DoctorType = Doctor.DoctorTypes.DERMATOLOGIST },
                    new Doctor { Id = 18, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "dermatologist5@gmail.com", UserType = User.UserTypes.DOCTOR, FirstName = "Ognjen", LastName = "Markovic", DoctorType = Doctor.DoctorTypes.DERMATOLOGIST }
                );

            modelBuilder.Entity<Admin>()
                .HasData(
                    new Admin { Id = 19, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")), PasswordSalt = hmac.Key, UserName = "admin@gmail.com", UserType = User.UserTypes.ADMIN, FirstName = "Nikolina", LastName = "Ivankovic" }
                );
            modelBuilder.Entity<Feedback>().HasData(
               new Feedback { Id = 1, FeedbackContent = "I love your website!", ShowOnFront = true, UsersFirstName = "Dusan", UsersLastName = "Sisarica", PatientId = 2 },
               new Feedback { Id = 2, FeedbackContent = "My favourite doctor is Jovana Nikolic!", ShowOnFront = true, PatientId = 1, UsersFirstName = "Marina", UsersLastName = "Ivankovic" }
               );
        }

    }
}
