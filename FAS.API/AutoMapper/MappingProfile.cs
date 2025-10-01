using AutoMapper;
using FAS.Model.DTOs;
using FAS.Model.Models;

namespace FAS.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EvaluationCriterion, EvaluationCriterionDto>()
          .ForMember(dest => dest.AwardCategoryName, opt => opt.MapFrom(src => src.AwardCategory.Name));
            CreateMap<CreateEvaluationCriterionDto, EvaluationCriterion>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateEvaluationCriterionDto, EvaluationCriterion>();
            CreateMap<AwardCategoryCreateDto, AwardCategory>();
            CreateMap<AwardCategory, AwardCategoryDto>();
        }
    }
}
