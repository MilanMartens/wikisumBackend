//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WikiSumBackend.Contracts.Webpage;
//using WikiSumBackend.Domain.Entiteiten;
//using WikiSumBackend.Infrastructure;

//[ApiController]
//[Route("api/[controller]")]
//public class WebpageController : ControllerBase
//{
//    private readonly AppDbContext _context;
//    private readonly IMapper _mapper;

//    public WebpageController(
//        AppDbContext context,
//        IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }

//    // GET: api/Webpage
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<WebpageDto>>> GetAll()
//    {
//        var webpages = await _context.Webpage
//            .AsNoTracking()
//            .Include(w => w.Chapters)
//                .ThenInclude(c => c.Summaries)
//            .ToListAsync();

//        var result = _mapper.Map<List<WebpageDto>>(webpages);

//        return Ok(result);
//    }

//    // GET: api/Webpage/1
//    [HttpGet("{url}")]
//    public async Task<ActionResult<WebpageDto>> GetByUrl(string url)
//    {
//        string decodedUrl = Uri.UnescapeDataString(url);
//        var webpage = await _context.Webpage
//            .AsNoTracking()
//            .Include(w => w.Chapters)
//                .ThenInclude(c => c.Summaries)
//            .FirstOrDefaultAsync(w => w.Url == decodedUrl);

//        if (webpage == null)
//            return NotFound();

//        var result = _mapper.Map<WebpageDto>(webpage);

//        return Ok(result);
//    }

//    // POST: api/Webpage
//    [HttpPost]
//    public async Task<ActionResult<WebpageDto>> Create(
//        CreateWebpageDto dto)
//    {
//        var webpage = _mapper.Map<Webpage>(dto);

//        _context.Webpage.Add(webpage);

//        await _context.SaveChangesAsync();

//        var result = _mapper.Map<WebpageDto>(webpage);

//        return CreatedAtAction(
//            nameof(GetByUrl),
//            new { url = Uri.EscapeDataString(webpage.Url) },
//            result
//        );
//    }

//    // PUT: api/Webpage/1
//    [HttpPut("{url}")]
//    public async Task<ActionResult<WebpageDto>> Update(
//        string url,
//        UpdateWebpageDto dto)
//    {
//        string decodedUrl = Uri.UnescapeDataString(url);
//        Webpage webpage = await _context.Webpage
//            .Include(w => w.Chapters)
//                .ThenInclude(c => c.Summaries)
//            .FirstOrDefaultAsync(w => w.Url == decodedUrl);

//        if (webpage == null)
//            return NotFound();

//        foreach (var chapterDto in dto.Chapters)
//        {
//            var chapter = webpage.Chapters
//                .FirstOrDefault(c => c.Title == chapterDto.OriginalTitle);

//            if (chapter == null)
//                continue;

//            foreach (var summaryDto in chapterDto.Summaries)
//            {
//                var newSummary = _mapper.Map<Summary>(summaryDto);
//                chapter.Summaries.Add(newSummary);
//            }
//        }

//        // Bestaande gegevens updaten
//        _mapper.Map(dto, webpage);

//        await _context.SaveChangesAsync();

//        var result = _mapper.Map<WebpageDto>(webpage);

//        return Ok(result);
//    }

//    // DELETE: api/Webpage/1
//    [HttpDelete("{url}")]
//    public async Task<IActionResult> Delete(string url)
//    {
//        string decodedUrl = Uri.UnescapeDataString(url);

//        var webpage = await _context.Webpage
//            .FirstOrDefaultAsync(w => w.Url == decodedUrl);

//        if (webpage == null)
//            return NotFound();

//        _context.Webpage.Remove(webpage);

//        await _context.SaveChangesAsync();

//        return NoContent();
//    }
//}

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
                .ThenInclude(c => c.Translations)
                    .ThenInclude(t => t.Summaries)
            .ToListAsync();

        var result = _mapper.Map<List<WebpageDto>>(webpages);

        return Ok(result);
    }

    // GET: api/Webpage/1
    [HttpGet("{url}")]
    public async Task<ActionResult<WebpageDto>> GetByUrl(string url)
    {
        string decodedUrl = Uri.UnescapeDataString(url);

        var webpage = await _context.Webpage
            .AsNoTracking()
            .Include(w => w.Chapters)
                .ThenInclude(c => c.Translations)
                    .ThenInclude(t => t.Summaries)
            .FirstOrDefaultAsync(w => w.Url == decodedUrl);

        if (webpage == null)
            return NotFound();

        var result = _mapper.Map<WebpageDto>(webpage);

        return Ok(result);
    }

    // POST: api/Webpage
    [HttpPost]
    public async Task<ActionResult<WebpageDto>> Create(CreateWebpageDto dto)
    {
        var webpage = _mapper.Map<Webpage>(dto);

        _context.Webpage.Add(webpage);

        await _context.SaveChangesAsync();

        var result = _mapper.Map<WebpageDto>(webpage);

        return CreatedAtAction(
            nameof(GetByUrl),
            new { url = Uri.EscapeDataString(webpage.Url) },
            result
        );
    }

    // PUT: api/Webpage/1
    [HttpPut("{url}")]
    public async Task<ActionResult<WebpageDto>> Update(
    string url,
    UpdateWebpageDto dto)
    {
        string decodedUrl = Uri.UnescapeDataString(url);

        var webpage = await _context.Webpage
            .Include(w => w.Chapters)
                .ThenInclude(c => c.Translations)
                    .ThenInclude(t => t.Summaries)
            .FirstOrDefaultAsync(w => w.Url == decodedUrl);

        if (webpage == null)
            return NotFound();

        foreach (var chapterDto in dto.Chapters)
        {
            var chapter = webpage.Chapters.FirstOrDefault(c => c.Translations.Any(t => t.Title == chapterDto.OriginalTitle));

            if (chapter == null)
                continue;

            foreach (var translationDto in chapterDto.Translations)
            {
                var translation = chapter.Translations
                    .FirstOrDefault(t => t.Language == translationDto.Language);

                if (translation == null)
                {
                    translation = new ChapterTranslation
                    {
                        Language = translationDto.Language,
                        Title = translationDto.Title,
                        ChapterId = chapter.Id
                    };

                    chapter.Translations.Add(translation);
                }
                else
                {
                    translation.Title = translationDto.Title;
                }

                foreach (var summaryDto in translationDto.Summaries)
                {
                    var newSummary = _mapper.Map<Summary>(summaryDto);

                    translation.Summaries.Add(newSummary);
                }
            }
        }

        await _context.SaveChangesAsync();

        var result = _mapper.Map<WebpageDto>(webpage);

        return Ok(result);
    }

    // DELETE: api/Webpage/1
    [HttpDelete("{url}")]
    public async Task<IActionResult> Delete(string url)
    {
        string decodedUrl = Uri.UnescapeDataString(url);

        var webpage = await _context.Webpage
            .FirstOrDefaultAsync(w => w.Url == decodedUrl);

        if (webpage == null)
            return NotFound();

        _context.Webpage.Remove(webpage);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}

