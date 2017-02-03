using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOverTime : MonoBehaviour
{
    private Vector3 currentScale = Vector3.zero;
    public Vector3 finalScale = new Vector3(1.0f, 1.0f, 1.0f);
    public float scaler = 3f;

    void Update()
    {
        Grow();
    }

    private void Grow()
    {
        Debug.Log(currentScale);
        currentScale = Vector3.Lerp(currentScale, finalScale, Time.deltaTime * scaler);
        transform.localScale = currentScale;

    }
}
