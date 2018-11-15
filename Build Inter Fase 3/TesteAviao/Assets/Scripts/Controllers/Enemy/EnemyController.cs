using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public PlayerController playerController;
    public float fov = 20f;
    public float viewDistance = 10f;

    public float fovWarning = 180f;
    public float viewDistanceWarning = 13f;

    private bool isAware = false;

    private NavMeshAgent agent;

    public Renderer renderer;

    private RaycastHit hit;

    public GameObject lineCastReference, pReference;

    public GameObject warning, chasing;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        warning.SetActive(false);
        chasing.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isAware)
        {
            agent.SetDestination(playerController.transform.position);
            chasing.SetActive(true);
            warning.SetActive(false);
        }
        else
        {
            SearchForPlayer();
            //renderer.material.color = Color.gray;
        }
	}

    public void SearchForPlayer()
    {
        if(Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(playerController.transform.position)) < fov/2)
        {
            
            if (Vector3.Distance(playerController.transform.position, transform.position) < viewDistance)
            {

                if (Physics.Linecast(lineCastReference.transform.position, pReference.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                }
            }
            else if (Vector3.Distance(playerController.transform.position, transform.position) < viewDistanceWarning && Vector3.Distance(playerController.transform.position, transform.position) > viewDistance)
            {
                if (Physics.Linecast(lineCastReference.transform.position, pReference.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        warning.SetActive(true);
                        chasing.SetActive(false);
                    }
                }
               
            }
            else
            {
                chasing.SetActive(false);
                warning.SetActive(false);
            }
        }

        
    }

    public void OnAware()
    {
        isAware = true;
        
    }
}
