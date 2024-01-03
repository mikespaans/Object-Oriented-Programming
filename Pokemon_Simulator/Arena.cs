namespace Pokemon;

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