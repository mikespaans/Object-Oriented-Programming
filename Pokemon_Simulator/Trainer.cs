namespace Pokemon;


public class Trainer
{
    private static int MaxPokeballs = 6;
    public string Name { get; }

    public List<Pokeball> PokeballsBelt = new List<Pokeball>();
    // public static List<Pokeball> PokeballsBelt2 = new List<Pokeball>();

    public List<Pokeball> UsedPokeballsList = new List<Pokeball>();
    // public static List<Pokeball> UsedPokeballsList2 = new List<Pokeball>();

    public Trainer(string Name)
    {
        this.Name = Name;
        // FillBelt(PokeballList, TrainerNumber);
    }

    public void FillBelt(List<Pokeball> PokeballList, int TrainerNumber)
    {
        for (int i = 0; i < MaxPokeballs; i++)
        {
            // check if bellt is full
            if (PokeballList.Count >= 6)
            {
                throw new Exception("Cannot add more Pokeballs, Belt is full");
            }
            // add pokeballs to belt
            if (i <= 1)
            {
                var charmander = new Charmander("Charmander", Strength_Weakness.Fire, Strength_Weakness.Water, i, "charmander");
                var Pokeball = new Pokeball(true, i, charmander, PokeballList, TrainerNumber);
            }
            else if (i <= 3)
            {
                var squirtle = new Squirtle("Squirtle", Strength_Weakness.Water, Strength_Weakness.Leaf, i, "squirtle");
                var Pokeball = new Pokeball(true, i, squirtle, PokeballList, TrainerNumber);
            }
            else
            {
                var bulbasaur = new Bulbasaur("Bulbasaur", Strength_Weakness.Leaf, Strength_Weakness.Fire, i, "bulbasaur");
                var Pokeball = new Pokeball(true, i, bulbasaur, PokeballList, TrainerNumber);
            }

        }
    }

    public void ReturnPokeballsToBellt(Trainer trainer)
    {
        //Pokeballs get returned to the belt
        foreach (var Pokeball in trainer.UsedPokeballsList)
        {
            trainer.PokeballsBelt.Add(Pokeball);
        }
        trainer.UsedPokeballsList.Clear();
    }

    public void Throw(int PokeballNumber, List<Pokeball> PokeballList)
    {
        Pokeball.Throw(PokeballNumber, PokeballList);
    }

    public void Return(int PokeballNumber, List<Pokeball> PokeballList)
    {
        Pokeball.Return(PokeballNumber, PokeballList);
    }

    //gets a random pokeball from the belt
    public Pokeball GetRandomPokeball(List<Pokeball> PokeballList, List<Pokeball> UsedPokeballList)
    {

        //Random Pokeball gets selected
        Random random = new Random();
        int RandomIndex = random.Next(PokeballList.Count);
        var RandomPokeball = PokeballList[RandomIndex];
        // Console.WriteLine(RandomPokeball.Pokemon.Name);

        //Pokeball gets removed from the belt
        PokeballList.Remove(RandomPokeball);

        //Pokeball gets added to the used Pokeball list
        UsedPokeballList.Add(RandomPokeball);

        //Pokemon gets released
        RandomPokeball.IsFull = false;

        //random Pokeball gets returned
        return RandomPokeball;
    }

}