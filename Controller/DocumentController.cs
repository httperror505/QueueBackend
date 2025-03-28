using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;

[Route("[controller]")]
[ApiController]
public class DocumentController(QueueDbContext context): ControllerBase
{
    private readonly QueueDbContext _context = context;
    
    [HttpPost("AddDocument")]
    public async Task<ActionResult<Document>> AddDepartment(CreateDocumentDTO newDocumentDto)
    {
        var newDocument = new Document()
        {
            Name = newDocumentDto.Name,
            DepartmentId = newDocumentDto.DepartmentId
        };
        _context.Document.Add(newDocument);
        await _context.SaveChangesAsync();
        return newDocument;
    }
}