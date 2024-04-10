using DocumentFormat.OpenXml.Wordprocessing;
using kolomentor.Data.Base;
using kolomentor.Data.ViewModel;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data.Services
{

    public class MenteeService : EntityBaseRepository<Mentee>, IMenteeService
    {
        private readonly AppDbContext _appDbcontext;
        public MenteeService(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public async Task AddNewMenteeAsync(NewMenteeVM data)
        {
            var newMentee = new Mentee()
            {
                FullName = data.FullName,
                Email = data.Email,
                Gender = data.Gender,
                EducationLevel = data.EducationLevel,
                CareerId = data.CareerId,
                ExecutiveSummary = data.ExecutiveSummary,
                MentorId = data.MentorId,

            };
            await _appDbcontext.Mentees.AddAsync(newMentee);
            await _appDbcontext.SaveChangesAsync();
        }

        public async Task<DropDownMentorandCareer> GetMentorandCareerDropDownValues()
        {
            var response = new DropDownMentorandCareer()

            {
                Mentors = await _appDbcontext.Mentors.OrderBy(n => n.FullName).ToListAsync(),
                Careers = await _appDbcontext.Careers.OrderBy(n => n.Category).ToListAsync(),

            };

            return response;

        }

        public async Task<Mentee> GetMenteeByIdAsync(int Id)
        {
            // Retrieve the Mentee with its attached Mentor
            var menteeWithMentor = await _appDbcontext.Mentees
                .Include(m => m.Mentor).ThenInclude(m => m.Skills).ThenInclude(st => st.SkillTypes).ThenInclude(stt => stt.SkillTypeTopics)
                .FirstOrDefaultAsync(n => n.Id == Id);
            return menteeWithMentor;
        }

        public async Task<Mentee> GetMenteeByEmailAsync(string Email)
        {
            var user = await _appDbcontext.Mentees
                .Include(m => m.Mentor).ThenInclude(m => m.Skills).ThenInclude(st => st.SkillTypes).ThenInclude(stt => stt.SkillTypeTopics)
                .FirstOrDefaultAsync(n => n.Email == Email);
            return user;
        }

    }
}
