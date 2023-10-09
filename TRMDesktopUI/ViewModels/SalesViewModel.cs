using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get
            {
                return _products;
            }

            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal
        {
            get
            {
                //TODO - replace with calculation:
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                //TODO - replace with calculation:
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                //TODO - replace with calculation:
                return "$0.00";
            }
        }


        public void AddToCart()
        {

        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected AND there is an item quantity
                if (false)
                {
                    output = true;
                }

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                if (false)
                {
                    output = true;
                }

                return output;
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }


        public void CheckOut()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //Make sure something is in cart
                if (false)
                {
                    output = true;
                }

                return output;
            }
        }


    }
}
