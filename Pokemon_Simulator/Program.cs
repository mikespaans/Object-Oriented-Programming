using Pokemon;
using System;

//asignement 3

// var replay = true;
//
// while (replay == true)
// {
//     Pokeball.PokeballsBelt.Clear();
//     Pokeball.PokeballsBelt2.Clear();
//     
//     Console.WriteLine("what is the name of the first trainer?");
//     string TrainerName = Console.ReadLine();
//     var trainer = new Trainer(TrainerName, Pokeball.PokeballsBelt);
//     
//     Console.WriteLine("what is the name of the second trainer?");
//     string TrainerName2 = Console.ReadLine();
//     var trainer2 = new Trainer(TrainerName2, Pokeball.PokeballsBelt2);
//     
//     for (int i = 0; i < 6; i++)
//     {
//         Console.WriteLine($"trainer {trainer.Name} throws pokeball {i + 1}");
//         trainer.Throw(i, Pokeball.PokeballsBelt);
//         
//         var SelectedCharmander = Pokeball.PokeballsBelt[i];
//         //battlecry
//         SelectedCharmander.Pokemon.BattleCry(SelectedCharmander.Pokemon.Name);
//         
//         Console.WriteLine($"trainer {trainer2.Name} throws pokeball {i + 1}");
//         trainer2.Throw(i, Pokeball.PokeballsBelt2);
//     
//         var SelectedCharmander2 = Pokeball.PokeballsBelt2[i];
//         //battlecry
//         SelectedCharmander2.Pokemon.BattleCry(SelectedCharmander2.Pokemon.Name);
//         
//         Console.WriteLine($"trainer {trainer.Name} returns pokeball {i + 1}");
//         trainer.Return(i, Pokeball.PokeballsBelt);
//         
//         Console.WriteLine($"trainer {trainer2.Name} returns pokeball {i + 1}");
//         trainer2.Return(i, Pokeball.PokeballsBelt2);
//     
//         
//     }
//     
//     Console.WriteLine("Do you want to play again? (y/n)");
//     string answer = Console.ReadLine();
//     if (answer == "n")
//     {
//         replay = false;
//     }
// }



//asignement 4

    Console.WriteLine("what is the name of the first trainer?");
    string TrainerName = Console.ReadLine();
    var trainer = new Trainer(TrainerName, Pokeball.PokeballsBelt);
     
    Console.WriteLine("what is the name of the second trainer?");
    string TrainerName2 = Console.ReadLine();
    var trainer2 = new Trainer(TrainerName2, Pokeball.PokeballsBelt2);

     
    var Battle = new Battle(trainer, trainer2);
    // var Round = Battle.SimulateRound();
    Battle.SimulateBattle();
