﻿namespace ImaginaryWebshop.Data.Dtos
{
    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
