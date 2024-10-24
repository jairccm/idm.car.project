namespace idm.car.project.domain.Entities;

public class Attributes
{
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public string Name { get; set; }
    public int DefaultQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public int PriceImpactAmount { get; set; }
    public bool IsRequired { get; set; }
    public string? NegativeAttributeId { get; set; }
    public int Order { get; set; }
    public string StatusId { get; set; }
    public string? UrlImage { get; set; }
}
