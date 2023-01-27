namespace WebApplication3.Models
{
    public class HomeViewModel
    {
        public HomeViewModel getData() //Construtor getData (atribui valor a todas as novas instâncias da classe criadas
        {
            HomeViewModel obj = new HomeViewModel() //Nova instância da classe permite atribuir valores diferentes à uma nova instância específica da classe
            {
                Id = 1,
                Name = "Matheus"
            };

            return obj;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
