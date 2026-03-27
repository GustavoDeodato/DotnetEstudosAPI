namespace DotnetEstudo.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public int idade { get; set; }
        public double peso_KG { get; set; }
        public int SexoId { get; set; }
        public Sexo? Sexo { get; set; }
        public List<HabitatAnimal> habitats { get; set; } = [];
    }
}
