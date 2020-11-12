using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Exceptions;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services.OrderServices;
using PizzaStore.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class PlaceOrderCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CartViewModel _cartViewModel;

        private readonly IPlaceOrderService _placeOrderService;

        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public PlaceOrderCommand(CartViewModel cartViewModel,
                                 IPlaceOrderService placeOrderService)
        {
            _cartViewModel = cartViewModel;
            _placeOrderService = placeOrderService;
            IsExecuting = false;
        }

        public bool CanExecute(object parameter)
        {
            if (_cartViewModel.Items.Count > 0 && IsExecuting == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            _cartViewModel.StatusMessage = string.Empty;
            _cartViewModel.ErrorMessage = string.Empty;

            try
            {
                var address = new Address(_cartViewModel.Street,
                                          _cartViewModel.Building,
                                          _cartViewModel.Unit);

                var order = new Order(_cartViewModel.Remarks,
                                      0,
                                      _cartViewModel.TotalPrice,
                                      _cartViewModel.User,
                                      address,
                                      _cartViewModel.Items);

                await _placeOrderService.PlaceOrder(order);

                _cartViewModel.StatusMessage = "Order has been placed! Check your e-mail box to see order's details.";

                _cartViewModel.Items.Clear();
            }
            catch (DbUpdateException)
            {
                _cartViewModel.ErrorMessage = "There has an error during connection to database occured. Order cannot be placed.";
            }
            catch (CannotSendEmailException)
            {
                _cartViewModel.ErrorMessage = "Order has been placed, but there was a problem with sending e-mail confirmation.";
            }

            _cartViewModel.TotalPriceChanged();

            IsExecuting = false;
        }
    }
}