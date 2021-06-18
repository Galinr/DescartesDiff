namespace DiffLibrary.Models
{
    public interface IData
    {
        string Base { get; set; }
        int ID { get; set; }
        int Key { get; set; }
        string Side { get; set; }
    }
}