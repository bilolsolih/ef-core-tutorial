using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public class PizzaContext(DbContextOptions<PizzaContext> options) : DbContext(options)
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
}