namespace idm.car.project.domain.Entities;

public class GroupAttribute
{
    public string GroupAttributeId { get; set; }
    public GroupAttributeType GroupAttributeType { get; set; }
    public string? Description { get; set; }
    public QuantityInformation QuantityInformation { get; set; }
    public List<Attributes> Attributes { get; set; }
    public int Order { get; set; }
}
