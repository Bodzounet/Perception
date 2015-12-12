using UnityEngine;
using System.Collections;

public class OnStartLevel : MonoBehaviour {

    void Awake()
    {
        transform.rotation = KeepRotationBetweenLevels.Instance.q;
    }
}
