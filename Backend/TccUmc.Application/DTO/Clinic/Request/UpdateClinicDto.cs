﻿namespace TccUmc.Application.DTO.Clinic.Request;

public class UpdateClinicDto
{
    public string Name { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = new AddressDto();
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Whatsapp { get; set; } = string.Empty;
    public List<WorkingHoursDto> WorkingHours { get; set; } = new List<WorkingHoursDto>();
}