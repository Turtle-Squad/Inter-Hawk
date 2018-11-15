using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFase3 : MonoBehaviour
{
    private Rigidbody corpo;
    public Transform direction;
    public Vector3 target = new Vector3(0, 1.186f, 0);
    // Use this for initialization
    void Start()
    {
        corpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        corpo.AddForce(direction.forward * 500);

        if (transform.position.z > 500)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -500)
        {
            Destroy(gameObject);
        }

        if (transform.position == target)
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
