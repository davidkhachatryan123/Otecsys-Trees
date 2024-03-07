﻿using Microsoft.AspNetCore.Mvc;
using SQL.ClosureTable.Services;

namespace SQL.ClosureTable.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeController(OrganizationHelperService organizationHelper) : ControllerBase
{
  private readonly OrganizationHelperService _organizationHelper = organizationHelper;

  [HttpGet]
  [Route("{nodeId}/" + nameof(CheckAccess))]
  public async Task<IActionResult> CheckAccess([FromRoute] int nodeId, [FromQuery] int parentId)
    => Ok(await _organizationHelper.CheckAccess(nodeId, parentId));
}
