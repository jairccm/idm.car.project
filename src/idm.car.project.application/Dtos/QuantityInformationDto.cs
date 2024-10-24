namespace idm.car.project.application.Dtos;

public class QuantityInformationDto
{
    public int GroupAttributeQuantity { get; set; }
    public bool ShowPricePerProduct { get; set; }
    public bool IsShown { get; set; }
    public bool IsEditable { get; set; }
    public bool IsVerified { get; set; }
    public string VerifyValue { get; set; }
}
