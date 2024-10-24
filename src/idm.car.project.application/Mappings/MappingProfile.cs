using AutoMapper;
using idm.car.project.application.Dtos;
using idm.car.project.application.Features.Product.Commands.AddCommand;
using idm.car.project.application.Features.Product.Commands.UpdateCommand;
using idm.car.project.domain.Entities;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace idm.car.project.application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<GroupAttributeTypeDto, GroupAttributeType>();
        CreateMap<QuantityInformationDto, QuantityInformation>();
        CreateMap<AttributesDto, Attributes>();
        CreateMap<GroupAttributeDto, GroupAttribute>()
            .ForMember(dest => dest.GroupAttributeType, opt => opt.MapFrom(src => src.GroupAttributeType))
            .ForMember(dest => dest.QuantityInformation, opt => opt.MapFrom(src => src.QuantityInformation))
            .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes));
        CreateMap<AddProductCommand, Product>()
    .ForMember(dest => dest.GroupAttributes, opt => opt.MapFrom(src => src.GroupAttributes));

        CreateMap<UpdateProductCommand, Product>()
            .ForMember(dest => dest.GroupAttributes, opt => opt.MapFrom(src => src.GroupAttributes));



        CreateMap<GroupAttributeType, GroupAttributeTypeDto>();
        CreateMap<QuantityInformation, QuantityInformationDto>();
        CreateMap<Attributes, AttributesDto>();
        
        CreateMap<GroupAttribute, GroupAttributeDto>()
            .ForMember(dest => dest.GroupAttributeType, opt => opt.MapFrom(src => src.GroupAttributeType))
            .ForMember(dest => dest.QuantityInformation, opt => opt.MapFrom(src => src.QuantityInformation))
            .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes));

        CreateMap<Product, ProductVm>()
            .ForMember(dest => dest.GroupAttributes, opt => opt.MapFrom(src => src.GroupAttributes));

    }
}
