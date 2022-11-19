using System.ComponentModel.DataAnnotations;
using TccUmc.Application.DTO.Professional;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Consult;

public class ConsultPostDto
{
    [Required]public Guid Procedure { get; set; }
    [Required]public DateTime ConsultStart { get; set; }
    public Guid? Professional { get; set; }
}