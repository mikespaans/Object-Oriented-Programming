using System.Collections.Generic;
using System;

namespace Pokemon;

    public class Charmander
    {
        public string Name { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }

        public int CharmanderNumber { get; set; }

        public Boolean IsReleased { get; set; }

        
    public Charmander(string Name, string Strength, string Weakness, int CharmanderNumber, bool IsReleased)
    {
        this.Name = Name;
        this.Strength = Strength;
        this.Weakness = Weakness;
        this.CharmanderNumber = CharmanderNumber;
        this.IsReleased = IsReleased;
    }


    }


/*
The pokeball is empty or it can contain a single charmander.
The pokeball can be thrown, which opens it up, and then releases the charmander inside of it.
The charmander can be returned back to its pokeball, which closes the pokeball again.
 */
    public class Pokeball
        {

    public static List<Pokeball> PokeballsBelt = new List<Pokeball>();
    public static List<Pokeball> PokeballsBelt2 = new List<Pokeball>();



    public Boolean IsFull { get; set; }
    public int PokeballNumber { get; set; }

    public Charmander charmander { get; set; }

        public Pokeball (Boolean IsFull, int PokeballNumber, Charmander charmander, List<Pokeball> PokeBallsList)
            {
            this.IsFull = IsFull;
            this.PokeballNumber = PokeballNumber;
            this.charmander = charmander;
            

            PokeBallsList.Add(this);
            Console.WriteLine(PokeBallsList.Count);
                    
            }
            

            public static void Throw(int PokeballNumber, List<Pokeball> PokeballList)
            {
                var PokeBall = PokeballList[PokeballNumber];
                //charmander gets released
                PokeBall.IsFull = false;
                PokeBall.charmander.IsReleased = true;
                
               // return PokeballNumber;
            }

            public static void Return(int PokeballNumber, List<Pokeball> PokeballList)
            {
                //charmander gets returned
                var PokeBall = PokeballList[PokeballNumber];
                PokeBall.IsFull = true;
                PokeBall.charmander.IsReleased = false;
            }
            
            

        }




/*
The trainer has a name and a belt with six pokeballs.
The trainer can throw a pokeball from their belt.
The trainer can return a pokemon back to its pokeball and put the pokeball back on their belt.
There are restrictions to the Trainer class:
The belt has six pokeballs with a Charmander in each of them.
The belt cannot be an array but has to be a List<Pokeball> class.
 */
public class Trainer
{
    //private List<Pokeball> PokeballsBelt = new List<Pokeball>();

    public string Name { get; set; }

    public Trainer(string Name, List<Pokeball> PokeballList)
    {
        this.Name = Name;
        FillBelt(PokeballList);
    }

    public static void FillBelt(List<Pokeball> PokeballList)
    {
        for (int i = 0; i < 6; i++)
        {
            var charmander = new Charmander("Charmander", "Fire", "Water", i, false);
            var Pokeball = new Pokeball(true, i, charmander, PokeballList);
        }
    }

    public void Throw(int PokeballNumber, List<Pokeball> PokeballList)
    {
        Pokeball.Throw(PokeballNumber, PokeballList);
    }

    public void Return(int PokeballNumber, List<Pokeball> PokeballList)
    {
        Pokeball.Return(PokeballNumber, PokeballList);
    }



}






