using Cysharp.Threading.Tasks;
using UnityEngine;

public class VictoryState : IState
{
    public async UniTask OnEnterAsync()
    {
        Debug.Log("Enter VictoryState");
        await UniTask.Yield();
    }

    public async UniTask OnExit()
    {
        Debug.Log("Exit VictoryState");
        await UniTask.Yield();
    }
}
