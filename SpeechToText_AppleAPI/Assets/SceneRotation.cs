using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;//or right for right landscape 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
