using FIAP.Hackathon.Application.Interfaces;
using FIAP.Hackathon.Application.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Hackathon.Paciente.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IPacienteService _pacienteService;
        private readonly IValidator<PacienteRequest> _pacienteValidator;

        public PacienteController(ITokenService tokenService, IPacienteService pacienteService, IValidator<PacienteRequest> pacienteValidator) 
        {
            _tokenService = tokenService;
            _pacienteService = pacienteService;
            _pacienteValidator = pacienteValidator;
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public IActionResult AutenticarPaciente([Required] string email, [Required] string senha)
        {
            var token = _tokenService.RetornarToken(email, senha);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }

            return BadRequest("Não foi possível autenticar. Favor verifique.");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CriarPaciente([FromBody] PacienteRequest request)
        {
            var validationResult = _pacienteValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Property = e.PropertyName, Message = e.ErrorMessage })
                    .ToList();

                return BadRequest(new { Errors = errors });
            }

            _pacienteService.CriarPaciente(request);

            return Ok();
        }

        [HttpPut("{pacienteId}")]
        public IActionResult EditarPaciente(Guid pacienteId, [FromBody] PacienteRequest request)
        {
            var validationResult = _pacienteValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Property = e.PropertyName, Message = e.ErrorMessage })
                    .ToList();

                return BadRequest(new { Errors = errors });
            }

            _pacienteService.EditarPaciente(pacienteId, request);

            return Ok();
        }

        [HttpDelete("{pacienteId}")]
        public IActionResult ExcluirPaciente(Guid pacienteId)
        {
            _pacienteService.ExcluirPaciente(pacienteId);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{pacienteId}")]
        public IActionResult RetornarDadosPaciente(Guid pacienteId)
        {
            var paciente = _pacienteService.RetornarPorId(pacienteId);
            return Ok(paciente);
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult RetornarPacientes()
        {
            var paciente = _pacienteService.RetornarTodos();
            return Ok(paciente);
        }
    }
}
