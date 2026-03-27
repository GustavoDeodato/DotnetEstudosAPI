using DotnetEstudo.Data;
using DotnetEstudo.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetEstudo.Service
{
      public class AnimalService
    {
        private readonly AppDbContext _context;

        public AnimalService(AppDbContext context)
        {
            _context = context;
        } 
        // AQ PEGAMOS O NOSSO CONTEXT DO APPDBCONTEXT, COMO SE FOSSE O NOSSO DTO DO JAVA..OU ALGO ASSIM SEI LA 
        public List<Animal> ListarTodos()
        {
            return _context.Animais
            .Include(a => a.Sexo)
            .Include(a => a.habitats)
                .ThenInclude(h => h.habitat)
            .ToList();
        }
        //ESTAS LINHAS DE CIMA SÃO PARA GARANTIR QUE AS CHAVES ESTRANGEIRAS SERÃO ADICIONADAS TAMBÉM NO NOSSO JSON

        public Animal? BuscarPorID(int Id)
        {
            return _context.Animais
            .Include(a => a.Sexo)
            .FirstOrDefault(a => a.Id == Id);
        }

        
        public Animal Criar(Animal animal)
        {
            _context.Animais.Add(animal);
            _context.SaveChanges();
            return animal;
        }
    }

}  
  
