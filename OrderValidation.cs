using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndLuncher
{
    //This class should compare incoming order with business logic, and set order handled status true/false based on result

    public class OrderValidation
    {
        public bool errorDetected { get; set; }
        private SortedDictionary<int, String> _errorMessages { get; set; }
        private SortedDictionary<int, String> _errorList { get; set; }

        private Orders orderSubject { get; set; }

        public OrderValidation()
        {
            _errorMessages = new SortedDictionary<int, string>
            {
                {100, "Error was detected and the order rejected" },
                { 101,"Delivery Date is earlier than OrderDate" },
                { 102,"Invalid Email Syntax, there is no @-symbol"},
                { 103, "The Payment of the order was not succesfull"},
                { 104, "No DishId or Dishes was found in order, the order must contain the dish item" },
                {200, "Exception Message" }
            };
            _errorList = new SortedDictionary<int, string>();
        }

        public SortedDictionary<int, string> ValidateOrder(Orders incomingOrder)
        {
            orderSubject = incomingOrder;
            CheckDishItem(orderSubject);
            CheckOrderHandled(orderSubject);
            CheckDeliveryDate(orderSubject);
            CheckContactMail(orderSubject);
            if (!errorDetected)
            {
                PaymentValidation(orderSubject);                
            }
            if (!errorDetected)
            {
                orderSubject.OrderHandled = true;

                return _errorList;
            }
            else
            {
                _errorList.Add(100, GetErrorMessage(100));
                return _errorList;
            }     
        }

        public bool PaymentValidation(Orders order)
        {
            PaymentIntegration paymentIntegration = new PaymentIntegration(new FakePaymentService());

            if (!paymentIntegration.ValidatePayment(order))
            {
                _errorList.Add(103, GetErrorMessage(103));
                
                return errorDetected = true;
            }
            return false;
        }


        public Orders CheckOrderHandled(Orders order)
        {
            if (order.OrderHandled)
            {
                order.OrderHandled = false;
            }

            return order;
        }

        public bool CheckDeliveryDate(Orders order)
        {
            TimeSpan differance = order.DeliveryDate - order.OrderDate;

            if (differance.Days < 0)
            {
                
                _errorList.Add(101,GetErrorMessage(101));
                return errorDetected = true;

            }
            else { return false; }
        }
        public bool CheckDishItem(Orders order)
        {         
            if (order.DishId <= 0)
            {
                _errorList.Add(104, GetErrorMessage(104));
                return errorDetected = true;
          }
            else { return false; }
        }

        public string GetErrorMessage(int errorCode)
        {
            string errorMessage = "";
            if (_errorMessages.TryGetValue(errorCode, out errorMessage)) {
                return errorMessage;
            }
            else { return $"Message for error code {errorCode} is not found"; }            
            
        }

        public bool CheckContactMail(Orders order)
        {
            try { 
            if (!order.ContactMail.Contains("@")) {

                _errorList.Add(102, GetErrorMessage(102));
                return errorDetected = true;
            }
            else
            {                
                return false;
            }
            }
            catch(NullReferenceException e) {
                Console.WriteLine("Error: " + e.Message);
                _errorList.Add(200, e.Message);
                
                return errorDetected = true;
                
            }
        }

        public string ErrorListToString()
        {
            string formatedError = "";
            foreach (var item in _errorList)
            {
                formatedError += "Error Code: " + item.Key + " Error Message: " + item.Value + "\n";
            }

            return formatedError;
        }

    }
}