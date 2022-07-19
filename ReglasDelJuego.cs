
public class GameRules<T>
{
    public int TokensByPlayer{get;set;}
    public IValidateMove<T> validador{get;set;}
    public BaseState<T> State{get;set;}
    public List<Token<T>> Tokens{get;set;}
    public IOrder<T> Ordenador{get;set;}
    public ControladorDeDesarrollo<T> contoler{get;set;}
    public IValorateToken<T> Valorator{get;set;}
    public IGameFinisher<T> Finisher{get;set;}
    public IResult<T> result{get;set;}
    public GameRules(int TokensByPlayer,IValidateMove<T> validador,BaseState<T> State,List<Token<T>> Tokens,IOrder<T> Ordenador,ControladorDeDesarrollo<T> contoler,IValorateToken<T> Valorator,IGameFinisher<T> Finisher,IResult<T> result)
    {
        this.TokensByPlayer = TokensByPlayer;
        this.State = State;
        this.validador = validador;
        this.Tokens = Tokens;
        this.Ordenador = Ordenador;
        this.contoler = contoler;
        this.Valorator = Valorator;
        this.Finisher = Finisher;
        this.result = result;
    }
}
static class GetGameRules<T>
{
    const int CantCarasToken = 2;
    public static GameRules<T> Get(List<Token<T>> Tokens,int TokensByPlayer,int CantJugadores,int ValidateMoveIndicator,
                            int OrderIndicator,int ValorateTokenIndicator,
                            int GameFinisherIndicador,int ResultIndicator)
    {
        IValidateMove<T> validator = GetValidateMove(ValidateMoveIndicator);
        IOrder<T> Ordenator = GetOrder(OrderIndicator);
        IValorateToken<T> valorator = GetValorateToken(ValorateTokenIndicator);
        IGameFinisher<T> finisher = GetGameFinisher(GameFinisherIndicador);
        IResult<T> result = GetResult(ResultIndicator);

        BaseState<T> State = new BaseState<T>();
        ControladorDeDesarrollo<T> controler = new ControladorDeDesarrollo<T>(CantJugadores);

        return new GameRules<T>(TokensByPlayer,validator,State,Tokens,Ordenator,controler,valorator,finisher,result);
    }
    private static IValidateMove<T> GetValidateMove(int x)
    {
        switch(x)
        {
            case 0:
                return new ValidadorNormal<T>();
            case 1:
            default:
                return new ValidadorEscalera<T>();
        }
    }
    private static IOrder<T> GetOrder(int x)
    {
        switch(x)
        {
            case 0:
                return new NormalOrder<T>();
            case 1:
            default:
                return new VariableOrder<T>();
        }
    }
    private static IValorateToken<T> GetValorateToken(int x)
    {
        switch(x)
        {
            case 0:
                return new NormalValorator<T>();
            case 1:
            default:
                return new MCDValorator<T>();
        }
    }
    private static IGameFinisher<T> GetGameFinisher(int x)
    {
        switch(x)
        {
            case 0:
                return new NormalFinisher<T>();
            case 1:
            default:
                return new OneTimePassFinisher<T>();
        }
    }
    private static IResult<T> GetResult(int x)
    {
        switch(x)
        {
            case 0:
                return new IndividualPuntuation<T>();
            case 1:
            default:
                return new TeamPuntuation<T>();
        }
    }
}
