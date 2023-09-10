using AutoMapper;
using GerenciamentoViagens.Data;
using GerenciamentoViagens.Data.Dto;
using GerenciamentoViagens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoViagens.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<IActionResult> RecuperarDepoimentoAsync([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        try
        {
            var depoimentos = await _context.depoimentos.ToListAsync();
            return Ok(_mapper.Map<LerDepoimentoDto>(depoimentos));
        } catch 
        {
            return NotFound();
        }
    }

    [HttpGet("{int:id}")]
    public async Task<IActionResult> RecuperarDepoimentoPorId(int id)
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

    [HttpDelete("{int:id}")]
    public async Task<IActionResult> DeletarDepoimento(int id)
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
