﻿
namespace Pokemon;

public class Squirtle : BasePokemon
{
    public Squirtle(string Name, Strength_Weakness Strength, Strength_Weakness Weakness, int PokemonNumber, string Type) : base(Name, Strength, Weakness, PokemonNumber, Type)
    {
        
    }

    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }
}