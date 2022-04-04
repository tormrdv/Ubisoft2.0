using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float treshold;
    public LevelLayoutGenerator levelLayoutGenerator;

    private void LateUpdate()
    {
        Vector3 cameraPosition = GameObject.transform.position;

        //Do I need this?
        cameraPosition.y = 0f;

        if (cameraPosition.magnitude > treshold)
        {
            for(int z = 0; z < SceneManager.sceneCount; z++)
            {
                foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
                {
                    g.transform.position -= cameraPosition;
                }
            }
        }
    }
}
