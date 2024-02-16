using Microsoft.AspNetCore.Mvc;
using TreeSQL.Services;

namespace TreeSQL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeController(OrganizationHelperService organizationHelper) : ControllerBase
{
  private readonly OrganizationHelperService _organizationHelper = organizationHelper;

  [HttpGet]
  [Route("{childId}/" + nameof(IsChildOf))]
  public async Task<IActionResult> IsChildOf([FromRoute] int childId, [FromQuery] int parnetId)
    => Ok(await _organizationHelper.IsChildOfAsync(childId, parnetId));
}
