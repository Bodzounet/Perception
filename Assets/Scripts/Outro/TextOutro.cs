using UnityEngine;
using System.Collections;

public class TextOutro : MonoBehaviour
{
    void Start()
    {
        SpawnText.printText("Congratulations, you have passed all the tests !");
        SpawnText.printText("Thank you very much for you cooperation !");
        SpawnText.printText("You will now be brought back outside of this place, enjoy the rest of your life :)");
    }
}
