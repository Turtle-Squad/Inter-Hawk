using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFase3 : MonoBehaviour
{
    private Rigidbody corpo;
    public Transform direction;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        corpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        corpo.AddForce((target.transform.position - transform.position) * 5);

        if (transform.position.z > 500)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -500)
        {
            Destroy(gameObject);
        }

        if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter()
    {
        EnemyHealthController.vidaInimigo -= 1f;
        Destroy(gameObject);
    }
}
