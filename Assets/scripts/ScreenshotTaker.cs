using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    public KeyCode key;
    public string format = ".png";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            string filename = System.DateTime.Now.ToString();
            filename = filename.Replace("/", "-");
            filename = filename.Replace(" ", "_");
            filename = filename.Replace(":", "-");

            ScreenCapture.CaptureScreenshot(string.Format("{0}/{1}{2}", Application.persistentDataPath, filename, format));

            Debug.Log("Screenshot saved.");
        }
    }
}
