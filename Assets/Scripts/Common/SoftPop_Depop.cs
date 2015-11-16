using UnityEngine;
using System.Collections;

public class SoftPop_Depop
{
    public struct softData
    {
        public softData(Renderer rd, Color end)
        {
            _end = end;
            _rd = rd;
        }

        public Color _end;
        public Renderer _rd;
    }

    public static IEnumerator Soft(softData sd)
    {
        Debug.Log("là");

        while (sd._rd.material.color != sd._end)
        {
            sd._rd.material.color = Color.Lerp(sd._rd.material.color, sd._end, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        Debug.Log("ici");
    }
}
