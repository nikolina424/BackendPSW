﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWHospital.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Doctor_FirstName = table.Column<string>(nullable: true),
                    Doctor_LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    DoctorType = table.Column<int>(nullable: true),
                    Patient_FirstName = table.Column<string>(nullable: true),
                    Patient_LastName = table.Column<string>(nullable: true),
                    Patient_Address = table.Column<string>(nullable: true),
                    Patient_Town = table.Column<string>(nullable: true),
                    IdGeneralPractitioner = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FeedbackContent = table.Column<string>(nullable: true),
                    ShowOnFront = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    UsersFirstName = table.Column<string>(nullable: true),
                    UsersLastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "PasswordHash", "PasswordSalt", "UserName", "UserType", "FirstName", "LastName" },
                values: new object[] { 19, "Admin", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "admin@gmail.com", 0, "Nikolina", "Ivankovic" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "PasswordHash", "PasswordSalt", "UserName", "UserType", "Patient_Address", "Patient_FirstName", "IdGeneralPractitioner", "IsDeleted", "Patient_LastName", "Patient_Town" },
                values: new object[,]
                {
                    { 2, "Patient", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "patient2@gmail.com", 1, null, "Ivana", 6, false, "Ivanic", null },
                    { 1, "Patient", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "patient1@gmail.com", 1, null, "Jovana", 5, false, "Jovanic", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "PasswordHash", "PasswordSalt", "UserName", "UserType", "Address", "DoctorType", "Doctor_FirstName", "Doctor_LastName", "Town" },
                values: new object[,]
                {
                    { 18, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "dermatologist5@gmail.com", 2, null, 1, "Ognjen", "Markovic", null },
                    { 17, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "dermatologist4@gmail.com", 2, null, 1, "Zoran", "Kosic", null },
                    { 16, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "dermatologist3@gmail.com", 2, null, 1, "Anastasja", "Rinic", null },
                    { 15, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "dermatologist2@gmail.com", 2, null, 1, "Teodora", "Milic", null },
                    { 14, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "dermatologist1@gmail.com", 2, null, 1, "Marija", "Jovanic", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "PasswordHash", "PasswordSalt", "UserName", "UserType", "Patient_Address", "Patient_FirstName", "IdGeneralPractitioner", "IsDeleted", "Patient_LastName", "Patient_Town" },
                values: new object[] { 3, "Patient", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "patient3@gmail.com", 1, null, "Marko", 7, false, "Markovic", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "PasswordHash", "PasswordSalt", "UserName", "UserType", "Address", "DoctorType", "Doctor_FirstName", "Doctor_LastName", "Town" },
                values: new object[,]
                {
                    { 13, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "neurologist4@gmail.com", 2, null, 2, "Stefan", "Stupar", null },
                    { 11, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "neurologist2@gmail.com", 2, null, 2, "Jana", "Tatalovic", null },
                    { 10, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "neurologist1@gmail.com", 2, null, 2, "Jovan", "Jenjic", null },
                    { 9, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "generalpractitioner5@gmail.com", 2, null, 0, "Uros", "Popovic", null },
                    { 8, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "generalpractitioner4@gmail.com", 2, null, 0, "Stefan", "Simic", null },
                    { 7, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "generalpractitioner3@gmail.com", 2, null, 0, "Zorana", "Vlaskalic", null },
                    { 6, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "generalpractitioner2@gmail.com", 2, null, 0, "Dajana", "Erceg", null },
                    { 5, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "generalpractitioner1@gmail.com", 2, null, 0, "Dusan", "Sisarica", null },
                    { 12, "Doctor", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "neurologist3@gmail.com", 2, null, 2, "Nikola", "Petrovic", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "PasswordHash", "PasswordSalt", "UserName", "UserType", "Patient_Address", "Patient_FirstName", "IdGeneralPractitioner", "IsDeleted", "Patient_LastName", "Patient_Town" },
                values: new object[] { 4, "Patient", new byte[] { 36, 209, 129, 114, 166, 117, 155, 65, 47, 36, 234, 227, 213, 70, 93, 124, 167, 193, 135, 79, 4, 55, 87, 111, 108, 109, 72, 145, 41, 248, 115, 130, 111, 84, 13, 211, 139, 44, 171, 113, 110, 180, 252, 157, 59, 69, 193, 37, 118, 82, 117, 113, 152, 245, 108, 6, 126, 138, 3, 229, 162, 89, 34, 246 }, new byte[] { 246, 248, 149, 166, 134, 209, 239, 137, 136, 101, 161, 50, 116, 66, 39, 148, 81, 34, 118, 87, 229, 251, 6, 1, 222, 27, 246, 136, 118, 61, 168, 232, 30, 8, 21, 4, 188, 188, 22, 12, 146, 70, 231, 134, 240, 82, 52, 26, 42, 235, 89, 78, 47, 77, 134, 50, 98, 19, 248, 59, 96, 155, 83, 225, 204, 176, 165, 164, 144, 156, 179, 147, 75, 224, 143, 79, 125, 242, 180, 86, 126, 39, 253, 167, 74, 148, 21, 27, 144, 162, 31, 243, 155, 174, 127, 131, 125, 19, 139, 250, 245, 3, 211, 126, 145, 237, 69, 142, 89, 50, 240, 232, 146, 219, 248, 78, 40, 85, 92, 133, 84, 62, 154, 120, 251, 40, 211, 33 }, "patient4@gmail.com", 1, null, "Stefan", 8, false, "Stefanovic", null });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "FeedbackContent", "PatientId", "ShowOnFront", "UsersFirstName", "UsersLastName" },
                values: new object[] { 2, "My favourite doctor is Jovana Nikolic!", 1, true, "Marina", "Ivankovic" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "FeedbackContent", "PatientId", "ShowOnFront", "UsersFirstName", "UsersLastName" },
                values: new object[] { 1, "I love your website!", 2, true, "Dusan", "Sisarica" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}