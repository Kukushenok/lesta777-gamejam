using Cysharp.Threading.Tasks;
using UnityEngine;

public class PauseState : IState
{
    public async UniTask OnEnterAsync()
    {
        Debug.Log("Enter PauseState");
        await UniTask.Yield();
    }

    public async UniTask OnExit()
    {
        Debug.Log("Exit PauseState");
        await UniTask.Yield();
    }
}
