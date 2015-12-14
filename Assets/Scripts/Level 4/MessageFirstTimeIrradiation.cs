using UnityEngine;
using System.Collections;

public class MessageFirstTimeIrradiation : MonoBehaviour 
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            var st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();

            st.printText("Oh ! i detect a uge amount of radiation around those lights.");
            st.printText("What do you think about staying a bit more in the radiation field ?");
            st.printText("I could get some interesting data from this extra experiment...");

            Destroy(this.gameObject);
        }
    }
}
