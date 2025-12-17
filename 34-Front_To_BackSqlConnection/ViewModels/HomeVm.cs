using _34_Front_To_BackSqlConnection.Models;

namespace _34_Front_To_BackSqlConnection.ViewModels
{
    public class HomeVM
    {
        public List <Slider> sliders { get; set; }
        public List<Slider> Sliders { get; internal set; }
        public Cards Cards { get; internal set; }
    }
}
