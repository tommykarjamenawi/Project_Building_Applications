﻿using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class OrderService
    {
        private OrderDAO orderDAO;

        public OrderService()
        {
            orderDAO = new OrderDAO();
        }

      
        public List<Order> GetAllOrders()
        {
            List<Order> orders = orderDAO.GetAllOrders();
            return orders;
        }
    }
}