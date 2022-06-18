using Clinica.Data.Model;
using Clinica.Data.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Clinica.Data.Repository
{
    public class ExameRepository
    {

        private readonly DataContext _dataContext;

        public ExameRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ExameDto GetById(int id)
        {
            return ModelToDto(ById(id));
        }

        public List<ExameDto> GetAll()
        {
            List<ExameDto> examesDTOs = new List<ExameDto>();
            foreach (var item in _dataContext.Exames.ToList())
            {
                examesDTOs.Add(ModelToDto(item));
            }

            return examesDTOs;
        }

        public void Add(ExameDto exame)
        {
            _dataContext.Exames.Add(DtoToModel(exame));
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            EntityEntry<Exame> temp = _dataContext.Exames.Remove(ById(id));
            _dataContext.SaveChanges();

            if (temp.Entity == null)
            {
                throw new Exception("Erro ao remover exame");
            }
        }

        public ExameDto Edit(ExameDto exameDto)
        {
            Exame exame = DtoToModel(exameDto);
            exame.dataExame = DateTime.Now;
            _dataContext.Entry(exame).State = EntityState.Modified;
            _dataContext.SaveChanges();

            return exameDto;
        }

        private Exame? ById(int id)
        {
            return _dataContext.Exames.FirstOrDefault(e => e.Id == id);
        }

        private ExameDto ModelToDto(Exame exame)
        {
            ExameDto exameDto = new ExameDto();
            exameDto.Cpf = exame.Cpf;
            exameDto.Id = exame.Id;
            exameDto.NomePaciente = exame.NomePaciente;
            exameDto.resultado = exame.resultado;
            exameDto.dataExame = exame.dataExame;

            return exameDto;
        }

        private Exame DtoToModel(ExameDto exameDTO)
        {
            Exame exame = new Exame();
            exame.Cpf = exameDTO.Cpf;
            exame.Id = exameDTO.Id;
            exame.NomePaciente = exameDTO.NomePaciente;
            exame.resultado = exameDTO.resultado;
            exame.dataExame = exameDTO.dataExame;

            return exame;
        }
    

}
}
