﻿using KanyeRestAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanyeRestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KanyeRestController : ControllerBase
{
    private readonly IKanyeRestService _kanyeRestService;

    public KanyeRestController(IKanyeRestService kanyeRestService)
    {
        _kanyeRestService = kanyeRestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetKanyeRest()
    {
        var kanyeRestResponse = await _kanyeRestService.GetKanyeRestRandom();

        if (kanyeRestResponse is null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "Erro ao obter uma fala do Kanye Rest.");
        }

        return StatusCode(StatusCodes.Status200OK, (new { KanyeRestAPI = kanyeRestResponse}));
    }
}