namespace _34_Front_To_BackSqlConnection.Models
{
    public class Cards:BaseEntity
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public string IconUrl {  get; set; }   
        public int Order {  get; set; }
        
    }
}
