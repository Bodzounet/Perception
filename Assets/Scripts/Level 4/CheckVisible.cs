﻿using UnityEngine;
using System.Collections;

public class CheckVisible : MonoBehaviour 
{
    public GameObject Light;
    public LightManager.e_Lights lightColor;

	RaycastHit hit;
    LightManager lm;

    void Awake()
    {
        lm = GameObject.FindObjectOfType<LightManager>();
    }

    void Start()
    {
        StartCoroutine("CheckItem", Light);
    }
	
	bool isVisible (GameObject go) 
    {
        Renderer objRend = go.GetComponent<Renderer>();
        Transform objPos = go.GetComponent<Transform>();

		if (objRend.isVisible) 
        {
			if (Physics.Raycast (transform.position, (objPos.position - transform.position), out hit)) 
            {
				if (hit.transform == objPos) 
                {
                    return true;
				}
			}
		}
        return false;
	}

    public void reset()
    {
        StopAllCoroutines();
        StartCoroutine("CheckItem", Light);
        lm.CurrentLights = LightManager.e_Lights.NONE;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            reset();
    }

    IEnumerator CheckItem(GameObject go)
    {
        int count = 0;

        while (true)
        {
            if (isVisible(go))
            {
                //Debug.Log("go : " + go.name + ", is visible, count = " + count);
                if (count++ >= 3)
                {
                    //Debug.Log("go : " + go.name + ", jackpot");
                    lm.addLight(lightColor);
                }
            }
            else
            {
                //Debug.Log("go : " + go.name + " is not visible");
                count = 0;
            }
            yield return new WaitForSeconds(1);
        }
    }

    void OnEnable()
    {
        StartCoroutine("CheckItem", Light);
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}