using AutoMapper;
using TreeElasticStack.Dto;

namespace TreeElasticStack.Mappings;

public class OrganizationMappingProfile : Profile
{
  public OrganizationMappingProfile()
  {
    CreateMap<Organization, OrganizationReadDto>();
    CreateMap<OrganizationCreateDto, Organization>();
  }
}
