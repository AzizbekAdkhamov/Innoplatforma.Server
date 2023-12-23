﻿using Innoplatforma.Server.Domain.Entities.Assets;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Applications;

public class AplicationForCreationDto
{
    public long UserId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MinLength(4), MaxLength(32)]
    public string Title { get; set; }
    public string Description { get; set; }
    public string MotivationLetter { get; set; }
    public ApplicationAsset Asset { get; set; }
}