using DocumentFormat.OpenXml.InkML;
using kolomentor.Data.Base;
using kolomentor.Data.ViewModel;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace kolomentor.Data.Services 
{
    public class MentorshipService : EntityBaseRepository<Mentorship>, IMentorshipService
    {

        public MentorshipService( AppDbContext appDbcontext) : base(appDbcontext) { }


                
    }
}




