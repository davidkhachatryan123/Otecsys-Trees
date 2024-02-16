using Microsoft.AspNetCore.Mvc;
using TreeElasticStack.Services;

namespace TreeElasticStack;

[ApiController]
[Route("api/[controller]")]
public class TreeController(OrganizationHelperService organizationHelper) : ControllerBase
{
  private readonly OrganizationHelperService _organizationHelper = organizationHelper;

  [HttpGet]
  public async Task<IActionResult> GetAll()
    => Ok(await _organizationHelper.GetAllAsync());

  [HttpGet]
  [Route("{childId}/" + nameof(IsChildOf))]
  public async Task<IActionResult> IsChildOf([FromRoute] string childId, [FromQuery] string parnetId)
  {
    return Ok(await _organizationHelper.IsChildOfAsync(childId, parnetId));
  }
}
