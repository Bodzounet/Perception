using UnityEngine;
using System.Collections;

public class TextOutro : MonoBehaviour
{
    void Start()
    {
        SpawnText st = GameObject.Find("GUI_Text").GetComponent<SpawnText>(); 
        
        st.printText("Congratulations, you have passed all the tests !");
        st.printText("Thank you very much for you cooperation !");
        st.printText("You will now be brought back outside of this place, enjoy the rest of your life :)");
    }
}
