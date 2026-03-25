namespace DotnetEstudo.Models
{
    public class HabitatAnimal
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int animalId { get; set; }
        public Animal animal { get; set; }
        public int habitatId { get; set; }
        public Habitat habitat { get; set; }
    }
}
