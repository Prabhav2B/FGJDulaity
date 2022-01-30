using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryDetection : MonoBehaviour
{
    public bool stopMovingLeft { get; private set; }
    public bool stopMovingRight { get; private set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, Vector2.left * 2f, Color.red);
        //Debug.DrawRay(transform.position, Vector2.right * 2f, Color.red);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector3.left, 1.2f);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector3.right, 1.2f);

        if(hitLeft.collider != null)
            stopMovingLeft = hitLeft.collider.gameObject.layer == LayerMask.NameToLayer("Boundry") ? true : false;
        if(hitRight.collider != null)
            stopMovingRight = hitRight.collider.gameObject.layer == LayerMask.NameToLayer("Boundry") ? true : false;
    }
}
