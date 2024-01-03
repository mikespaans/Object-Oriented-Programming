namespace Pokemon;


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