using UnityEngine;
using System.Collections;

public class UnlockDoor : MonoBehaviour
{
    Animator _anim;

    void Awake()
    {
        _anim = this.GetComponent<Animator>();
    }

    void open()
    {
        _anim.SetBool("ChangeState", true);
    }
}
