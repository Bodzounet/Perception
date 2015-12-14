using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnText : MonoBehaviour 
{
    static List<string> pendingMsgs = new List<string>();
    Text text;

    void Awake()
    {
        text = this.GetComponent<Text>();
        //printText("Bodz est trop un boss");
        //printText("il dechire grave");
        //printText("praise the lord of c#");
    }

    void Start()
    {
        StartCoroutine("printTextAux");
    }

    public void printText(string msg)
    {
        pendingMsgs.Add(msg);
    }

    IEnumerator printTextAux()
    {
        while (true)
        {
            if (pendingMsgs.Count == 0)
                yield return new WaitForSeconds(1);
            else
            {
                string msg = pendingMsgs[0];
                pendingMsgs.RemoveAt(0);

                int count = 0;

                while (count++ < msg.Length)
                {
                    text.text = msg.Substring(0, count) + (count % 3 == 0 ? "*" : "");
                    yield return new WaitForSeconds(0.05f);
                }

                text.text = msg;
                yield return new WaitForSeconds(3);
                text.text = "";
            }
        }
    }
}
