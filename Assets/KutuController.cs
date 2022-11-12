using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuController : MonoBehaviour
{
    public GameObject ParticleSystem;
    public GameObject EffectorObject1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag=="KirmiziKutu") 
        {
            if (collision.gameObject.tag == "KirmiziKutu")
            {
                Patla();
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Bomba")
                Patla();
        }
        else
        {
            if (collision.gameObject.tag == "Bomba")
                Destroy(gameObject);
        }

    }


    private void Patla()
    {
        GameObject MyParticalEffect= Instantiate(ParticleSystem, transform.position, transform.rotation);
        GameObject MyEffectorObject = Instantiate(EffectorObject1, transform.position, transform.rotation);
        Destroy(MyParticalEffect, 3);
        Destroy(MyEffectorObject, 1);
        Destroy(gameObject);
    }
}
