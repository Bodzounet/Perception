using UnityEngine;
using System.Collections;

public class FollowPlatforms : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

	void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.tag == "platform")
        {
            tr.SetParent(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        print(other.name);
        if (other.tag == "platform")
        {
            tr.parent = null;
        }
    }
}
