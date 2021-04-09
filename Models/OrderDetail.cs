using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketReservation.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } //PK
        public int ProductId { get; set; } //FK
        public int OrderId { get; set; } //FK
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Order Order { get; set; }
        public Movies movies { get; set; }


    }
}
