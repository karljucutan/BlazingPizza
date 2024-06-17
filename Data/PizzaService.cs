namespace BlazingPizza.Data
{
    public class PizzaService
    {
        private List<Pizza> pizzas = new();

        public async Task<List<Pizza>> GetPizzasAsync()
        {
            
            // Call your data access technology here
            pizzas.AddRange(new List<Pizza>
            {
                new Pizza { PizzaId = 1, Name = "Hawaian", Description = "Descrip", Price = 12.5m, Vegan = false, Vegetarian = false}

            });

            // Introduce a 5-second delay
            await Task.Delay(5000); // 5000 milliseconds = 5 seconds

            return pizzas;
        }

        public Task<List<Pizza>> GetPizzas()
        {

            // Call your data access technology here
            pizzas.AddRange(new List<Pizza>
            {
                new Pizza { PizzaId = 1, Name = "Hawaian", Description = "Descrip", Price = 12.5m, Vegan = false, Vegetarian = false}

            });

            // Introduce a 5-second delay
            Task.Delay(5000); // 5000 milliseconds = 5 seconds

            return Task.FromResult(pizzas);
        }
    }
}
