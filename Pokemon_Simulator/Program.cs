﻿using Pokemon;
using System;

//assignement 1

/*
Console.WriteLine("what is the name of the charmander?");
string CharmanderName = Console.ReadLine();
var charmander = new Charmander(CharmanderName, "Fire", "Water");
bool isPlaying = true;

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{charmander.Name}!!!!");
}

//3. The charmander does its battle cry for ten times.

while (isPlaying == true)
{



    Console.WriteLine("what is the new name of the charmander?");
    string CharmanderName2 = Console.ReadLine();
    charmander.Name = CharmanderName2;

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{charmander.Name}!!!!");
    }

    Console.WriteLine("Do you want to continue? (y/n)");
    string answer = Console.ReadLine();
    if (answer == "n")
    {
        isPlaying = false;
    }


}
*/



//assignement 2
Console.WriteLine("what is the name of the first trainer?");
string TrainerName = Console.ReadLine();
var trainer = new Trainer(TrainerName, Pokeball.PokeballsBelt);

Console.WriteLine("what is the name of the second trainer?");
string TrainerName2 = Console.ReadLine();
var trainer2 = new Trainer(TrainerName2, Pokeball.PokeballsBelt2);

for (int i = 0; i < 6; i++)
{
    //Console.WriteLine($"trainer {trainer.Name} throws pokeball {i}");
    var Test = Pokeball.PokeballsBelt[i];
    Console.WriteLine($"{Test.charmander.Name}");
    //trainer.Throw(i, Pokeball.PokeballsBelt);



    //Console.WriteLine($"trainer {trainer2.Name} throws pokeball {i}");
    //trainer2.Throw(i);
}