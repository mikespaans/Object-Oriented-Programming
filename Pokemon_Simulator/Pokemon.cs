using System.Collections.Generic;
using System;

namespace Pokemon;

public abstract class BasePokemon
{
    public string Name { get; set; }
    public string Strength { get; set; }
    public string Weakness { get; set; }
    public string Type { get; set; }

    public int PokemonNumber { get; set; }

    
    
    public abstract void BattleCry(string Name);
    
    //

}

public class Squirtle : BasePokemon
{
    public Squirtle(string Name, string Strength, string Weakness, int PokemonNumber, string Type)
    {
        this.Name = Name;
        this.Strength = Strength;
        this.Weakness = Weakness;
        this.PokemonNumber = PokemonNumber;
        this.Type = Type;
    }
    
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }
}

public class Bulbasaur : BasePokemon
{
    public Bulbasaur(string Name, string Strength, string Weakness, int PokemonNumber, string Type)
    {
        this.Name = Name;
        this.Strength = Strength;
        this.Weakness = Weakness;
        this.PokemonNumber = PokemonNumber;
        this.Type = Type;
    }
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }
}


public class Charmander : BasePokemon
{
    public Charmander(string Name, string Strength, string Weakness, int PokemonNumber, string Type)
    {
        this.Name = Name;
        this.Strength = Strength;
        this.Weakness = Weakness;
        this.PokemonNumber = PokemonNumber;
        this.Type = Type;
    }
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }

    
}


public class Pokeball
    {

    public static List<Pokeball> PokeballsBelt = new List<Pokeball>();
    public static List<Pokeball> PokeballsBelt2 = new List<Pokeball>();



    public Boolean IsFull { get; set; }
    public int PokeballNumber { get; set; }
    public int TrainerNumber { get; set; }

    // public Charmander charmander { get; set; }
    public BasePokemon Pokemon { get; set; }

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
    public string Name { get; set; }

    public Trainer(string Name, List<Pokeball> PokeballList, int TrainerNumber)
    {
        this.Name = Name;
        FillBelt(PokeballList, TrainerNumber);
    }

    public static void FillBelt(List<Pokeball> PokeballList, int TrainerNumber)
    {
        for (int i = 0; i < 6; i++)
        {
            if (i <= 1)
            {
                var charmander = new Charmander("Charmander", "Fire", "Water", i, "charmander");
                var Pokeball = new Pokeball(true, i, charmander, PokeballList, TrainerNumber);
            }
            else if (i <= 3)
            {
                var squirtle = new Squirtle("Squirtle", "Water", "Leaf", i, "squirtle");
                var Pokeball = new Pokeball(true, i, squirtle, PokeballList, TrainerNumber);
            }
            else
            {
                var bulbasaur = new Bulbasaur("Bulbasaur", "Leaf", "Fire", i, "bulbasaur");
                var Pokeball = new Pokeball(true, i, bulbasaur, PokeballList, TrainerNumber);
            }
            
        }
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
    public Pokeball GetRandomPokeball(List<Pokeball> PokeballList)
    {
        
        //Random Pokeball gets selected
        Random random = new Random();
        int RandomIndex = random.Next(PokeballList.Count);
        var RandomPokeball = PokeballList[RandomIndex];
        // Console.WriteLine(RandomPokeball.Pokemon.Name);
        
        //Pokeball gets removed from the belt
        PokeballList.Remove(RandomPokeball);
        
        //Pokemon gets released
        RandomPokeball.IsFull = false;
        
        //random Pokeball gets returned
        return RandomPokeball;
    }



}
