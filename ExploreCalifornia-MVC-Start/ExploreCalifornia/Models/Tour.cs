using System;

namespace ExploreCalifornia.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public int Length { get; set; }
        public decimal Price { get; set; }        
        public string Rating { get; set; }
        public bool IncludesMeals { get; set; }
    }
}