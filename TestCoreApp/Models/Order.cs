﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestCoreApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public String ClientName { get; set; }

        [Required]
        public string ClientPhone { get; set; }

        [Required]
        public string ClientAddress { get; set; }

        



        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Food")]
        [ForeignKey("Food")]
        public int FoodId { get; set; }


        public Food? Food { get; set; }


    }
}

