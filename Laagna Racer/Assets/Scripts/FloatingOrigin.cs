using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float treshold;
    public LevelLayoutGenerator layOutGenerator;

    private void LateUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;

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

            Vector3 originDelta = Vector3.zero - cameraPosition;
            layOutGenerator.UpdateSpawnOrigin(originDelta);
            Debug.Log("Reseting position, origin delta = " + originDelta);
        }
    }
}
