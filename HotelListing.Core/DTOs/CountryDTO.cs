﻿using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.DTOs
{
    public class CountryDTO:CreateCountryDTO
    {
        public int Id { get; set; }
        public  IList<HotelDTO> Hotels { get; set; }
    }
        public class CreateCountryDTO
        {
            [Required]
            [StringLength(maximumLength: 50, ErrorMessage = "Country Name is Too Long")]
            public string Name { get; set; }
            [Required]
            [StringLength(maximumLength: 2, ErrorMessage = "Short Country Name Is Too Long")]
            public string ShortName { get; set; }
        }
    public class UpdateCountryDTO : CreateCountryDTO
    {
        public IList<HotelDTO> Hotels { get; set; }
    }
    
}