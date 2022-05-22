﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeCourse.Sevices.Basket.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDto> Items { get; set; }
        public decimal TotalPrice
        {
            get => Items.Sum(x => x.Price * x.Quantity);
        }

        public BasketDto()
        {
        }
    }
}

