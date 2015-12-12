using UnityEngine;
using System.Collections;

public class SasManager : MonoBehaviour 
{
    Animator _animator;

    public float initialState = -1; // -1 closed, 1 opened
    private float currentState;

    void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _animator.SetFloat("StateF", initialState);
        currentState = initialState;
    }

    public void changeSasState(float state)
    {
        if (state != currentState)
            _animator.SetFloat("StateF", state);
    }
}
