using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class WrapperViewModel
    {
        public User LoggedInUser { get; set; }
        public User OneUser { get; set; }
        public List<User> AllUsers { get; set; }
        public Wedding OneWedding { get; set; }
        public List<Wedding> AllWeddings { get; set; }
    }
}