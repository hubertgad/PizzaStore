using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Exceptions;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services;
using PizzaStore.Domain.Services.EmailServices;
using PizzaStore.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class PlaceOrderCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CartViewModel _cartViewModel;

        private readonly IOrderDataService _orderService;

        private readonly IEmailService _emailService;

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
                                 IOrderDataService orderService,
                                 IEmailService emailService)
        {
            _cartViewModel = cartViewModel;
            _orderService = orderService;
            _emailService = emailService;
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
                address = await _orderService.ValidateAddress(address);

                var order = new Order(_cartViewModel.Remarks,
                                      0,
                                      _cartViewModel.TotalPrice,
                                      _cartViewModel.User,
                                      address,
                                      _cartViewModel.Items);

                await _orderService.CreateAsync(order);

                order = await _orderService.GetAsync(order.Id);
                await _emailService.SendAsync(order);

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