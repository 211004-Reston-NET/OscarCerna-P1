using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Models
{
    public class Customer
    {
        private int customerId;
        private string name;
        private string address;
        private string email;
        private string phone;
        private List<Orders> orders = new List<Orders>();

        public int CustomerId { get; set; }
        public string Name
        {
            get { return name; }
            set 
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    throw new Exception("Invaild Name Format!");
                }
                name = value;
            }
        }
        public string Address 
        {
            get { return address; }
            set 
            {
                if (!Regex.IsMatch(value, @"\d{1,6}\s(?:[A-Za-z0-9#]+\s){0,7}(?:[A-Za-z0-9#]+,)\s*(?:[A-Za-z]+\s){0,3}(?:[A-Za-z]+,)\s*[A-Z]{2}\s*\d{5}"))
                {
                    throw new Exception("Invaild Address Format!");
                }
                address = value;
            }
        }

        public object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public string Email         
        {
            get { return email; }
            set 
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"))
                {
                    throw new Exception("Invaild E-Mail Address!");
                }
                email = value;
            }
        } 
        public string Phone         
        {
            get { return phone; }
            set 
            {
                if (!Regex.IsMatch(value, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
                {
                    throw new Exception("Invaild Phone Number Format!");
                }
                phone = value;
            }       
        }
        public List<Orders> Orders { get{return orders;} set {orders = value;} }  
         
        public override string ToString()
        {
            return $"CustomerID: {CustomerId}\n Name: {Name}\nAddress: {Address}\nE-mail: {Email}\nPhone: {Phone}";
        }
    }
}