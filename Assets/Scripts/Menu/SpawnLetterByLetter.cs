using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnLetterByLetter : MonoBehaviour 
{
    Text txt;
    string msg;


    void Awake()
    {
        txt = this.GetComponent<Text>();
        msg = txt.text;
        txt.text = "";
    }

    void Print()
    {
        StopAllCoroutines();
        txt.text = "";
        StartCoroutine("Co_Print");
    }

    IEnumerator Co_Print()
    {
        int count = 0;
        while (count++ < msg.Length)
        {
            txt.text = msg.Substring(0, count) + (count % 3 == 0 ? "*" : "");
            yield return new WaitForSeconds(0.05f);
        }
        txt.text = msg;
    }
}
