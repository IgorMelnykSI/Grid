using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D body;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 53);
        body.rotation = 53f;
        body.velocity = transform.right * speed;
        //Destroy(gameObject, 2);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform targetPos = collision.gameObject.transform;

        if (targetPos != null)
        {
            if (targetPos == target)
            {
                Destroy(gameObject);
            }
        }
    }

}
