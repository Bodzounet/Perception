using UnityEngine;
using System.Collections;

public class ChangeOcclusionZoneSize : MonoBehaviour
{
    Vector3 initial;
    Vector3 mini;

    OVRPlayerController ctrl;

    void Start()
    {
        ctrl = GameObject.FindObjectOfType<OVRPlayerController>();

        initial = transform.localScale;
        mini = new Vector3(initial.x / 33, initial.y, initial.z / 33);
    }

    void FixedUpdate() // and not Update
    {
        if (ctrl.ShakingHeadChecker(1, 50, 300, 0, 10, 0, 1))
        {
            StopAllCoroutines();
            StartCoroutine(resize());
        }
    }

    IEnumerator resize()
    {
        while (transform.localScale != mini)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, mini, 0.1f);
            yield return new WaitForEndOfFrame();
        }
        while (transform.localScale != initial)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initial, 0.001f);
            yield return new WaitForEndOfFrame();
        }
    }
}
