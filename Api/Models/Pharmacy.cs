using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Pharmacy: EntityWithId
{
    public int Id { get; set; }
    [Column("PharmacyName")]
    public string Name { get; set; }
    public string Telephone { get; set; }
    public decimal GeoLat { get; set; }
    public decimal GeoLong { get; set; }
    public string Website { get; set; }
    public Address Address { get; set; }
}
