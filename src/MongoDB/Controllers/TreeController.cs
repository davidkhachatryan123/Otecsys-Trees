using Microsoft.AspNetCore.Mvc;
using MongoDB.Services;

namespace MongoDB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeController(OrganizationHelperService organizationHelper) : ControllerBase
{
  private readonly OrganizationHelperService _organizationHelper = organizationHelper;

  [HttpGet]
  [Route("{nodeId}/" + nameof(CheckAccess))]
  public async Task<IActionResult> CheckAccess([FromRoute] string nodeId, [FromQuery] string parnetId)
  => Ok(await _organizationHelper.CheckAccess(nodeId, parnetId));
}
