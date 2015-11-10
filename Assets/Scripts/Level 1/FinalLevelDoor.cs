using UnityEngine;
using System.Collections;

public class FinalLevelDoor : MonoBehaviour
{
    int _locks = 3;
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void unlockDoor()
    {
        switch (--_locks)
        {
            case 2:
                _anim.SetBool("FirstLock", true);
                break;
            case 1:
                _anim.SetBool("SecondLock", true);
                break;
            case 0:
                _anim.SetBool("Open", true);
                break;
            default:
                Debug.LogError("Should not happen");
                break;

        }
    }
}
