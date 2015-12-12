using UnityEngine;
using System.Collections;

public class SwitchBehavior : MonoBehaviour
{
    public Animator door1;
    public Animator door2;
    public string door1Behavior;
    public string door2Behavior;
    
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();	
	}

    public void unlock()
    {
        door1.Play(door1Behavior);
        door2.Play(door2Behavior);
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetButtonDown("Action"))
        {
            _anim.Play("Switch_OnActivation");
        }
    }
}
