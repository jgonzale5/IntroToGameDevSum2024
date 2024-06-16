using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //
    public static CameraShake instance;

    //
    private Vector3 originalPos;

    //
    private void Start()
    {
        //
        instance = this;  
        //
        originalPos = transform.position;
    }

    //
    public void ShakeCamera(float duration, float intensity)
    {
        //
        StartCoroutine(Shake(duration, intensity));
    }

    //
    IEnumerator Shake(float duration, float intensity)
    {
        //
        //Vector3 originalPos = transform.localPosition;

        //
        float elapsed = 0;

        //
        while (elapsed < duration)
        {
            //
            float xPos = Random.Range(-intensity, intensity);
            float yPos = Random.Range(-intensity, intensity);

            //
            transform.localPosition = originalPos + new Vector3(xPos, yPos, 0);

            //
            elapsed += Time.deltaTime;

            //
            yield return new WaitForEndOfFrame();
        }

        //
        transform.localPosition = originalPos;
    }
}
