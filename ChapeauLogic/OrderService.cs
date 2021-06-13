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

        public void UpdateOrderPreparing(OrderItem order)
        {
            orderDAO.UpdateOrderPreparing(order);
        }

        public void UpdateOrderReady(OrderItem order)
        {
            orderDAO.UpdateOrderReady(order);

        }
        public List<Order> GetAllKitchen()
        { 

            return orderDAO.GetAllOrdersKitchen();
        }

        public List<Order> GetAllBar()
        {
            return orderDAO.GetAllOrdersBar();
        }

    #region Alex's part

        public bool ExecuteOrderPayment(Order order)
        {
            try
            {
                // in real life - we need to perform interaction with PaymentSystem here to get payment processed by bank and confirmed
                // if(PerformBankTransaction() == false) throw new Exception("Payment refused by bank");
                orderDAO.SaveOrderPaymentInfo(order);
                orderDAO.UpdateOrderDetails(order,/*newStatus=*/true);
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public Order GetOrderForTableByTableID(int tableID)
        {
            return orderDAO.GetOrderForTableByTableID(tableID);
        }

    #endregion Alex's part

        // Tommy Service parts
        public void SendOrder(Order order)
        {
            order.OrderID = orderDAO.AddOrder(order);
            orderDAO.AddOrderItem(order);
        }

        public int GroupOrderItem(Order order, int amount)
        {
            foreach (OrderItem orderorderItem in order.OrderItems)
            {
                    return orderorderItem.Quantity += amount; // To do in logic layer.
            }
            return 1;
        }
    }
}
