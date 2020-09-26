namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string ThirdName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirthday { get; set; }

        [StringLength(12)]
        public string Number { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
    }
}
