using UnityEngine;
using System.Collections;

public class ChangeOcclusionZoneSize : MonoBehaviour
{
    public float incr = 0.01f;

    Vector3 v = new Vector3(1, 0, 1);
    Vector3 initial;

    void Start()
    {
        initial = transform.localScale;
    }

    void FixedUpdate() // and not Update
    {
        transform.localScale += v * incr;

        // if (Shakehead)
        //     transform.localScale = initial;
    }
}
