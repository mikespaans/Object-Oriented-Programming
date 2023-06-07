using Pokemon;
using System;
using System.Runtime.ConstrainedExecution;

var replay = true;
var AddToDict = true;

Console.WriteLine("what is the name of the first trainer?");
string TrainerName = Console.ReadLine();
var trainer = new Trainer(TrainerName);
trainer.FillBelt(trainer.PokeballsBelt, 1);
    
Console.WriteLine("what is the name of the second trainer?");
string TrainerName2 = Console.ReadLine();
var trainer2 = new Trainer(TrainerName2);
trainer2.FillBelt(trainer2.PokeballsBelt, 2);




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

    
 Arena.ResetRoundStats(trainer, trainer2);
 
 // Trainer.FillBelt(Pokeball.PokeballsBelt, 1);
 // Trainer.FillBelt(Pokeball.PokeballsBelt2, 2);
 
 //return all used pokeballs to the belt
 trainer.ReturnPokeballsToBellt(trainer);
 trainer2.ReturnPokeballsToBellt(trainer2);
 
 
 
 
 
 
 // Pokecenter
 Trainer[] TrainerArray = new Trainer[] { trainer, trainer2 };
 foreach (var t in TrainerArray)
 {
     var PokemonCenter = new PokemonCenter(t);
     PokemonCenter.HealPokemon();
 }
     
 
  
 Console.WriteLine("Do you want to play again? (y/n)");
 string answer = Console.ReadLine();
 if (answer == "n")
 {
     replay = false;
 }

}