using DocumentFormat.OpenXml.InkML;
using kolomentor.Data.Base;
using kolomentor.Data.ViewModel;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace kolomentor.Data.Services 
{
    public class MentorService : EntityBaseRepository<Mentor>, IMentorService
    {
        private readonly AppDbContext _appDbcontext;

        public MentorService( AppDbContext appDbcontext) : base(appDbcontext) {
            _appDbcontext = appDbcontext;
        }

        public async Task AddNewMentorAsync(NewMentorVM data)
        {
            var newMentor = new Mentor()
            {
                FullName = data.FullName,
                Email = data.Email,
                Gender = data.Gender,
                JobTitle = data.JobTitle,
                ExecutiveSummary = data.ExecutiveSummary,
                PlaceOfWork = data.PlaceOfWork,
                CareerId = data.CareerId,
                
            };
            await _appDbcontext.Mentors.AddAsync(newMentor);
           await _appDbcontext.SaveChangesAsync();
        }

        public async Task<Mentor> GetAllMentorAsync()
        {
            var mentorDetails = await _appDbcontext.Mentors
                .Include(g => g.Guests)
                .Include(m => m.Mentees)
                .Include(s => s.Skills).ThenInclude(st => st.SkillTypes).ThenInclude(stt => stt.SkillTypeTopics)
                .Include(c => c.Career)
                .Include(mm => mm.Mentors_Materials).ThenInclude(m => m.Material)
                .FirstOrDefaultAsync();
            return mentorDetails;
        }

        public async Task<DropDownCareer> GetCareerDropDownValues()
        {
            var response = new DropDownCareer();
            
            response.Careers = await _appDbcontext.Careers.OrderBy(n => n.Category).ToListAsync(); 
            return response;
        }

        public async Task<Mentor> GetMentorByIdAsync(int Id)
        {
            var mentorDetails = await _appDbcontext.Mentors
                .Include(g => g.Guests)
                .Include(m => m.Mentees)
                .Include(s => s.Skills).ThenInclude(st => st.SkillTypes).ThenInclude(stt => stt.SkillTypeTopics)
                .Include(c => c.Career)
                .Include(mm => mm.Mentors_Materials).ThenInclude(m => m.Material)
                .FirstOrDefaultAsync(n => n.Id == Id);
            return mentorDetails;
        }


        public async Task UpdateMentorAsync(NewMentorVM data)
        {
            var dbMentor = await _appDbcontext.Mentors.FirstOrDefaultAsync(n =>n.Id == data.Id);
            
            if (dbMentor != null)
            {
                dbMentor.FullName = data.FullName;
                dbMentor.Email = data.Email;
                dbMentor.Gender = data.Gender;
                dbMentor.JobTitle = data.JobTitle;
                dbMentor.ExecutiveSummary = data.ExecutiveSummary;
                dbMentor.PlaceOfWork = data.PlaceOfWork;
                dbMentor.CareerId = data.CareerId;
                await _appDbcontext.SaveChangesAsync();
            }
            
        }
    }
}
