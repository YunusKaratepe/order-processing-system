using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ybs_order_processing_system.Models
{
    [Table("USERS")]
    public partial class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Required]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        
        [Column("role")]
        [StringLength(20)]
        public string Role { get; set; }
    }
}
