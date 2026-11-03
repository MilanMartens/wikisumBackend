using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiSumBackend.Contracts.Webpage;
using WikiSumBackend.Domain.Entiteiten;
using WikiSumBackend.Infrastructure;

[ApiController]
[Route("api/[controller]")]
public class WebpageController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public WebpageController(
        AppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Webpage
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WebpageDto>>> GetAll()
    {
        var webpages = await _context.Webpage
            .AsNoTracking()
            .Include(w => w.Chapters)
                .ThenInclude(c => c.Summaries)
            .ToListAsync();

        var result = _mapper.Map<List<WebpageDto>>(webpages);

        return Ok(result);
    }

    // GET: api/Webpage/1
    [HttpGet("{id}")]
    public async Task<ActionResult<WebpageDto>> GetById(int id)
    {
        var webpage = await _context.Webpage
            .AsNoTracking()
            .Include(w => w.Chapters)
                .ThenInclude(c => c.Summaries)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (webpage == null)
            return NotFound();

        var result = _mapper.Map<WebpageDto>(webpage);

        return Ok(result);
    }

    // POST: api/Webpage
    [HttpPost]
    public async Task<ActionResult<WebpageDto>> Create(
        CreateWebpageDto dto)
    {
        var webpage = _mapper.Map<Webpage>(dto);

        _context.Webpage.Add(webpage);

        await _context.SaveChangesAsync();

        var result = _mapper.Map<WebpageDto>(webpage);

        return CreatedAtAction(
            nameof(GetById),
            new { id = webpage.Id },
            result
        );
    }

    // PUT: api/Webpage/1
    [HttpPut("{id}")]
    public async Task<ActionResult<WebpageDto>> Update(
        int id,
        UpdateWebpageDto dto)
    {
        var webpage = await _context.Webpage
            .Include(w => w.Chapters)
                .ThenInclude(c => c.Summaries)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (webpage == null)
            return NotFound();

        // Bestaande gegevens updaten
        _mapper.Map(dto, webpage);

        await _context.SaveChangesAsync();

        var result = _mapper.Map<WebpageDto>(webpage);

        return Ok(result);
    }

    // DELETE: api/Webpage/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var webpage = await _context.Webpage
            .FindAsync(id);

        if (webpage == null)
            return NotFound();

        _context.Webpage.Remove(webpage);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}