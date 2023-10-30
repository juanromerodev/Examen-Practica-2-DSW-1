using System.ComponentModel.DataAnnotations;

namespace examen_cl2_dsw1.Models
{
    public class Account
    {
        [Key]
        private int Id { get; set; }
        private string? AccountNumber { get; set; }
        private decimal Amount { get; set; }
        private bool Active { get; set; }
    }
}
