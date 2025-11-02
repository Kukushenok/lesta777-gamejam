using Cysharp.Threading.Tasks;
using UnityEngine;

public class MenuState : IState
{
    public async UniTask OnEnterAsync()
    {
        Debug.Log("Enter MenuState");
        await UniTask.Yield();
    }

    public async UniTask OnExit()
    {
        Debug.Log("Exit MenuState");
        await UniTask.Yield();
    }
}
