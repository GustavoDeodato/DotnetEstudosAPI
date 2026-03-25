namespace DotnetEstudo.Models
{
    public class Habitat
    {
        public int Id { get; set; }
        public string habitat { get; set; }
        public List<HabitatAnimal> Animais { get; set; }
    }
}
