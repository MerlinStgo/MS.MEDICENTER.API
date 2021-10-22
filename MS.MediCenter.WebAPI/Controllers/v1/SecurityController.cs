using Microsoft.AspNetCore.Mvc;
using MS.MediCenter.Application.Features.Security.Commands;
using System.Threading.Tasks;

namespace MS.MediCenter.WebAPI.Controllers.v1.Security
{
    /// <summary>
    /// Controlador Security
    /// </summary>
    [ApiVersion("1.0")]
    public class SecurityController : BaseApiController
    {
        //private readonly IUnitOfWork _unitOfWork;
        
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="unitOfWork"></param>
        //public SecurityController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}



        ///// <summary>
        ///// Método para obtener un usuario por ID
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById(int Id)
        //{
        //    try
        //    {
        //        var data = await _unitOfWork.Users.GetByIdAsync(Id);
        //        return Ok(new Response<User>(data));
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new Response<User>(e.Message));
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }
    }
}
