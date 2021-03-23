using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndLuncher
{
    //Interface representing the unimplemented connection to for exampel Klarna payment API in the PaymentIntegration class
    public interface IPaymentIntegration
    {
        bool SendOrderDataToPaymentApi(Orders order);
    }


    public class PaymentIntegration
    {
        private readonly IPaymentIntegration paymentIntegration;
        public bool paymentApproved { get; set; }
        public int orderId { get; set; }
        public PaymentIntegration(IPaymentIntegration payment)
        {
            paymentIntegration = payment;
        }


        public bool ValidatePayment(Orders incomingOrder)
        {
            orderId = incomingOrder.Id;
            //If payment service successfully verifies payment, order should be marked as handled.
            return paymentApproved = paymentIntegration.SendOrderDataToPaymentApi(incomingOrder);
        }
    }

    //A Fake class implementation of the PaymentService

    public class FakePaymentService : IPaymentIntegration
    {
        public bool SendOrderDataToPaymentApi(Orders unpaidOrder)
        {
            //Simulates that the PaymentService applies some logic to verify that the order could be paid by the user or not
            if (unpaidOrder.Id >= 1)
            {
                return true;
            }
            else { return false; }
        }
    }

}