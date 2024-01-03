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
    public async Task<IActionResult> ListarDestinosAsync([FromQuery] int page = 0,[FromQuery] int pageSize = 0)
    {
        try
        {
            var destinos = await _context.Destinos.Skip(page).Take(pageSize).ToListAsync();
            return Ok(_mapper.Map<List<LerDestinoNomeDto>>(destinos));
        } catch 
        {
            return NotFound();
        }
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarDestinosPorIdAsync([FromRoute] int id)
    { 
        if(id == null) return NotFound();
        
        var destinos = await _context.Destinos.FirstAsync(x => x.Id == id);
        return Ok(_mapper.Map<LerDestinoDto>(destinos));
    }

    [HttpGet("{nome}")]
    public async Task<IActionResult> ListarDestinosPorNomeAsync([FromRoute] string nome)
    {
        if (nome == null)
        {
            return NotFound("Nenhum destino foi encontrado.");
        }
            
            var destinos = await _context.Destinos.FirstAsync(x => x.Nome == nome);
            return Ok(_mapper.Map<LerDestinoNomeDto>(destinos));  
    }

    [HttpPost]
    public async Task<IActionResult> CriarDestinoAsync([FromBody] CriarDestinoDto destinoDto)
    {
        var destino = _mapper.Map<Destino>(destinoDto);
        await _context.Destinos.AddAsync(destino);
        return CreatedAtAction(nameof(ListarDestinosPorIdAsync), new { id = destino.Id }, destino);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ApagarDestinoAsync([FromQuery] int id)
    {
        var destino = await _context.Destinos.FirstAsync(x => x.Id == id);
        if(destino == null) return NotFound();

        _context.Destinos.Remove(destino);
        return NoContent();
    }


}
