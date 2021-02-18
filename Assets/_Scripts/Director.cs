using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Space(10)]

    // Projectile Settings
    public float maxProjectileSpeed = 1f;
    public float maxProjectileWeight = 2f;
    public float maxProjectileSize = 2.5f;
    public float maxChargeTime = 2f;

    // Just some formatting for the Editor Inspector
    [Space(10)]

    public Text scoreText;
    public Text chargeText;
    public GameObject projectileBase;

    // The players current score
    public int playerScore = 0;


    private bool charging = false;
    public float currentCharge = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (lockCursorOnStart)
            Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseLeftDown = Input.GetButton("Fire1");

        if (mouseLeftDown)
        {
            if (!charging)
                charging = true;
            else
            {
                if (currentCharge < maxChargeTime)
                {
                    currentCharge += Time.deltaTime;
                    chargeText.text = ((int)((currentCharge / maxChargeTime)*100)).ToString();
                }
            }
        }
        else if (charging)
        {
            CreateProjectile();
            charging = false;
            currentCharge = 0f;
            chargeText.text = "0";
        }

        // Reloads Scene on Space
        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void CreateProjectile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Get new projectile
        var go = Instantiate(projectileBase);

        // get transform, rigidbody
        var tf = go.transform;
        var rb = go.GetComponent<Rigidbody>();

        // Set position to mouse
        tf.position = ray.origin;
        // Set projectile scale according to charge time
        tf.localScale = tf.localScale * ((currentCharge / maxChargeTime) * maxProjectileSize);
        // set projectile mass based on charge time
        rb.mass = ((currentCharge / maxChargeTime) * maxProjectileWeight);

        rb.AddForce(ray.direction * ((currentCharge / maxChargeTime) * maxProjectileSpeed));
    }
}
