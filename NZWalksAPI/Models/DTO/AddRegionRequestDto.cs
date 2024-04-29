﻿using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be of minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be of maximum of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name can be of maximum 100 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
