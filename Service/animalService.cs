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
        public bool Atualizar(int id, Animal animal)
        {
            var existente = _context.Animais.Find(id);
            if (existente == null) return false;

            existente.nome = animal.nome;
            existente.idade = animal.idade;
            existente.peso_KG = animal.peso_KG;
            existente.SexoId = animal.SexoId;
            _context.SaveChanges();
            return true;
        }


        public bool Deletar(int id)
        {
            var animal = _context.Animais.Find(id);

            if (animal == null)
                return false;

            _context.Animais.Remove(animal);
            _context.SaveChanges();
            return true;
        }
    }

}  
  
