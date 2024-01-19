using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;



namespace ContosoPizza.Controller;

[ApiController]
[Route("[Controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _pizzaService;
    public PizzaController(PizzaService pizzaService) =>
        _pizzaService = pizzaService;
    

    [HttpGet]
    public async Task<List<Pizza>> GetAll() =>
        await _pizzaService.GetAsync();
    
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Pizza>> Get(String id){
        var pizza = await _pizzaService.GetAsync(id);
        if (pizza == null){
            return NotFound();
        }

        return pizza;

    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza){
        await _pizzaService.CreateAsync(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, Pizza newpizza){
        var pizza = await _pizzaService.GetAsync(id);

        if (pizza == null){
            return NotFound();
        }

        newpizza.Id = pizza.Id;
        await _pizzaService.UpdateAsync(id, newpizza);
        return NoContent();

    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(String id){
        var pizza = await _pizzaService.GetAsync(id);
        if (pizza == null){
            return NotFound();
        }

        await _pizzaService.RemoveAsync(id);
        return NoContent();

    }
    
}



