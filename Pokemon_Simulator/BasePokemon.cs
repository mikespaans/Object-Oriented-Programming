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

