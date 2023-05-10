using Pokemon;
using System;
using System.Runtime.ConstrainedExecution;

var replay = true;
var AddToDict = true;

Console.WriteLine("what is the name of the first trainer?");
string TrainerName = Console.ReadLine();
var trainer = new Trainer(TrainerName, Pokeball.PokeballsBelt, 1);
Console.WriteLine(Pokeball.PokeballsBelt.Count);
    
Console.WriteLine("what is the name of the second trainer?");
string TrainerName2 = Console.ReadLine();
var trainer2 = new Trainer(TrainerName2, Pokeball.PokeballsBelt2, 2);
Console.WriteLine(Pokeball.PokeballsBelt2.Count);




//asignement 4
while (replay == true)
{
    

    // Console.WriteLine("what is the name of the first trainer?");
    // string TrainerName = Console.ReadLine();
    // var trainer = new Trainer(TrainerName, Pokeball.PokeballsBelt, 1);
    // Console.WriteLine(Pokeball.PokeballsBelt.Count);
    //
    // Console.WriteLine("what is the name of the second trainer?");
    // string TrainerName2 = Console.ReadLine();
    // var trainer2 = new Trainer(TrainerName2, Pokeball.PokeballsBelt2, 2);
    // Console.WriteLine(Pokeball.PokeballsBelt2.Count);



    var Arena = new Arena(trainer, trainer2, AddToDict);
    AddToDict = false;
    var Battle = Arena.CreateBattle(trainer, trainer2);



    Arena.SimulateBattle(trainer, trainer2);
    Arena.PrintStats(trainer, trainer2);

    Console.WriteLine("Do you want to play again? (y/n)");
    string answer = Console.ReadLine();
    if (answer == "n")
    {
        replay = false;
    }
 Arena.ResetRoundStats(trainer, trainer2, Pokeball.PokeballsBelt, Pokeball.PokeballsBelt2);
 
 Trainer.FillBelt(Pokeball.PokeballsBelt, 1);
 Trainer.FillBelt(Pokeball.PokeballsBelt2, 2);
}