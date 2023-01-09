using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D body;
    private Transform target;

    private float timer = 0.0f;
    private float waitTime = 0.8f;

    public GameObject _explosion;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 53);
        body.rotation = 53f;
        body.velocity = transform.right * speed;
        //Destroy(gameObject, 2);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime && target != null)
        {
            float offsetX = -12.0f;
            float offsetY = 12.0f;

            transform.position = new Vector3(target.position.x + offsetX, target.position.y + offsetY, 0);
            transform.Rotate(0, 0, -90);
            body.rotation = -90f;
            body.velocity = transform.right * speed;
            
            timer = timer - waitTime - 1f;
        }
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
                Instantiate(_explosion, targetPos.position, targetPos.rotation);
            }
        }
    }

}
