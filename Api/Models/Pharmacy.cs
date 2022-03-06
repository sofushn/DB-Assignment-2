namespace Api.Models;

public class Pharmacy
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Telephone { get; set; }
    public decimal GeoLat { get; set; }
    public decimal GeoLong { get; set; }
    public string Website { get; set; }
}
