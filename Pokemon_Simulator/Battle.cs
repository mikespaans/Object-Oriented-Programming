//Roundwinner laten staan
//meerdere rondes in een battle stoppen

namespace Pokemon;


// Create a Battle class that contains all the gameplay needed for the pokemon battle simulator.
    //     A battle is fought between two trainers and their pokemon.
    //     A battle is fought in rounds between two pokemon.
    //     The trainers throw a random pokeball from their belt until all their pokeballs are used.
    //     A round is fought in a rock-paper-scissors style:
    // Charmander (fire) wins from Bulbasuar (leaf).
    // Bulbasuar (leaf) wins from Squirtle (water).
    // Squirtle (water) wins from Charmander (fire).
    // A round can have three outcomes: the first pokemon wins, the second pokemon wins or its a draw.
    //     The pokemon who wins a round stays in the arena and the losing pokemon gets returned to their pokeball. If it's a draw, then the winner of the previous round is returned to their pokeball.
    //     The battle can have three outcomes: trainer 1 wins, trainer 2 wins or its a draw.


//single battle
public class Battle
{

    private Trainer PokemonTrainer1;
    private Trainer PokemonTrainer2;
    
    //constructor
    public Battle(Trainer PokemonTrainer1, Trainer PokemonTrainer2)
    {
        this.PokemonTrainer1 = PokemonTrainer1;
        this.PokemonTrainer2 = PokemonTrainer2;
    }

    //Simulates a round of battle
    
    public Pokeball SimulateRound( Pokeball PreviousRoundWinner = null)
    {
        Console.WriteLine($"{PreviousRoundWinner} won the previous round");
        
        //get a random pokeball from each trainer 
        Pokeball Pokeball1 = PokemonTrainer1.GetRandomPokeball(Pokeball.PokeballsBelt);
        Pokeball Pokeball2 = PokemonTrainer2.GetRandomPokeball(Pokeball.PokeballsBelt2);
        
        //determine the winner of the round
        
        var RoundWinner = DetermineWinner(Pokeball1, Pokeball2);
        if (RoundWinner != null)
        {
            Console.WriteLine($"Round winner : {RoundWinner.Pokemon.Name}");
        }
        
        
        
        //return the winner
        return RoundWinner;
    }
    
    //determine the winner of the round
    private Pokeball DetermineWinner(Pokeball PokeballTrainer1, Pokeball PokeballTrainer2)
    {
        //get pokemn types
        string StrengthPokemon1 = PokeballTrainer1.Pokemon.Strength;
        string StrengthPokemon2 = PokeballTrainer2.Pokemon.Strength;
        
        //determine winner based on pokemon types
        if (StrengthPokemon1 == "Fire" && StrengthPokemon2 == "Leaf")
        {
            return PokeballTrainer1;
        }
        else if (StrengthPokemon1 == "Leaf" && StrengthPokemon2 == "Water")
        {
            return PokeballTrainer1;
        }
        else if (StrengthPokemon1 == "Water" && StrengthPokemon2 == "Fire")
        {
            return PokeballTrainer1;
        }
        else if (StrengthPokemon2 == "Fire" && StrengthPokemon1 == "Leaf")
        {
            return PokeballTrainer2;
        }
        else if (StrengthPokemon2 == "Leaf" && StrengthPokemon1 == "Water")
        {
            return PokeballTrainer2;
        }
        else if (StrengthPokemon2 == "Water" && StrengthPokemon1 == "Fire")
        {
            return PokeballTrainer2;
        }
        else
        {
            // if the round is a draw, return the winner of the previous round
            return null;
            Console.WriteLine("draw");
        }
    }
    
    
    //Check if the battle is over
    public bool IsBattleOver()
    {
        //check if all pokeballs are used
        if (Pokeball.PokeballsBelt.Count == 0 || Pokeball.PokeballsBelt2.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    //meerdere rondes maken
    //Simulate a battle
    public void SimulateBattle()
    {
        //simulate first round without a previous round winner
        var RoundWinner = SimulateRound();
        
        //loop until the battle is over
        while (!IsBattleOver())
        {
            //simulate a round
            RoundWinner = SimulateRound(RoundWinner);
        }
        Console.WriteLine("battle ended");
    }
    
    
}

//meerdere rondes worden hier bijgehouden
public class Arena
{
    
}