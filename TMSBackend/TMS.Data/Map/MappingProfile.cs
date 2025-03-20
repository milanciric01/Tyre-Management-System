using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Models;

namespace TMS.Data.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from ProductionDTO to ProductionRecord
            CreateMap<ProductionDTO, ProductionRecord>()
                .ForMember(dest => dest.PerformedBy, opt => opt.Ignore()) // Ignore navigation property
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id if you want to generate it in the database

            // Mapping from ProductionRecord to ProductionDTO
            CreateMap<ProductionRecord, ProductionDTO>()
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
                .ForMember(dest => dest.PerformedById, opt => opt.MapFrom(src => src.PerformedById)); // Include this if you want to send back the user's ID

            CreateMap<TyreSalesDTO, TyreSales>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Assuming Id is generated in the database
            .ForMember(dest => dest.DateOfSale, opt => opt.Ignore()) // Ignore if you want to set it manually
            .ForMember(dest => dest.ReferenceProductionId, opt => opt.MapFrom(src => src.ReferenceProductionId));

            CreateMap<LogDTO, Log>().ReverseMap();
            
        }
    }
}
