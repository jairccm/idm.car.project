namespace idm.car.project.application.Dtos;

public class GroupAttributeDto
{
    public string GroupAttributeId { get; set; }
    public GroupAttributeTypeDto GroupAttributeType { get; set; }
    public string? Description { get; set; }
    public QuantityInformationDto QuantityInformation { get; set; }
    public List<AttributesDto> Attributes { get; set; }
    public int Order { get; set; }
}
