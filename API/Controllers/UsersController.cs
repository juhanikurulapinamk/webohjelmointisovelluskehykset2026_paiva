
using System.Security.Cryptography.X509Certificates;
using API.Dtos;
using API.Factories;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
    {
        try
        {
            using var repo = UsersRepositoryFactory.Create();
            var users = await repo.GetAll();
            return Ok(users);

        } catch(Exception e)
        {
            return Problem($"Database error: {e.Message}", statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById(long id)
    {
        try
        {
            using var repo = UsersRepositoryFactory.Create();
            var user = await repo.GetById(id);
            if(user == null)
            {
                return NotFound("User not found");
            }

            await repo.Remove(id);


            
            return NoContent();

        } catch(Exception e)
        {
            return Problem($"Database error: {e.Message}", statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserRequest>> GetUserById(long id)
    {
        try
        {
            using var repo = UsersRepositoryFactory.Create();
            var user = repo.GetById(id);
            if(user == null)
            {
                return NotFound("user not found");
            }
            return Ok(user);

        } catch(Exception e)
        {
            return Problem($"Database error: {e.Message}", statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}