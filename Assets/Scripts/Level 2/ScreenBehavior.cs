using UnityEngine;
using System.Collections;
using SynchronizerData;

public class ScreenBehavior : MonoBehaviour
{
    public Material normal_view;
    public Material look;
    public float bpm = 120.0f;

    private BeatObserver beatObserver;
    private bool isEnabled;
    private float elapsedTime;

    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        isEnabled = false;
        elapsedTime = 0.0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 60.0f / bpm)
        {
            if (isEnabled)
            {
                gameObject.GetComponent<Renderer>().material = look;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = normal_view;
            }
            isEnabled = !isEnabled;
            elapsedTime = 0.0f;
        }
    }
}