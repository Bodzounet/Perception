using UnityEngine;
using System.Collections;

public class SwitchButtonLevel4 : MonoBehaviour 
{
    bool _triggered = false;
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void unlock()
    {
        GameObject.FindObjectOfType<ProgressionManagerLevel4>().unlockDoor();
    }

    void OnTriggerStay(Collider col)
    {
        if (!_triggered && Input.GetButtonDown("Action"))
        {
            _triggered = true;
            _anim.Play("Switch_OnActivation");
        }
    }
}
