using UnityEngine;
using System.Collections;

public class AnimateBackGround : MonoBehaviour 
{
    VisionManager vm;
    public GameObject Sas;

    void Awake()
    {
        vm = GameObject.FindObjectOfType<VisionManager>();
        StartCoroutine("Co_AnimateBackground");
    }

    IEnumerator Co_AnimateBackground()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(0, 4); i++)
                vm.CurrentVisionType++;
            yield return new WaitForSeconds(Random.Range(5, 10));

            if (Random.Range(0, 6) >= 3)
                Sas.SendMessage("changeSasState", 1);
            else
                Sas.SendMessage("changeSasState", -1);
        }
    }
}
