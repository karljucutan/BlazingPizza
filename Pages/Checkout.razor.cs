using BlazingPizza.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazingPizza.Pages
{
    public partial class Checkout
    {
        private Order Order => OrderState.Order; // private access modifier by default if not explicitly indicated.
        bool isError = false;
        private EditContext editContext;

        protected override void OnInitialized()
        {
            editContext = new(Order.DeliveryAddress);
            editContext.OnFieldChanged += HandleFieldChanged;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            isError = !editContext.Validate();
            StateHasChanged();
        }

        private async Task PlaceOrder() // private access modifier by default if not explicitly indicated.
        {
            var response = await HttpClient.PostAsJsonAsync(NavigationManager.BaseUri + "orders", OrderState.Order);
            var newOrderId = await response.Content.ReadFromJsonAsync<int>();
            OrderState.ResetOrder();
            NavigationManager.NavigateTo($"myorders/{newOrderId}");
        }

        protected void ShowError()
        {
            isError = true;
        }

        public void Dispose()
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}