using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 50);
        body.rotation = 50f;
        body.velocity = transform.right * speed;
        Destroy(gameObject, 2);
    }
}
