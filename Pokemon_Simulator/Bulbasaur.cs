namespace Pokemon;

public class Bulbasaur : BasePokemon
{
    public Bulbasaur(string Name, Strength_Weakness Strength, Strength_Weakness Weakness, int PokemonNumber, string Type) : base(Name, Strength, Weakness, PokemonNumber, Type)
    {
        
    }
    public override void BattleCry(string Name)
    {
        Console.WriteLine($"{Name}!!!!");
    }
}