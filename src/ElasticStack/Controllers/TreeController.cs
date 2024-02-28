using Microsoft.AspNetCore.Mvc;
using ElasticStack.Services;
using ElasticStack.Services.Repositories;

namespace ElasticStack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeController
  (OrganizationHelperService organizationHelper, IOrganizationRepository organizationRepository)
    : ControllerBase
{
  private readonly OrganizationHelperService _organizationHelper = organizationHelper;
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  [HttpGet]
  public async Task<IActionResult> GetAll()
    => Ok(await _organizationRepository.GetAllAsync());

  [HttpGet]
  [Route("{nodeId}/" + nameof(CheckAccess))]
  public async Task<IActionResult> CheckAccess([FromRoute] string nodeId, [FromQuery] string parnetId)
    => Ok(await _organizationHelper.CheckAccess(nodeId, parnetId));
}
