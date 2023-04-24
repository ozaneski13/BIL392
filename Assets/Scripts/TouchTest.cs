using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    private void Update()
    {

            for (int i = 0; i < Input.touchCount; i++)
            {
            
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3
        (Input.touches[i].position.x, Input.touches[i].position.y, Camera.main.nearClipPlane));

            Debug.DrawLine(Vector3.zero, worldPos, Color.red);
            }
    }
}