using Microsoft.AspNetCore.Mvc;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Wrappers;
using System.Threading.Tasks;
using MS.MediCenter.Core.Security;

namespace MS.MediCenter.WebAPI.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SecurityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await _unitOfWork.Users.GetByIdAsync(Id);
            var response = new Response<User>(data);

            return Ok(response);
        }
    }
}
