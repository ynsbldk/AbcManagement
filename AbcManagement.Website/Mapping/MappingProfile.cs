using AbcManagement.Entities.Entities;
using AbcManagement.Website.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AbcManagement.Website.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectModel>();
            CreateMap<ProjectModel, Project>();
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();
        }
            
    }
}
