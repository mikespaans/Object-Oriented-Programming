using System;
using System.Collections.Generic;

namespace Pokemon
{
    public class PokemonCenter
    {
        private Trainer trainer { get; set; }
        private Nurse Nurse { get; set; }
        private HealingStation HealingStation { get; set; }
        
        public PokemonCenter(Trainer trainer)
        {
            this.trainer = trainer;
            this.Nurse = new Nurse();
            this.HealingStation = new HealingStation();
        }
        
        public void HealPokemon()
        {
            int DeadPokemons = Nurse.CheckAllHealed(trainer.PokeballsBelt);
            
            Console.WriteLine($"Number of dead pokemons: {DeadPokemons}");
              
            // loop till all pokemons are healed                        
            while (DeadPokemons > 0)
            {
                // fill the station slots
                Nurse.FillStationSlots(HealingStation.Slots, trainer.PokeballsBelt);
                
                // heal the pokemons
                HealingStation.CheckNurseAndHeal(Nurse);
                
                // return the healed pokemons to the belt
                Nurse.ReturnPokeballsToBelt(HealingStation.Slots, trainer.PokeballsBelt);
                
                //check if all pokemons are healed
                DeadPokemons = Nurse.CheckAllHealed(trainer.PokeballsBelt);
            }
            
            
        }
    }

    public class Nurse
    {
        public Nurse()
        {
        }
        
        // fill the slots of the healing station with dead pokemons
        public void FillStationSlots(Pokeball[] Slots, List<Pokeball> PokeballList)
        {
            Console.WriteLine("the nurse is filling the slots");
            
            var Index = 0;
            foreach (var pokeball in PokeballList)
            {
                // check if the slots are full
                if (Index == Slots.Length)
                {
                    break;
                }
                
                // check if the pokemon is dead
                if (pokeball.Pokemon.IsAlive == false)
                {
                    Slots[Index] = pokeball;
                    Index++;
                }
            }
            
            // Remove the pokeballs from the pokebellt
            foreach (var pokeball in Slots)
            {
                if (pokeball != null)
                {
                    PokeballList.Remove(pokeball);
                }
            }
        }

        // return the pokeballs to the belt
        public void ReturnPokeballsToBelt(Pokeball[] Slots, List<Pokeball> PokeballList)
        {
            Console.WriteLine("the nurse is returning the pokeballs to the belt");
            int Index = 0;
            foreach (var pokeball in Slots)
            {
                if (pokeball != null)
                {
                    PokeballList.Add(pokeball);
                    Slots[Index] = null;
                }
                Index++;
            }
        }

        // check if all pokemons are healed
        public int CheckAllHealed(List<Pokeball> PokeballList)
        {
            int NumberOfDeadPokemons = 0;
            foreach (var pokeball in PokeballList)
            {
                if (pokeball.Pokemon.IsAlive == false)
                {
                    NumberOfDeadPokemons++;
                }
            }
            return NumberOfDeadPokemons;
        }
        
    }
 
    public class HealingStation
    {
        public Pokeball[] Slots { get; set; }
        private int MaxSlots = 4;
        
        public HealingStation()
        {
            this.Slots = new Pokeball[MaxSlots];
        }

        // heal the pokemons in the slots
        private void HealPokemon()
        {
            Console.WriteLine("the nurse is healing the pokemons");
            foreach (var pokeball in Slots)
            {
                if (pokeball != null)
                {
                    pokeball.Pokemon.IsAlive = true;
                }
            }
        }

        public void CheckNurseAndHeal(Nurse Nurse)
        {
            if (Nurse != null)
            {
                HealPokemon();
            }
        }
    }
}
