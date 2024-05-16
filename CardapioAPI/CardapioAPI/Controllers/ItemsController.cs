using CardapioAPI.Data;
using CardapioAPI.Model;
using CardapioAPI.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardapioAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _context; 

    public ItemsController(AppDbContext dbContext)
    {
        this._context = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAllItems()
    {
        var items = _context.Items.ToList();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var item = _context.Items.Find(id);
        if (item is null) return NotFound();

        return Ok(item);
    }


    [HttpPost]
    public IActionResult Create(ItemDTO itemDTO)
    {
        //var filePath = Path.Combine("Storage", itemDTO.Image.FileName);

        if (itemDTO.Name is null) return BadRequest(); 

        //using Stream fileStream = new FileStream(filePath, FileMode.Create);
        //itemDTO.Image.CopyTo(fileStream);

        Item item = new Item {
            Name = itemDTO.Name,
            Description = itemDTO.Description,
            ImagePath = itemDTO.ImagePath,
        };

        _context.Items.Add(item);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, ItemDTO itemDTO) 
    {
        var itemDB = _context.Items.Find(id);
        if (itemDB is null) return BadRequest();

        itemDB.Name = itemDTO.Name;
        itemDB.Description = itemDTO.Description;
        itemDB.ImagePath = itemDTO.ImagePath;

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Items.Find(id);
        if (item is null) return NotFound();
        _context.Items.Remove(item);

        return Ok();
    }


}
