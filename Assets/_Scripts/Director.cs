using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * The Director runs the show, they generally control the scene and influence the 'actors'
 * as well as keeps track of all the important player-relevant info
 * like scoring, lifes, time/ammo remaining, time-elapsed, ect.
 * Also keeps track of some programtic settings and developer options,
 * Mostly a catch-all for scene top-level things
*/
public class Director : MonoBehaviour
{
    // Lock Cursor in Window?
    public bool lockCursorOnStart = false;

    // Just some formatting for the Editor Inspector
    [Space(10)]

    // The players current score
    public int playerScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        if(lockCursorOnStart)
            Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseLeftDown = Input.GetButton("Fire1");

        if(mouseLeftDown)
        {
            
        }
    }

    public void AddScore(int score)
    {
        playerScore += score;
    }
}
