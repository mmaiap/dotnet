using Microsoft.AspNetCore.Mvc;
using Clinica.Data;
using Clinica.Data.Repository;
using Clinica.Data.Dto;



namespace Clinica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly ExameRepository _exameRepository;

        public ExameController(DataContext dataContext)
        {
            _exameRepository = new ExameRepository(dataContext);
        }

        [HttpGet("byId/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_exameRepository.GetById(id));
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_exameRepository.GetAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] ExameDto exame)
        {

            exame.dataExame = DateTime.Now;
            exame.NomePaciente = exame.NomePaciente.ToUpper();

            _exameRepository.Add(exame);

            return Ok("Exame adicionado!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _exameRepository.Delete(id);
                return Ok("Exame removido!");
            }
            catch (ArgumentNullException)
            {
                return Ok("Exame nao encontrado");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Edit([FromBody] ExameDto exame)
        {
            return Ok(_exameRepository.Edit(exame));
        }
    }


}

