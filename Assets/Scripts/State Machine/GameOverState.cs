using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameOverState : IState
{
    public async UniTask OnEnterAsync()
    {
        Debug.Log("Enter GameOverState");
        await UniTask.Yield();
    }

    public async UniTask OnExit()
    {
        Debug.Log("Exit GameOverState");
        await UniTask.Yield();
    }
}
