using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As from the name, controls the player camera,
// Also provides some handy 
public class PlayerCameraController : MonoBehaviour
{
    // Max angles for the camera, otherwise you have to deal with sticky issues
    // like gimbal lock and accidental rotations on unintended axis
    public float maxUpAngle;
    public float maxDownAngle;

    [Space(10)]
    // Distance from center-point to rotate around (The Radius)
    public float distanceFromCenter = 4f;

    // Just some formatting for the editor inspector
    [Space(10)]

    // Making a quick assumption that people will try both mouse drag
    // and poking the arrow keys to rotate the camera, so need speed for both
    public float clickdragSpeed;
    public float keydownSpeed;

    private Vector2 lastMousePos = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateMousePosition()
    {

    }
}
