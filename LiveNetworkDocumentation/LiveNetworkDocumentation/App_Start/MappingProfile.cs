using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LiveNetworkDocumentation.Models;
using LiveNetworkDocumentation.ViewModels;

namespace LiveNetworkDocumentation.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to ViewModel
            Mapper.CreateMap<KhadamatMashiniPersonnel, PersonnelSematMantagheViewModel>();
            // ViewModel to Domain
            Mapper.CreateMap<PersonnelSematMantagheViewModel, KhadamatMashiniPersonnel>()
                .ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}