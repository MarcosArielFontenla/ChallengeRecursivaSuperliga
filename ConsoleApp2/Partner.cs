namespace ConsoleApp2
{
    public class Partner
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Team { get; set; }
        public string MaritalStatus { get; set; }
        public string Studies { get; set; }

        public string OnlyNameAgeTeam => $"Nombre: {Name} \tEdad: {Age} \tEquipo: {Team}";
        public override string ToString()
        {
            return $"Nombre: {Name},\tEdad: {Age},\tEquipo: {Team},\tEstado civil: {MaritalStatus},\tEstudios: {Studies}";
        }
    }
}
