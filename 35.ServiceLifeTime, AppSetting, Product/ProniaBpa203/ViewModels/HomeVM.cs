
using ProniaBpa203.Models;

namespace ProniaBpa203.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Product> Products { get; internal set; }
    }
}
