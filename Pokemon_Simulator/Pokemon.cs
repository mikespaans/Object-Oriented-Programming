using System.Collections.Generic;
using System;

namespace Pokemon;



public abstract class BasePokemon
{
    // once the value is set in the constructor, it cannot be changed
    public readonly string Name;
    public readonly Strength_Weakness Strength;
    public readonly Strength_Weakness Weakness;
    public readonly string Type;

    public readonly int PokemonNumber;
    
    public bool IsAlive { get; set; }
    
    
    public BasePokemon(string name, Strength_Weakness strength, Strength_Weakness weakness, int pokemonNumber, string type, bool isAlive = true)
    {
        Name = name;
        Strength = strength;
        Weakness = weakness;
        PokemonNumber = pokemonNumber;
        Type = type;
        IsAlive = isAlive;
    }
    
    
    public abstract void BattleCry(string Name);
    
    //

}

public class Squirtle : BasePokemon
{
    public Squirtle(string Name, Strength_Weakness Strength, Strength_Weakness Weakness, int PokemonNumber, string Type) : base(Name, Strength, Weakness, PokemonNumber, Type)
    {
        // this.Name = Name;
        // this.Strength = Strength;
        // this.Weakness = Weakness;
        // this.PokemonNumber = PokemonNumber;
        // this.Type = Type;
    }
    
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }
}

public class Bulbasaur : BasePokemon
{
    public Bulbasaur(string Name, Strength_Weakness Strength, Strength_Weakness Weakness, int PokemonNumber, string Type) : base(Name, Strength, Weakness, PokemonNumber, Type)
    {
        // this.Name = Name;
        // this.Strength = Strength;
        // this.Weakness = Weakness;
        // this.PokemonNumber = PokemonNumber;
        // this.Type = Type;
    }
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }
}


public class Charmander : BasePokemon
{
    public Charmander(string Name, Strength_Weakness Strength, Strength_Weakness Weakness, int PokemonNumber, string Type) : base(Name, Strength, Weakness, PokemonNumber, Type)
    {
        // this.Name = Name;
        // this.Strength = Strength;
        // this.Weakness = Weakness;
        // this.PokemonNumber = PokemonNumber;
        // this.Type = Type;
    }
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }

    
}


public class Pokeball
    {

    // public static List<Pokeball> PokeballsBelt = new List<Pokeball>();
    // public static List<Pokeball> PokeballsBelt2 = new List<Pokeball>();
    //
    // public static List<Pokeball> UsedPokeballsList = new List<Pokeball>();
    // public static List<Pokeball> UsedPokeballsList2 = new List<Pokeball>();



    public Boolean IsFull { get; set; }
    public int PokeballNumber { get; set; }
    public int TrainerNumber { get; set; }

    // public Charmander charmander { get; set; }
    public BasePokemon Pokemon { get; }

        public Pokeball (Boolean IsFull, int PokeballNumber, BasePokemon Pokemon, List<Pokeball> PokeBallsList, int TrainerNumber)
            {
            this.IsFull = IsFull;
            this.PokeballNumber = PokeballNumber;
            this.Pokemon = Pokemon;
            this.TrainerNumber = TrainerNumber;
            

            PokeBallsList.Add(this);
            
                    
            }
            

            public static void Throw(int PokeballNumber, List<Pokeball> PokeballList)
            {
                var PokeBall = PokeballList[PokeballNumber];
                //charmander gets released
                PokeBall.IsFull = false;
                
                
               // return PokeballNumber;
            }

            public static void Return(int PokeballNumber, List<Pokeball> PokeballList)
            {
                //charmander gets returned
                var PokeBall = PokeballList[PokeballNumber];
                PokeBall.IsFull = true;
                
            }
            
        }


public class Trainer
{
    private static int MaxPokeballs = 6;
    public string Name { get; }
    
    public List<Pokeball> PokeballsBelt = new List<Pokeball>();
    // public static List<Pokeball> PokeballsBelt2 = new List<Pokeball>();
    
    public List<Pokeball> UsedPokeballsList = new List<Pokeball>();
    // public static List<Pokeball> UsedPokeballsList2 = new List<Pokeball>();

    public Trainer(string Name)
    {
        this.Name = Name;
        // FillBelt(PokeballList, TrainerNumber);
    }

    public void FillBelt(List<Pokeball> PokeballList, int TrainerNumber)
    {
        for (int i = 0; i < MaxPokeballs; i++)
        {
            // check if bellt is full
            if (PokeballList.Count >= 6)
            {
                throw new Exception("Cannot add more Pokeballs, Belt is full");
            }
            // add pokeballs to belt
            if (i <= 1)
            {
                var charmander = new Charmander("Charmander", Strength_Weakness.Fire, Strength_Weakness.Water, i, "charmander");
                var Pokeball = new Pokeball(true, i, charmander, PokeballList, TrainerNumber);
            }
            else if (i <= 3)
            {
                var squirtle = new Squirtle("Squirtle", Strength_Weakness.Water, Strength_Weakness.Leaf, i, "squirtle");
                var Pokeball = new Pokeball(true, i, squirtle, PokeballList, TrainerNumber);
            }
            else
            {
                var bulbasaur = new Bulbasaur("Bulbasaur", Strength_Weakness.Leaf, Strength_Weakness.Fire, i, "bulbasaur");
                var Pokeball = new Pokeball(true, i, bulbasaur, PokeballList, TrainerNumber);
            }
            
        }
    }
    
    public void ReturnPokeballsToBellt(Trainer trainer)
    {
        //Pokeballs get returned to the belt
        foreach (var Pokeball in trainer.UsedPokeballsList)
        {
            trainer.PokeballsBelt.Add(Pokeball);
        }
        trainer.UsedPokeballsList.Clear();
    }

    public void Throw(int PokeballNumber, List<Pokeball> PokeballList)
    {
        Pokeball.Throw(PokeballNumber, PokeballList);
    }

    public void Return(int PokeballNumber, List<Pokeball> PokeballList)
    {
        Pokeball.Return(PokeballNumber, PokeballList);
    }

    //gets a random pokeball from the belt
    public Pokeball GetRandomPokeball(List<Pokeball> PokeballList, List<Pokeball> UsedPokeballList)
    {
        
        //Random Pokeball gets selected
        Random random = new Random();
        int RandomIndex = random.Next(PokeballList.Count);
        var RandomPokeball = PokeballList[RandomIndex];
        // Console.WriteLine(RandomPokeball.Pokemon.Name);
        
        //Pokeball gets removed from the belt
        PokeballList.Remove(RandomPokeball);
        
        //Pokeball gets added to the used Pokeball list
        UsedPokeballList.Add(RandomPokeball);
        
        //Pokemon gets released
        RandomPokeball.IsFull = false;
        
        //random Pokeball gets returned
        return RandomPokeball;
    }
    
}
