using AutoMapper;
using TreeSQL.Dto;
using TreeSQL.Models;

namespace TreeSQL.Mappings;

public class OrganizationMappingProfile : Profile
{
  public OrganizationMappingProfile()
  {
    CreateMap<Organization, OrganizationReadDto>();
    CreateMap<OrganizationCreateDto, Organization>();
  }
}
