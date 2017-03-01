using System.ComponentModel.DataAnnotations;

namespace MailUI.Model
{
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Skype { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
