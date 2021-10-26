using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        [Route("api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);
                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o id informado",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);
                if(user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o e-mail informado",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/search-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.SearchByEmail(email);
                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o e-mail informado",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/search-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var user = await _userService.SearchByName(name);
                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o nome informado",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
