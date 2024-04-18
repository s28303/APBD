﻿namespace lab06.Models.DTOs;

using System.ComponentModel.DataAnnotations;

public class AddAnimal
{
    [Required]
    [MinLength(3)]
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(200)]
    public string Category { get; set; }
    [MaxLength(200)]
    public string Area { get; set; }
}