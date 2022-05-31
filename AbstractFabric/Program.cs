using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabric
{
    public interface PizzaIngredientFactory
    {
        public Dough createDough();
        public Sause createSause();
        public Cheese createCheese();
        public Veggies[] createVeggies();
        public Clams createClams();
    }

    public class NyPizzaIngredientsFactory : PizzaIngredientFactory
    {
        public Dough createDough()
        {
            return new ThinCrustDough();
        }

        public Sause createSause()
        {
            return new MarinaraSause();
        }
    
    
        public Clams createClams()
        {
            return new FreshClams();
        }

        public Cheese createCheese()
        {
            return new Cheese();
        }

        public Veggies[] createVeggies()
        {
           Veggies[] veggies = { new Tomato()};
            return veggies;
        }
    }

public class ChicagoPizzaIngredientsFactory : PizzaIngredientFactory
{
    public Dough createDough()
    {
        return new ThickCrustDough();
    }

    public Sause createSause()
    {
        return new PlumTomatoSause();
    }

    
    public Clams createClams()
    {
        return new FrozenClams();
    }

    public Cheese createCheese()
    {
            return new Cheese();
    }

    public Veggies[] createVeggies()
    {
            Veggies[] veggies = { new Tomato() };
            return veggies;
    }
}


public abstract class Pizza
{
    String name;
    Dough dough;
    Sause sause;
    Clams clams;

    public abstract void prepare();

    public void bake()
    {
            Console.WriteLine("baking pizza");
    }

    public void cut()
    {
            Console.WriteLine("Cuting pizza");
    }

    public void box()
    {
            Console.WriteLine("Boxing pizza");
    }

}

public class CheesePizza : Pizza
{
    private PizzaIngredientFactory ingredientFactory;
    private Dough dough;
    private Sause sause;
    private Cheese cheese;

    public CheesePizza(PizzaIngredientFactory ingredientFactory)
    {
        this.ingredientFactory = ingredientFactory;
    }

    public override void prepare()
    {
        this.dough = ingredientFactory.createDough();
        this.sause = ingredientFactory.createSause();
        this.cheese = ingredientFactory.createCheese();
    }
}

public class PepperoniPizza : Pizza
{
    private PizzaIngredientFactory ingredientFactory;
    private Dough dough;
    private Sause sause;
    private Cheese cheese;
    private Clams clams;


    public PepperoniPizza(PizzaIngredientFactory ingredientFactory)
    {
        this.ingredientFactory = ingredientFactory;
    }

    public override void prepare()
    {
        this.dough = ingredientFactory.createDough();
        this.sause = ingredientFactory.createSause();
        this.cheese = ingredientFactory.createCheese();
        this.clams = ingredientFactory.createClams();
    }
}

public abstract class PizzaStore
{
    public Pizza orderPizza(String type)
    {
        Pizza pizza;

        pizza = createPizza(type);


        pizza.prepare();
        pizza.bake();
        pizza.cut();
        pizza.box();
        return pizza;
    }


    public abstract Pizza createPizza(String type);

}



public class NyPizzaStore : PizzaStore
{

    
    public override Pizza createPizza(String type) {
        Pizza piza = null;
        PizzaIngredientFactory ingredientFactory = new NyPizzaIngredientsFactory();

        if (type.Equals("cheese"))
        {
            piza = new CheesePizza(ingredientFactory);
        }
        else if (type.Equals("pepperoni"))
        {
            piza = new PepperoniPizza(ingredientFactory);
        }
        return piza;
    }

}

public class ChicagoPizzaStore : PizzaStore
{

    public override Pizza createPizza(String type) {
        Pizza piza = null;
        PizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientsFactory();

        if (type.Equals("cheese"))
        {
            piza = new CheesePizza(ingredientFactory);
        }
        
        else if (type.Equals("pepperoni"))
        {
            piza = new PepperoniPizza(ingredientFactory);
        }
        return piza;
    }

}

public class Test
    {

        static void Main(string[] args) {
            ChicagoPizzaStore chicagoPizzaStore = new ChicagoPizzaStore();
            chicagoPizzaStore.orderPizza("cheese");
            chicagoPizzaStore.orderPizza("pepperoni");
        
        }
    }
}
