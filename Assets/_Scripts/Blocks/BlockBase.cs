using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Base Class for blocks!
 * Can be used itself for basic structure blocks, 
 * or extended for more advanced block types
 */

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BlockBase : MonoBehaviour
{

    // Option to destroy block after it falls past a certain Y point
    public bool destroyOnY = true;
    public float yHeightLevel = 0f;

    [Space(10)]

    // Option to destroy block after it has moved a max distance from its starting position
    public bool destroyOnDistance = true;
    public float maxDestroyDistance = 2f;


    // Initial starting position of current block
    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyOnDistance & Vector3.Distance(startPos, transform.position) >= maxDestroyDistance)
            DestroyBlock();

        if(destroyOnY & transform.position.y <= yHeightLevel)
            DestroyBlock();
    }


    // Call to destory the block programatically!
    public void DestroyBlock()
    {

    }
}
