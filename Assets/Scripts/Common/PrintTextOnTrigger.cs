using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrintTextOnTrigger : MonoBehaviour
{
    public List<string> messages;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            foreach (string message in messages)
            {
                SpawnText.printText(message);
            }
            Destroy(this);
        }
    }
}
