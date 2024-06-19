using BlazingPizza.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazingPizza.Pages
{
    public partial class Checkout
    {
        private Order Order => OrderState.Order; // private access modifier by default if not explicitly indicated.
        private bool isSubmitting;
        bool isError = false;

        private async Task PlaceOrder() // private access modifier by default if not explicitly indicated.
        {
            isError = false;
            isSubmitting = true;
            var response = await HttpClient.PostAsJsonAsync(
                $"{NavigationManager.BaseUri}orders", OrderState.Order);
            var newOrderId = await response.Content.ReadFromJsonAsync<int>();
            OrderState.ResetOrder();
            NavigationManager.NavigateTo($"myorders/{newOrderId}");
        }

        protected void ShowError()
        {
            isError = true;
        }
    }
}