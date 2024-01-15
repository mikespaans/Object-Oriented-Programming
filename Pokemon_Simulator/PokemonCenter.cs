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
}

