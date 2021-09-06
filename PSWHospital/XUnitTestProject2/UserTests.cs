using Microsoft.AspNetCore.Mvc;
using Moq;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
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
    public class UserTests
    {

        [Fact]
        public async Task GetPatientSuccessfully()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var patient = new Patient() {FirstName = "test", LastName = "test" };

            patientRepository.Setup(r => r.GetPatient(0)).ReturnsAsync(patient);

            PatientService patientService = new PatientService(patientRepository.Object);

            ActionResult<Patient> p = await patientService.GetPatient(0);
            Assert.NotNull(p);

        }

        [Fact]
        public async Task GetPatientNull()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var patient = new Patient() { FirstName = "test", LastName = "test" };

            patientRepository.Setup(r => r.GetPatient(0)).ReturnsAsync(patient);

            PatientService patientService = new PatientService(patientRepository.Object);

            ActionResult<Patient> p = await patientService.GetPatient(1);
            Assert.Null(p);
        }

        [Fact]
        public async Task GetDoctorSuccessfully()
        {
            var doctorRepository = new Mock<IDoctorRepository>();
            var doctor = new Doctor() { FirstName = "test", LastName = "test" };

            doctorRepository.Setup(d => d.GetDoctor(0)).ReturnsAsync(doctor);

            DoctorService doctorService = new DoctorService(doctorRepository.Object);

            ActionResult<Doctor> d = await doctorService.GetDoctor(0);
            Assert.NotNull(d);

        }

        [Fact]
        public async Task GetDoctorNull()
        {
            var doctorRepository = new Mock<IDoctorRepository>();
            var doctor = new Doctor() { FirstName = "test", LastName = "test" };

            doctorRepository.Setup(d => d.GetDoctor(0)).ReturnsAsync(doctor);

            DoctorService doctorService = new DoctorService(doctorRepository.Object);

            ActionResult<Doctor> d = await doctorService.GetDoctor(1);
            Assert.Null(d);
        }

        [Fact]
        public async Task GetAdminSuccessfully()
        {
            var adminRepository = new Mock<IAdminRepository>();
            var admin = new Admin() { FirstName = "test", LastName = "test" };

            adminRepository.Setup(a => a.GetAdmin(0)).ReturnsAsync(admin);

            AdminService adminService = new AdminService(adminRepository.Object);

            ActionResult<Admin> a = await adminService.GetAdmin(0);
            Assert.NotNull(a);

        }

        [Fact]
        public async Task GetAdminNull()
        {
            var adminRepository = new Mock<IAdminRepository>();
            var admin = new Admin() { FirstName = "test", LastName = "test" };

            adminRepository.Setup(a => a.GetAdmin(0)).ReturnsAsync(admin);

            AdminService adminService = new AdminService(adminRepository.Object);

            ActionResult<Admin> a = await adminService.GetAdmin(1);
            Assert.Null(a);
        }

        [Fact]
        public void BlockPatientSuccessfully()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var patient = new Patient() { FirstName = "test", LastName = "test", CanceledExamination = 4 };
            var blockedUserRequest = new BlockedUserRequest()
            {
                Id = 0
            };

            patientRepository.Setup(r => r.Block(blockedUserRequest)).Returns(true);

            PatientService patientService = new PatientService(patientRepository.Object);

            bool p =  patientService.Block(blockedUserRequest);
            Assert.True(p);
        }

        [Fact]
        public void BlockPatientUnsuccessfully()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var patient = new Patient() { FirstName = "test", LastName = "test", CanceledExamination = 4 };
            var blockedUserRequest = new BlockedUserRequest()
            {
                Id = 0
            };
            var blockedUserRequest2 = new BlockedUserRequest()
            {
                Id = 1
            };

            patientRepository.Setup(r => r.Block(blockedUserRequest)).Returns(true);

            PatientService patientService = new PatientService(patientRepository.Object);

            bool p = patientService.Block(blockedUserRequest2);
            Assert.False(p);
        }
    }
}
