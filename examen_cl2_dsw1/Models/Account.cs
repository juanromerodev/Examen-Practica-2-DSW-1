using System.ComponentModel.DataAnnotations;

namespace examen_cl2_dsw1.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public bool Active { get; set; }
    }
}
