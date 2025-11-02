using Cysharp.Threading.Tasks;
using UnityEngine;

public class BattleState : IState
{
    public async UniTask OnEnterAsync()
    {
        Debug.Log("Enter BattleState");
        await UniTask.Yield();
    }

    public async UniTask OnExit()
    {
        Debug.Log("Exit BattleState");
        await UniTask.Yield();
    }
}
