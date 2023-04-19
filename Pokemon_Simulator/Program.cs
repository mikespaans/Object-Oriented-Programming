using Pokemon;
using System;


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
