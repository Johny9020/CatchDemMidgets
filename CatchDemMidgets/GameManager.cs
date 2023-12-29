using CatchDemMidgets.Pokemon;
using CatchDemMidgets.Utilities;

namespace CatchDemMidgets;

public class GameManager
{
    private static GameManager? _instance;
    private List<OPokemon> _pokemonList = new List<OPokemon>();
    private List<OPokemon> _starterPokemon = new List<OPokemon>();

    public static GameManager Instance
    {
        get => _instance ??= new GameManager();
    }

    public List<OPokemon> PokemonList
    {
        get => _pokemonList;
    }

    public void Setup()
    {
        InitializeStartingPokemon();

        foreach (var pokemon in _pokemonList)
        {
            StringUtils.Print(pokemon.Name);
        }
    }
    
    private void InitializeStartingPokemon()
    {
        var builder = new IPokemonBuilder();
        var random = new Random();
        
        // Turtwig
        builder.Reset();
        builder.SetName("Turtwig");
        builder.SetHp(100);
        builder.SetDmg(random.Next(25, 50));
        _starterPokemon.Add(builder.GetPokemon());
        
        // Piplup
        builder.Reset();
        builder.SetName("Piplup");
        builder.SetHp(100);
        builder.SetDmg(random.Next(25, 50));
        _starterPokemon.Add(builder.GetPokemon());
        
        // Charmander
        builder.Reset();
        builder.SetName("Charmander");
        builder.SetHp(100);
        builder.SetDmg(random.Next(25, 50));
        _starterPokemon.Add(builder.GetPokemon());
    }


}