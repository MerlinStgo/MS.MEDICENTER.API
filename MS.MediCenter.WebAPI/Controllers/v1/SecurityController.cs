using Microsoft.AspNetCore.Mvc;
using MS.MediCenter.Application.Features.Security.Commands;
using MS.MediCenter.Application.Features.Security.Queries;
using System.Threading.Tasks;

namespace MS.MediCenter.WebAPI.Controllers.v1.Security
{
    /// <summary>
    /// Controlador Security
    /// </summary>
    [ApiVersion("1.0")]
    public class SecurityController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Get: api/<controller>/1
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult> GetAll([FromQuery] GetAllUserParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllUserQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Nombre = filter.Nombre,
                Usuario = filter.Usuario
            }));
        }

    }
}
