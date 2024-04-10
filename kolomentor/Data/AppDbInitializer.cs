using kolomentor.Data.Enums;
using kolomentor.Data.Static;
using kolomentor.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Resources;

namespace kolomentor.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Career Data
                if (!context.Careers.Any())
                {
                    context.Careers.AddRange(new List<Career>()
                    {
                        
                        new Career()
                        {   MentorId = 3,
                            Category = "Administration",
                            Description = "Description for Administration Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                        },

                        new Career()
                        {   MentorId = 1,
                            Category = "Management",
                            Description = "Description for Management Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                        },

                        new Career()
                        {   MentorId = 2,
                            Category = "Network",
                            Description = "Description for Network Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                        },


                        new Career()
                        {   MentorId = 4,
                            Category = "Technical Support",
                            Description = "Description for Technical Support Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                        }

                    });
                    context.SaveChanges();

                }
                //Materials
                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(new List<Material>()
                    {
                        new Material()
                        {
                            Video = "video resource 1",
                            Pdf = "PDF Resource 1",
                            Images ="Image Resource 1",
                            Other = "other Resource 1"

                        },

                        new Material()
                        {
                            Video = "video resource 2",
                            Pdf = "PDF Resource 2",
                            Images ="Image Resource 2",
                            Other = "other Resource 2"
                        },

                        new Material()
                        {
                            Video = "video resource 3",
                            Pdf = "PDF Resource 3",
                            Images ="Image Resource 3",
                            Other = "other Resource 3"
                        },

                        new Material()
                        {
                            Video = "video resource 4",
                            Pdf = "PDF Resource 4",
                            Images ="Image Resource 4",
                            Other = "other Resource 4"
                        }

                    });
                    context.SaveChanges();

                }

                //Mentor
                if (!context.Mentors.Any())
                {
                    context.Mentors.AddRange(new List<Mentor>()
                    {
                        new Mentor()
                        {
                            FullName = "Gabriel Kingston",
                            Email = "gabriel@google.com",
                            Gender = Gender.Male,
                            JobTitle = "AI OPs Engineer",
                            ExecutiveSummary = "Hello, I'm an AIOps Engineer, specializing in leveraging AI and automation to enhance operational efficiency. My focus is on optimizing IT processes and ensuring seamless, proactive monitoring and management.",
                            PlaceOfWork = "Google",
                            CareerId = 1,
                            Career =  new Career()
                            {
                                Category = "Software",
                                Description = "Description for Security Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                            },
                            
                        },

                        new Mentor()
                        {
                            FullName = "Jonathan Paulina",
                            Email = "Jona@paulina.com",
                            Gender = Gender.Female,
                            JobTitle = "Data Scientist",
                            ExecutiveSummary = "Data scientist skilled in extracting meaningful insights from complex datasets. Experienced in machine learning, statistical analysis, and transforming data into actionable solutions.",
                            PlaceOfWork = "TATA",
                            CareerId = 2,
                            Career =  new Career()
                            {
                                Category = "Hardware",
                                Description = "Description for Security Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                            }

                        },

                        new Mentor()
                        {
                            FullName = "Patience Mary",
                            Email = "mary@pat.com",
                            Gender = Gender.Female,
                            JobTitle = "UI/UX Designer",
                            ExecutiveSummary = "As a seasoned Data Scientist, my expertise lies in unlocking insights from intricate datasets. I thrive on transforming raw data into actionable solutions through advanced machine learning and statistical analysis.",
                            PlaceOfWork = "Microsoft",
                            CareerId = 3,
                            Career =  new Career()
                            {
                                Category = "Data",
                                Description = "Description for Security Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                            }
                        },

                        new Mentor()
                        {
                            FullName = "Nkem Balogun",
                            Email = "nkbalo@balo.com",
                            Gender = Gender.Male,
                            JobTitle = "Solution Architect",
                            ExecutiveSummary = "I am a Solution Architect specializing in designing robust and scalable solutions. With a keen understanding of technology and business needs, I create architecture that aligns with organizational goals and drives success.",
                            PlaceOfWork = "Microsoft",
                            CareerId = 4,
                            Career =  new Career()
                            {
                                Category = "Cloud",
                                Description = "Description for Security Career. This is required to be displayed to the Mentee Upon registration. I have decided to include this as I imagined that it would help Mentees to decide",
                            }
                        }

                    });

                    context.SaveChanges();

                }
                //Mentee
                if (!context.Mentees.Any())
                {

                    context.Mentees.AddRange(new List<Mentee>()
                    {
                        new Mentee()
                        {
                            FullName = "Mentee 1",
                            Email = "mentee1@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 1 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 1,
                            CareerId = 2
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 2",
                            Email = "mentee2@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 2 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 2,
                            CareerId = 3
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 3",
                            Email = "mentee3@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 3 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Post_Graduate,
                            MentorId = 4,
                            CareerId = 2
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 4",
                            Email = "mentee4@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 4 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Diploma,
                            MentorId = 3,
                            CareerId = 4
                        },
                        new Mentee()
                        {
                            FullName = "Mentee 5",
                            Email = "mentee5@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 5 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 1,
                            CareerId = 1
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 6",
                            Email = "mentee6@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 6 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 2,
                            CareerId = 3
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 7",
                            Email = "mentee7@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 7 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Post_Graduate,
                            MentorId = 4,
                            CareerId = 4
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 8",
                            Email = "mentee8@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 8 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Diploma,
                            MentorId = 3,
                            CareerId = 3
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 9",
                            Email = "mentee9@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 9 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 1,
                            CareerId = 1
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 10",
                            Email = "mentee10@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 10 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 2,
                            CareerId = 5
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 11",
                            Email = "mentee11@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 11 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Post_Graduate,
                            MentorId = 4,
                            CareerId = 1
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 12",
                            Email = "mentee12@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 12 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Diploma,
                            MentorId = 3,
                            CareerId = 3
                        },
                        new Mentee()
                        {
                            FullName = "Mentee 13",
                            Email = "mentee13@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 13 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 1,
                            CareerId = 5
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 14",
                            Email = "mentee14@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 14 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Graduate,
                            MentorId = 3,
                            CareerId = 6
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 15",
                            Email = "mentee15@gmail.com",
                            Gender = Gender.Male,
                            ExecutiveSummary = "Mentee 15 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Post_Graduate,
                            MentorId = 3,
                            CareerId = 6
                        },

                        new Mentee()
                        {
                            FullName = "Mentee 16",
                            Email = "mentee16@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 16 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.Diploma,
                            MentorId = 3,
                            CareerId = 6
                        },

                         new Mentee()
                        {
                            FullName = "Mentee 17",
                            Email = "mentee17@gmail.com",
                            Gender = Gender.Female,
                            ExecutiveSummary = "Mentee 17 is Here to learn and be mentored",
                            EducationLevel = EducationLevel.No_Formal_Education,
                            MentorId = 3,
                            CareerId = 2
                        }

                    });
                    context.SaveChanges();
                }


                //Mentor and Materials
                if (!context.Mentors_Materials.Any())
                {
                    context.Mentors_Materials.AddRange(new List<Mentor_Material>()
                    {
                        new Mentor_Material()
                        {
                            MentorId = 4,
                            MaterialId = 1
                        },

                        new Mentor_Material()
                        {
                            MentorId = 2,
                            MaterialId = 2
                        },

                        new Mentor_Material()
                        {
                            MentorId = 3,
                            MaterialId = 3
                        },

                        new Mentor_Material()
                        {
                            MentorId = 1,
                            MaterialId = 4
                        }

                    });
                    context.SaveChanges();

                }
                //Guest
                if (!context.Guests.Any())
                {
                    context.Guests.AddRange(new List<Guest>()
                    {
                        new Guest()
                        {
                            Email = "guest1@gmail.com",
                            CareerCategory = "Software",
                            MentorId = 2
                        },

                        new Guest()
                        {
                            Email = "guest2@gmail.com",
                            CareerCategory = "Hardware",
                            MentorId = 4
                        },

                        new Guest()
                        {
                            Email = "guest3@gmail.com",
                            CareerCategory = "Data",
                            MentorId = 1
                        },

                        new Guest()
                        {
                            Email = "guest4@gmail.com",
                            CareerCategory = "Cloud",
                            MentorId = 3
                        }

                    });
                    context.SaveChanges();
                }

                //Skill
                if (!context.Skills.Any())
                {

                    context.Skills.AddRange(new List<Skill>()
                    {
                        new Skill()
                        {
                            Title = "Azure",
                            Description = "Microsoft cloud services",
                            MentorId = 1
                        },

                        new Skill()
                        {
                            Title = "Powershell",
                            Description = "Windows based powerful scripting tool",
                            MentorId = 2
                        },
                        new Skill()
                        {
                            Title = "C Sharp",
                            Description = "Microsoft owned programming language",
                            MentorId = 3
                        },
                        new Skill()
                        {
                            Title = "Devops Engineering",
                            Description = "Bridge of development and operations for fast delivery of software",
                            MentorId = 4
                        },

                    });
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}
