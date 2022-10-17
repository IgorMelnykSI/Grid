using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public ParticleSystem exploision;

    public void Start()
    {
     var exp = Instantiate(exploision);
     exp.Play();
     exp.transform.parent = gameObject.transform;
     Destroy(gameObject, exp.duration);
      
    }
}
