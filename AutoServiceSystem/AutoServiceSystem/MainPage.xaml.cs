using System;
using Xamarin.Forms;

namespace AutoServiceSystem
{
    public partial class MainPage : ContentPage
    {
        private float totalAmount;
        private string customerName;
        private string phoneNumber;
        private Label basketSummaryLabel;
        public MainPage()
        {
            InitializeComponent();
            InitializeServices();
            InitializeBasket();

            clearBasketButton.Clicked += (sender, e) => ClearBasket();
            makeOrderButton.Clicked += (sender, e) => MakeOrder();
            basketSummaryLabel = new Label { TextColor = Color.Black };
            basketStackLayout.Children.Add(basketSummaryLabel);
        }

        private void InitializeServices()
        {
            var diagnosticService = new Service { Name = "Диагностика", Price = 10000 };
            var oilChangeService = new Service { Name = "Замена масла", Price = 500 };
            var tireChangeService = new Service { Name = "Смена резины", Price = 2000 };
            var filterChangeService = new Service { Name = "Замена фильтра", Price = 8000 };

            diagnosticServiceButton.Text = diagnosticService.Name;
            diagnosticServiceButton.Clicked += (sender, e) => AddToBasket(diagnosticService);

            oilChangeServiceButton.Text = oilChangeService.Name;
            oilChangeServiceButton.Clicked += (sender, e) => AddToBasket(oilChangeService);

            tireChangeServiceButton.Text = tireChangeService.Name;
            tireChangeServiceButton.Clicked += (sender, e) => AddToBasket(tireChangeService);

            filterChangeServiceButton.Text = filterChangeService.Name;
            filterChangeServiceButton.Clicked += (sender, e) => AddToBasket(filterChangeService);
        }

        private void InitializeBasket()
        {
            customerNameEntry.TextChanged += (sender, e) => customerName = e.NewTextValue;
            phoneNumberEntry.TextChanged += (sender, e) => phoneNumber = e.NewTextValue;
        }

        private void UpdateBasketSummary()
        {

        }

        private void AddToBasket(Service service)
        {
            // Update the totalAmount with the new service price
            totalAmount += service.Price;

            // Update the totalAmountLabel to display the updated totalAmount
            totalAmountLabel.Text = $"Общая сумма: {totalAmount} руб.";

            // Create labels for service details
            var serviceLabel = new Label { Text = service.Name, TextColor = Color.White };
            var priceLabel = new Label { Text = $"Цена: {service.Price} руб.", TextColor = Color.White };

            // Create a layout for the service details
            StackLayout serviceLayout = new StackLayout
            {
                BackgroundColor = Color.Green,
                Padding = new Thickness(10),
                Margin = new Thickness(0, 0, 0, 10),
                Children = { serviceLabel, priceLabel }
            };

            basketStackLayout.Children.Add(serviceLayout);


            UpdateBasketSummary();
        }



        private void ClearBasket()
        {
            basketStackLayout.Children.Clear();
            totalAmount = 0;
            totalAmountLabel.Text = $"Общая сумма: {totalAmount} руб.";
        }

        private void MakeOrder()
        {
            if (Navigation != null)
            {
                // Navigate to the OrderConfirmationPage when the "Make an Order" button is clicked
                Navigation.PushAsync(new OrderConfirmationPage());
            }
        }
    }

    public class Service
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
}