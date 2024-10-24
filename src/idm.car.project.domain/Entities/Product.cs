namespace idm.car.project.domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<GroupAttribute> GroupAttributes { get; set; }
}
