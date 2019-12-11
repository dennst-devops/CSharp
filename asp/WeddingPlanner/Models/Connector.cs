using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models
{
    public class Connector
    {
        public int ConnectorId { get; set; }
        public int UserId { get; set; }
        public int WeddingId { get; set; }
        public User User { get; set; }
        public Wedding Wedding { get; set; }
    }
}