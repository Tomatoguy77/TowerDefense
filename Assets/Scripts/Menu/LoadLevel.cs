using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
    public void ChangeScene(string sceneChange)
    {
        //Changes Scene by writing the scene name.
        Application.LoadLevel(sceneChange);
    }
}