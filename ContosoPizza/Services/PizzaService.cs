using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService(PizzaContext context)
{
    public IEnumerable<Pizza> GetAll()
    {
        return context.Pizzas.AsNoTracking().ToList();
    }

    public Pizza? GetById(int id)
    {
        return context.Pizzas.AsNoTracking()
                      .Include(p => p.Toppings).Include(p => p.Sauce).SingleOrDefault(p => p.Id == id);
    }

    public Pizza? Create(Pizza newPizza)
    {
        context.Pizzas.Add(newPizza);
        context.SaveChanges();

        return newPizza;
    }

    public void AddTopping(int pizzaId, int toppingId)
    {
        Pizza? pizza = context.Pizzas.Find(pizzaId);
        Topping? topping = context.Toppings.Find(toppingId);

        if (pizza == null || topping == null)
        {
            throw new InvalidOperationException("Pizza or Topping does not exist");
        }

        if (pizza.Toppings is null)
        {
            pizza.Toppings = new List<Topping>();
        }

        pizza.Toppings.Add(topping);
        context.SaveChanges();
    }

    public void UpdateSauce(int PizzaId, int SauceId)
    {
        var pizza = context.Pizzas.Find(PizzaId);
        var sauce = context.Sauces.Find(SauceId);

        if (pizza == null || sauce == null)
        {
            throw new InvalidOperationException("Pizza or Sauce does not exist");
        }

        pizza.Sauce = sauce;
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var pizza = context.Pizzas.Find(id);
        if (pizza is not null)
        {
            context.Pizzas.Remove(pizza);
            context.SaveChanges();
        }
    }
}