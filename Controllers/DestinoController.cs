using AutoMapper;
using GerenciamentoViagens.Data;
using GerenciamentoViagens.Data.Dto;
using GerenciamentoViagens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoViagens.Controllers;

[ApiController]
[Route("[controller]")]
public class DestinoController : ControllerBase
{
    private ViagensContext _context;
    private IMapper _mapper;

    public DestinoController(ViagensContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ListarDestinosAsync([FromQuery] int skip = 0, int take = 0)
    {
        try
        {
            var destinos = await _context.destinos.Skip(skip).Take(take).ToListAsync();
            return Ok(_mapper.Map<List<LerDestinoDto>>(destinos));
        } catch 
        {
            return NotFound();
        }
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarDestinosPorIdAsync(int id)
    { 
        if(id == null) return NotFound();
        
        var destinos = await _context.destinos.FirstAsync(x => x.Id == id);
        return Ok(_mapper.Map<LerDepoimentoDto>(destinos));
    }

    [HttpPost]
    public async Task<IActionResult> CriarDestinoAsync([FromBody] CriarDepoimentoDto destinoDto)
    {
        var destino = _mapper.Map<Destino>(destinoDto);
        await _context.destinos.AddAsync(destino);
        return CreatedAtAction(nameof(ListarDestinosPorIdAsync), new { id = destino.Id }, destino);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ApagarDestinoAsync(int id)
    {
        var destino = await _context.destinos.FirstAsync(x => x.Id == id);
        if(destino == null) return NotFound();

        _context.destinos.Remove(destino);
        return NoContent();
    }


}
