using System.Threading;

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

//meerdere rondes worden hier bijgehouden
public class Arena
{
    public static int BattlesFought = 0;
    public static int RoundsFought = 0;
    public static int BattlesDraw = 0;
    
    //create Dictionary
    public static Dictionary<Trainer, int> RoundDict = new Dictionary<Trainer, int>();
    public static Dictionary<Trainer, int> BattleDict = new Dictionary<Trainer, int>();

    private Battle Battle;

    public Arena(Trainer PokemonTrainer1, Trainer PokemonTrainer2, bool AddToDict)
    {
        RoundDict[PokemonTrainer1] = 0;
        RoundDict[PokemonTrainer2] = 0;

        if (AddToDict == true)
        {
            BattleDict.Add(PokemonTrainer1, 0);
            BattleDict.Add(PokemonTrainer2, 0);
            
        }
        
        
    }

    public Battle CreateBattle(Trainer PokemonTrainer1, Trainer PokemonTrainer2)
    {
        Battle = new Battle(PokemonTrainer1, PokemonTrainer2);
        return Battle;
    }
    
    //Simulate a battle
    public void SimulateBattle(Trainer PokemonTrainer1, Trainer PokemonTrainer2)
    {
        //simulate first round without a previous round winner
        var RoundWinner = Battle.SimulateRound(PokemonTrainer1, PokemonTrainer2);
        Console.WriteLine($"Trainer {RoundWinner.TrainerNumber} won the round");
        
        RoundsFought++;
        Console.WriteLine($"{RoundsFought} rounds fought");
        
        if (RoundWinner.TrainerNumber == 1)
        {
            RoundDict[PokemonTrainer1]++;
        }
        else
        {
            RoundDict[PokemonTrainer2]++;
        }
        
        //loop until the battle is over
        while (!Battle.IsBattleOver(PokemonTrainer1, PokemonTrainer2))
        {
            
            
            //simulate a round
            RoundWinner = Battle.SimulateRound(PokemonTrainer1, PokemonTrainer2, RoundWinner);

            // Console.WriteLine(RoundWinner.TrainerNumber);
            Console.WriteLine($"Trainer {RoundWinner.TrainerNumber} won the round");

            RoundsFought++;
            Console.WriteLine($"{RoundsFought} rounds fought");
            
            if (RoundWinner.TrainerNumber == 1)
            {
                RoundDict[PokemonTrainer1]++;
            }
            else
            {
                RoundDict[PokemonTrainer2]++;
            }
            
            Console.WriteLine($"Trainer 1 has won {RoundDict[PokemonTrainer1]} rounds and trainer 2 has won {RoundDict[PokemonTrainer2]} rounds");
            Thread.Sleep(3000);
            
            


        }
        Console.WriteLine("battle ended");
        
        //return the last pokemon to their pokeball
        RoundWinner.IsFull = true;
        
        //determine the winner of the battle
        BattlesFought++;
        if (RoundDict[PokemonTrainer1] > RoundDict[PokemonTrainer2])
        {
            Console.WriteLine($"Trainer 1 won the battle with {RoundDict[PokemonTrainer1]} rounds won");
            BattleDict[PokemonTrainer1]++;
        }
        else if (RoundDict[PokemonTrainer2] > RoundDict[PokemonTrainer1])
        {
            Console.WriteLine($"Trainer 2 won the battle with {RoundDict[PokemonTrainer2]} rounds won");
            BattleDict[PokemonTrainer2]++;
        }
        else
        {
            Console.WriteLine("The battle ended in a draw");
            BattlesDraw++;
        }
        
        
    }
    
    public void PrintStats(Trainer PokemonTrainer1, Trainer PokemonTrainer2)
    {
        Console.WriteLine($"Battles fought: {BattlesFought}");
        Console.WriteLine($"Battles won by trainer 1: {BattleDict[PokemonTrainer1]}");
        Console.WriteLine($"Battles won by trainer 2: {BattleDict[PokemonTrainer2]}");
        Console.WriteLine($"Battles ended in a draw: {BattlesDraw}");
    }
    
    public void ResetRoundStats(Trainer PokemonTrainer1, Trainer PokemonTrainer2)
    {
        //clear the round stats
        RoundDict[PokemonTrainer1] = 0;
        RoundDict[PokemonTrainer2] = 0;
        RoundsFought = 0;
        // PokeballList1.Clear();
        // PokeballList2.Clear();
        
        

    }

}