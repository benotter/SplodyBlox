using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    public float lifetime = 3f;
    public float yKill = 0f;

    private float currentLifeTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= yKill)
            Destroy(gameObject);

        currentLifeTime += Time.deltaTime;

        if(currentLifeTime >= lifetime)
            Destroy(gameObject);
    }
}
