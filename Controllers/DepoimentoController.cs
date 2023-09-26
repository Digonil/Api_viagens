using AutoMapper;
using GerenciamentoViagens.Data;
using GerenciamentoViagens.Data.Dto;
using GerenciamentoViagens.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoViagens.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("AcessoApi")]
public class DepoimentoController : ControllerBase
{
    private ViagensContext _context;
    private IMapper _mapper;

    public DepoimentoController(ViagensContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> RecuperarDepoimentoAsync([FromQuery] int page = 0, [FromQuery] int pageSize = 20)
    {
        try
        {   
            var depoimentos = await _context.depoimentos.Skip(page).Take(pageSize).ToListAsync();
            return Ok(_mapper.Map<List<LerDepoimentoDto>>(depoimentos));
        } catch 
        {
            return NotFound();
        }
    }

    [HttpGet("depoimentos-home")]
    public async Task<IActionResult> RecuperarOs3PrimeirosDepoimentoAsync([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        try
        {
            var depoimentos = await _context.depoimentos.Skip(skip).Take(take).ToListAsync();
            return Ok(_mapper.Map<List<LerDepoimentoDto>>(depoimentos));
        } catch
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarDepoimentoPorId([FromQuery] int id)
    {
        var depoimento = await _context.depoimentos.FirstOrDefaultAsync(x => x.Id == id);
        if (depoimento == null)
        {
            return NotFound();
        }
        var depoimentoDto = _mapper.Map<LerDepoimentoDto>(depoimento);

        return Ok(depoimentoDto);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarComentario([FromBody] CriarDepoimentoDto depoimentoDto)
    {
        var depoimento = _mapper.Map<Depoimento>(depoimentoDto);

        await _context.depoimentos.AddAsync(depoimento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(RecuperarDepoimentoPorId), new {id = depoimento.Id}, depoimento);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarDepoimento([FromQuery] int id)
    {
        var depoimento = await _context.depoimentos.FirstOrDefaultAsync(x => x.Id == id);
        if (depoimento == null)
        {
            return NotFound();
        }
        _context.depoimentos.Remove(depoimento);

        return NoContent();
    }
}
