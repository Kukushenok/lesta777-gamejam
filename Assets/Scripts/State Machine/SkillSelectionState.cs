using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillSelectionState : IState   
{
    public async UniTask OnEnterAsync()
    {
        Debug.Log("Enter SkillSelectionState");
        await UniTask.Yield();
    }

    public async UniTask OnExit()
    {
        Debug.Log("Exit SkillSelectionState");
        await UniTask.Yield();
    }
}
