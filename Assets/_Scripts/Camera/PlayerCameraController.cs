using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As from the name, controls the player camera,
// Also provides some handy 
public class PlayerCameraController : MonoBehaviour
{
    // Max angles for the camera, otherwise you have to deal with sticky issues
    // like gimbal lock and accidental rotations on unintended axis
    // public float maxUpAngle = 4f;
    // public float maxDownAngle = -4f;

    [Space(10)]
    // Distance from center-point to rotate around (The Radius)
    public float distanceFromCenter = 4f;
    // The initial distance off the ground the camera should be when looking straight forward
    public float initialCameraYOffset = 2f;

    // Just some formatting for the editor inspector
    [Space(10)]

    // Making a quick assumption that people will try both mouse drag
    // and poking the arrow keys to rotate the camera, so need speed for both
    public float clickdragSpeed = 3f;
    public float keydownSpeed = 0.005f;

    [Space(10)]

    // Maximuum speed the camera can go regardless of clickdrag/keydown speeds
    public float maxCameraSpeed = 1f;
    // public float maxCameraYSpeed = 0.3f;

    // Gotta keep track of that mouse for input tracking
    private Vector2 lastMousePos = Vector2.zero;
    // Moving the camera towards a target point at a smooth speed, instead of controlling directly, reduces judder and 'hard' camera movments
    private Vector3 targetCameraPosition = Vector3.zero;

    private float currentHozAngle = 0f;

    // public float currentCameraYOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
       // currentCameraYOffset = initialCameraYOffset;
        transform.position = new Vector3(0, initialCameraYOffset, distanceFromCenter);
        targetCameraPosition = transform.position;
        transform.LookAt(new Vector3(0, initialCameraYOffset, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        /*
         * Could not get vertical camera logic figured out within timeframe, scraping it

        if (verticalInput != 0f)
        {
            float newYOffset = currentCameraYOffset = ( verticalInput > 0f ? maxCameraYSpeed : -maxCameraYSpeed);
            targetCameraPosition = new Vector3(targetCameraPosition.x, newYOffset, targetCameraPosition.z);
        }

        */

        // Doing this sloppy because I dont have the time to clean it up
        if (horizontalInput != 0f)
        {
            float newHozAngle = currentHozAngle = GetNewHozAngle((horizontalInput > 0f) ? keydownSpeed : -keydownSpeed);
            float hozCos = Mathf.Cos(newHozAngle), hozSin = Mathf.Sin(newHozAngle);

            targetCameraPosition = new Vector3(hozSin * distanceFromCenter, initialCameraYOffset, hozCos * distanceFromCenter);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetCameraPosition, maxCameraSpeed);
        transform.LookAt(new Vector3(0, initialCameraYOffset, 0));
    }

    private void UpdateMousePosition()
    {

    }

    private float GetNewHozAngle(float change)
    {
        float newAngle = currentHozAngle + change;

        if (newAngle >= 6.283f)
            newAngle -= 6.283f;
        else if (newAngle < -6.283f)
            newAngle += 6.283f;

        return newAngle;
    }

    /*
    private float GetNewCameraYOffset(float change)
    {
        float newYOffset = currentCameraYOffset + change;
        if(newYOffset > maxUpAngle)
            return maxUpAngle;
        else if(newYOffset < maxDownAngle)
            return maxDownAngle;
        else
            return newYOffset;
    }
    */
}
