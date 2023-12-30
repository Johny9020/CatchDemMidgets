namespace CatchDemMidgets;

using CatchDemMidgets.Pokemon;

public class Player
{
    private OPokemon? _pokemon;
    
    public OPokemon Pokemon
    {
        get => _pokemon ?? throw new NullReferenceException();
        set => _pokemon = value;
    }
}