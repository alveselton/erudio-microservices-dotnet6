using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Model;
using RestWithAspNet.Services;

namespace RestWithAspNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindByID(id);

        if (person == null) return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Client person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Client person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long? id)
    {
        if (id == null) return BadRequest();
        _personService.Delete((long)id);
        return NoContent();
    }
}