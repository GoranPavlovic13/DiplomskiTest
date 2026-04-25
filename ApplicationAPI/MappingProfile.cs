using AutoMapper;
using Entitites.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Test;

namespace ApplicationAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();

            CreateMap<TestAIDto, Test>()
                .ForMember(dest => dest.Level, opt =>
                    opt.MapFrom(src => Enum.Parse<Level>(src.Level, true)))
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom(src => src.Exercises));

            CreateMap<ExerciseAIDto, Exercise>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));

            CreateMap<AnswerAIDto, Answer>();
        }


    }
}
