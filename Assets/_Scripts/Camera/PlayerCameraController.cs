using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As from the name, controls the player camera,
// Also provides some handy 
public class PlayerCameraController : MonoBehaviour
{
    // Max angles for the camera, otherwise you have to deal with sticky issues
    // like gimbal lock and accidental rotations on unintended axis
    public float maxUpAngle = 45f;
    public float maxDownAngle = -45f;

    [Space(10)]
    // Distance from center-point to rotate around (The Radius)
    public float distanceFromCenter = 4f;
    // The initial distance off the ground the camera should be when looking straight forward
    public float cameraYOffset = 2f;

    // Just some formatting for the editor inspector
    [Space(10)]

    // Making a quick assumption that people will try both mouse drag
    // and poking the arrow keys to rotate the camera, so need speed for both
    public float clickdragSpeed = 3f;
    public float keydownSpeed = 7f;

    [Space(10)]

    // Maximuum speed the camera can go regardless of clickdrag/keydown speeds
    public float maxCameraSpeed = 1f;

    // Gotta keep track of that mouse for input tracking
    private Vector2 lastMousePos = Vector2.zero;
    // Moving the camera towards a target point at a smooth speed, instead of controlling directly, reduces judder and 'hard' camera movments
    private Vector3 targetCameraPosition = Vector3.zero;

    public float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, cameraYOffset, distanceFromCenter);
        targetCameraPosition = transform.position;
        transform.LookAt(new Vector3(0, cameraYOffset, 0));
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0f)
        {
            float newAngle = GetNewAngle((horizontalInput > 0f) ? keydownSpeed : -keydownSpeed);
            currentAngle = newAngle;

            float cos = Mathf.Cos(newAngle), sin = Mathf.Sin(newAngle);

            targetCameraPosition = new Vector3(sin * distanceFromCenter, cameraYOffset, cos * distanceFromCenter);

            

            transform.position = Vector3.MoveTowards(transform.position, targetCameraPosition, maxCameraSpeed);
            transform.LookAt(new Vector3(0, cameraYOffset, 0));
        }
    }

    private void UpdateMousePosition()
    {

    }

    private float GetNewAngle(float change)
    {
        float newAngle = currentAngle + change;

        if (newAngle >= 360f)
            newAngle -= 360f;
        else if (newAngle < 0f)
            newAngle += 360f;

        return newAngle;
    }
}
