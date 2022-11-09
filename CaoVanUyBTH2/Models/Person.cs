using System.ComponentModel.DataAnnotations;
namespace CaoVanUyBTH2.Models
{
    public class Person
    {
        [Key]
        public string? PerID { get; set; }
        public string? PerName { get; set; }
        public string? Address { get; set; }
    }
}