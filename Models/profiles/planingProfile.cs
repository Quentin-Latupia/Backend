using AutoMapper;
using DTO;
using Models;

namespace profiles
{
    public class planingProfile : Profile
    {
        public planingProfile()
        {
            CreateMap<planningDTO, Reservation>()
                .ForMember(d => d.RES_id, opt => opt.MapFrom(s => s.RES_id))
                .ForMember(d => d.RES_heure_debut, opt => opt.MapFrom(s => s.RES_heure_debut))
                .ForMember(d => d.RES_heure_fin, opt => opt.MapFrom(s => s.RES_heure_fin))
                .ForMember(d => d.RES_prive, opt => opt.MapFrom(s => s.RES_prive == 1))
                .ForMember(d => d.RES_statut, opt => opt.MapFrom(s => s.RES_statut));

            CreateMap<planningDTO, Site>()
                .ForMember(d => d.SIT_nom, opt => opt.MapFrom(s => s.SIT_nom));

            CreateMap<planningDTO, Terrain>()
                .ForMember(d => d.TER_nom, opt => opt.MapFrom(s => s.TER_nom));
        }
    }
}
