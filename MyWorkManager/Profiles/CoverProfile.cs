using AutoMapper;
using MyWorkManager.Dto;
using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Profiles
{
    public class CoverProfile:Profile
    {
        public CoverProfile()
        {
            CreateMap<Cover, CoverDto>();
        }

    }
}
