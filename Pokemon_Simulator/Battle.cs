﻿using System.Threading;

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

    public Pokeball SimulateRound( Trainer trainer, Trainer trainer2 ,Pokeball PreviousRoundWinner = null)
    {
        Pokeball? Pokeball1 = null;
        Pokeball? Pokeball2 = null;
        //get a random pokeball from each trainer 
        // Console.WriteLine();

        if (PreviousRoundWinner != null)
        {
            if (PreviousRoundWinner.TrainerNumber == 1)
            {
                Pokeball1 = PreviousRoundWinner;
            }
            else
            {
                Pokeball1 = PokemonTrainer1.GetRandomPokeball(trainer.PokeballsBelt, trainer.UsedPokeballsList);

            }

            if (PreviousRoundWinner.TrainerNumber == 2)
            {
                Pokeball2 = PreviousRoundWinner;

            }
            else
            {
                Pokeball2 = PokemonTrainer2.GetRandomPokeball(trainer2.PokeballsBelt, trainer2.UsedPokeballsList);

            }
        }
        else
        {
            Pokeball1 = PokemonTrainer1.GetRandomPokeball(trainer.PokeballsBelt, trainer.UsedPokeballsList);
            Pokeball2 = PokemonTrainer2.GetRandomPokeball(trainer2.PokeballsBelt, trainer2.UsedPokeballsList);
        }
        

        //determine the winner of the round
        Console.WriteLine($"Trainer {Pokeball1.TrainerNumber} throws {Pokeball1.Pokemon.Name} and trainer {Pokeball2.TrainerNumber} throws {Pokeball2.Pokemon.Name}");
        var RoundWinner = DetermineWinner(Pokeball1, Pokeball2, PreviousRoundWinner);

        // return the loser of the round to their pokeball
        if (RoundWinner == Pokeball1)
        {
            Pokeball2.IsFull = true;
            Pokeball2.Pokemon.IsAlive = false;
        } 
        else if (RoundWinner == Pokeball2)
        {
            Pokeball1.IsFull = true;
            Pokeball1.Pokemon.IsAlive = false;
        }



        //return the winner
        return RoundWinner;
    }
    
    //determine the winner of the round
    private Pokeball DetermineWinner(Pokeball PokeballTrainer1, Pokeball PokeballTrainer2, Pokeball PreviousRoundWinner)
    {
        //get pokemn types
        Strength_Weakness StrengthPokemon1 = PokeballTrainer1.Pokemon.Strength;
        Strength_Weakness StrengthPokemon2 = PokeballTrainer2.Pokemon.Strength;
        
        //determine winner based on pokemon strength
        if (StrengthPokemon1 == Strength_Weakness.Fire && StrengthPokemon2 == Strength_Weakness.Leaf)
        {
            return PokeballTrainer1;
        }
        else if (StrengthPokemon1 == Strength_Weakness.Leaf && StrengthPokemon2 == Strength_Weakness.Water)
        {
            return PokeballTrainer1;
        }
        else if (StrengthPokemon1 == Strength_Weakness.Water && StrengthPokemon2 == Strength_Weakness.Fire)
        {
            return PokeballTrainer1;
        }
        else if (StrengthPokemon2 == Strength_Weakness.Fire && StrengthPokemon1 == Strength_Weakness.Leaf)
        {
            return PokeballTrainer2;
        }
        else if (StrengthPokemon2 == Strength_Weakness.Leaf && StrengthPokemon1 == Strength_Weakness.Water)
        {
            return PokeballTrainer2;
        }
        else if (StrengthPokemon2 == Strength_Weakness.Water && StrengthPokemon1 == Strength_Weakness.Fire)
        {
            return PokeballTrainer2;
        }
        //draw
        else
        {
            
            // if the round is a draw, return the winner of the previous round
            if (PreviousRoundWinner != null)
            {
                return PreviousRoundWinner;
            }
            else
            {
                return PokeballTrainer1;
            }
            
            
            
        }
    }
    
    
    //Check if the battle is over
    public bool IsBattleOver(Trainer trainer, Trainer trainer2)
    {
        //check if all pokeballs are used
        if (trainer.PokeballsBelt.Count == 0 || trainer2.PokeballsBelt.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
