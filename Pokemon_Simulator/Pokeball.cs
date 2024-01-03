namespace Pokemon;


public sealed class Pokeball
{

    // public static List<Pokeball> PokeballsBelt = new List<Pokeball>();
    // public static List<Pokeball> PokeballsBelt2 = new List<Pokeball>();
    //
    // public static List<Pokeball> UsedPokeballsList = new List<Pokeball>();
    // public static List<Pokeball> UsedPokeballsList2 = new List<Pokeball>();



    public Boolean IsFull { get; set; }
    public int PokeballNumber { get; set; }
    public int TrainerNumber { get; set; }

    // public Charmander charmander { get; set; }
    public BasePokemon Pokemon { get; }

    public Pokeball(Boolean IsFull, int PokeballNumber, BasePokemon Pokemon, List<Pokeball> PokeBallsList, int TrainerNumber)
    {
        this.IsFull = IsFull;
        this.PokeballNumber = PokeballNumber;
        this.Pokemon = Pokemon;
        this.TrainerNumber = TrainerNumber;


        PokeBallsList.Add(this);


    }


    public static void Throw(int PokeballNumber, List<Pokeball> PokeballList)
    {
        var PokeBall = PokeballList[PokeballNumber];
        //charmander gets released
        PokeBall.IsFull = false;


        // return PokeballNumber;
    }

    public static void Return(int PokeballNumber, List<Pokeball> PokeballList)
    {
        //charmander gets returned
        var PokeBall = PokeballList[PokeballNumber];
        PokeBall.IsFull = true;

    }

}