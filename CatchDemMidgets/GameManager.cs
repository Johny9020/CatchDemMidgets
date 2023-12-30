using CatchDemMidgets.Pokemon;
using CatchDemMidgets.Bush;
using CatchDemMidgets.Utilities;

namespace CatchDemMidgets;

public class GameManager
{
    private static GameManager? _instance;
    
    // PokemonList is a list of all the pokemon in the game
    private List<OPokemon> _pokemonList = new List<OPokemon>();
    
    // StarterPokemon is a list of all the starter pokemon in the game
    private List<OPokemon> _starterPokemon = new List<OPokemon>();
    
    // Bushes is a list of all the bushes in the game
    private List<OBush> _bushes = new List<OBush>();

    // Instance of the player
    private Player _player;
    
    private Random random = new Random();

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
        InitializePokemon();
        InitiateBushes();
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        _player = new Player();
        StringUtils.Print("Please choose a starter pokemon:");
        StringUtils.Print("-----------------------------");
        
        for (var i = 0; i < _starterPokemon.Count; i++)
        {
            StringUtils.Print((i + 1) + ". " + _starterPokemon[i].Name);
        }
        
        StringUtils.Print("-----------------------------");
        var input = Console.ReadLine();

        if (input?.Length > 0)
        {
            switch(input)
            {
                case "1":
                    _player.Pokemon = _starterPokemon[0];
                    break;
                case "2":
                    _player.Pokemon = _starterPokemon[1];
                    break;
                case "3":
                    _player.Pokemon = _starterPokemon[2];
                    break;
                default:
                    _player.Pokemon = _starterPokemon[0];
                    break;
            }
            StringUtils.Print("You chose " + _player.Pokemon.Name + " as your starter pokemon!");
            StringUtils.Print("You are now ready to start your adventure!\n");
            BushSelection();
        }
    }

    private void BushSelection()
    {
        StringUtils.Print("Oh no! The pokemon's are hiding in the bushes!");
        StringUtils.Print("Which bush do you want to check?");
        StringUtils.Print("-----------------------------");
        for(var i = 0; i < _bushes.Count; i++)
        {
            StringUtils.Print("| " + (i + 1) + " ", false);
        }
        StringUtils.Print("\n-----------------------------");
    }
    
    private void InitializeStartingPokemon()
    {
        var builder = new IPokemonBuilder();
        
        // Turtwig
        builder.Reset();
        builder.SetName("Turtwig");
        builder.SetHp(100);
        builder.SetDmg(random.Next(35, 50));
        _starterPokemon.Add(builder.GetPokemon());
        
        // Piplup
        builder.Reset();
        builder.SetName("Piplup");
        builder.SetHp(100);
        builder.SetDmg(random.Next(35, 50));
        _starterPokemon.Add(builder.GetPokemon());
        
        // Charmander
        builder.Reset();
        builder.SetName("Charmander");
        builder.SetHp(100);
        builder.SetDmg(random.Next(35, 50));
        _starterPokemon.Add(builder.GetPokemon());
    }

    private void InitializePokemon()
    {
        var builder = new IPokemonBuilder();
        var pokemonNames = new List<string>();
        
        pokemonNames.Add("Bulbasaur");
        pokemonNames.Add("Ivysaur");
        pokemonNames.Add("Venusaur");
        pokemonNames.Add("Charmeleon");
        pokemonNames.Add("Charizard");
        pokemonNames.Add("Squirtle");
        pokemonNames.Add("Wartortle");
        pokemonNames.Add("Blastoise");
        pokemonNames.Add("Caterpie");
        pokemonNames.Add("Metapod");
        pokemonNames.Add("Butterfree");
        pokemonNames.Add("Weedle");
        pokemonNames.Add("Kakuna");
        pokemonNames.Add("Beedrill");
        pokemonNames.Add("Pidgey");
        pokemonNames.Add("Pidgeotto");
        pokemonNames.Add("Pidgeot");
        pokemonNames.Add("Rattata");
        pokemonNames.Add("Raticate");
        pokemonNames.Add("Spearow");
        pokemonNames.Add("Fearow");

        for (var i = 0; i < 10; i++)
        {
            builder.Reset();
            builder.SetName(pokemonNames[random.Next(0, pokemonNames.Count)]);
            builder.SetHp(100);
            builder.SetDmg(random.Next((i + 5) + 20, (i + 5) + 50));
            _pokemonList.Add(builder.GetPokemon());
            pokemonNames.Remove(builder.GetPokemon().Name);
        }
    }

    private void InitiateBushes()
    {
        var tempPokemonList = new List<OPokemon>(_pokemonList);
        var bush = new OBush();
        
        for (var i = 0; i < 10; i++)
        {
            bush.BushName = "Bush " + (i + 1);
            bush.Pokemon = tempPokemonList[random.Next(0, tempPokemonList.Count)];
            _bushes.Add(bush.Clone());
            tempPokemonList.Remove(bush.Pokemon);
        }
    }
}