using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 offset2;
    private Vector3 amount = new Vector3(0, 0, 20.0f);
    private float speed = 0.02f;
    Vector3 target = new Vector3(0, 1.186f, 0);

    void Start()
    {
        offset = transform.position - player.transform.position;
        offset2 = transform.position - player.transform.position + amount;
    }

    void LateUpdate()
    {
        transform.LookAt(target);
        transform.position = player.transform.position + offset;

        if(player.transform.position.z >= target.z)
        {
            //transform.position = Vector3.Slerp(offset, offset2, Time.time * speed);
            transform.position = player.transform.position + offset2;
        }
    }
}