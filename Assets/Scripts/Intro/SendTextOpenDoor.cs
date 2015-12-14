using UnityEngine;
using System.Collections;

public class SendTextOpenDoor : MonoBehaviour
{
    public SasManager sasManager;

	void Start ()
    {
        SpawnText st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();

        st.printText("Hi, subject #357.");
        st.printText("You are here because your cognitive capacities have been judged high enough to participate in this experiment.");
        st.printText("You have been provided a last generation augmented reality headpiece.");
        st.printText("It's the thing on your head, letting you read my sweet sweet messages. :)");
        st.printText("You may now start the tests. Don't worry, nothing is lethal. Good luck.");
        Invoke("OpenDoor", 35);
    }

    void OpenDoor()
    {
        sasManager.changeSasState(1);
    }
}
