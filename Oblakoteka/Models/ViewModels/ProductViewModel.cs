namespace Oblakoteka;

public class ProductViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ProductViewModel() { }
    public ProductViewModel(Guid id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }
}