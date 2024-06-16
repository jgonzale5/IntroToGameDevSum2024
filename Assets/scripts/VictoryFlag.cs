using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryFlag : MonoBehaviour
{
    public string VictorySceneName;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player Entered");
        SceneManager.LoadScene(VictorySceneName);
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Player Exited");
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Player is Here");
    }
}
