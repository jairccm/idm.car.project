namespace idm.car.project.domain.Entities;

public class QuantityInformation
{
    public int GroupAttributeQuantity { get; set; }
    public bool ShowPricePerProduct { get; set; }
    public bool IsShown { get; set; }
    public bool IsEditable { get; set; }
    public bool IsVerified { get; set; }
    public string VerifyValue { get; set; }
}
