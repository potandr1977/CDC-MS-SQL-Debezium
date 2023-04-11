using System.ComponentModel.DataAnnotations;

namespace CdcApi.Models;

public record Contract
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
