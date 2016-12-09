using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table("Degrees")]
    public class Degrees
    {
        [Key]
        public int DegreeID { get; set; }
        public string Name { get; set; }
        public string Coordinator { get; set; }
        public string Title { get; set; }
        public string Office { get; set; }
        public string PhDEducation { get; set; }
        public string MastersEducation { get; set; }
        public string BachelorsEducation { get; set; }
        public string CoordinatorPicture { get; set; }
    }
}