using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class PlayerDebuffManager : MonoBehaviour
{
    [SerializeField] DebuffRepositorySO TMP;
    private IEnumerator Start()
    {
        // TODO: just fetch all initial debuffs from GameManager
        var x = TMP.GetFetcher();
        bool work = true;
        while (work)
        {
            var debuffs = x.GetDebuffs();
            work = debuffs.Count > 0;
            if(work)
            {
                x.OnDebuffSelected(debuffs[0]);
                Debug.Log("Applied " + debuffs[0].Name);
                debuffs[0].ApplyDebuff(gameObject);
            }
            yield return new WaitForSeconds(1);
        } 
    }
}
