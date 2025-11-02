using Cysharp.Threading.Tasks;

public interface IState
{
    public UniTask OnEnterAsync();

    public UniTask OnExit();
}
