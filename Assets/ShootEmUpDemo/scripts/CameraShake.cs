using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //A static reference to this instance of the script so its functions can be called from anywhere in the game without a direct reference to the object
    public static CameraShake instance;

    //The original position of this object so it can be reset after each shake
    private Vector3 originalPos;

    //At the start of the game...
    private void Start()
    {
        //We set the instance to be this instance of the script, meaning any time "instance" is referred to, its refering to the (hopefully) only component of that type in the scene
        instance = this;  
        //The local position of the object is stored at the start. 
        originalPos = transform.localPosition;
    }

    //This function will shake the camera for the time specified, with the intensity specified, when called
    public void ShakeCamera(float duration, float intensity)
    {
        //Executes the Shake couroutine, which is called differently than functions
        StartCoroutine(Shake(duration, intensity));
    }

    //This coroutine runs in parallel to other processes of the game. When called it will shake the object for the specified intensity for the specified duration of time
    IEnumerator Shake(float duration, float intensity)
    {
        //This variable used to store the local position of the object, however since multiple coroutines can be executed simultaneously this could eventually cause drift
        //Vector3 originalPos = transform.localPosition;

        //Keeps track of the time elapsed in this coroutine
        float elapsed = 0;

        //While the duration hasn't passed
        while (elapsed < duration)
        {
            //We generate a random offet in X and Y
            float xPos = Random.Range(-intensity, intensity);
            float yPos = Random.Range(-intensity, intensity);

            //Then add it to the original position and set that as the position of the camera
            transform.localPosition = originalPos + new Vector3(xPos, yPos, 0);

            //Add time to the elapsed variable to keep track of it
            elapsed += Time.deltaTime;

            //Wait for the end of the frame. Functionally identical to "yield return null"
            yield return new WaitForEndOfFrame();
        }

        //Reset the local position of this object
        transform.localPosition = originalPos;
    }
}
