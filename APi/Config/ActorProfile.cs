using APi.DTO;
using AutoMapper;

namespace APi.Config
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {

            CreateMap<ActorDto, Actor>();
        }

    }
}
