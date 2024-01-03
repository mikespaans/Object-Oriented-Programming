namespace Pokemon;


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