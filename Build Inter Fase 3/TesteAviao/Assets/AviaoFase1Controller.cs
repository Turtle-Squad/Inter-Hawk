using UnityEngine;

public class AviaoFase1Controller : MonoBehaviour {

    public float damage = 1.0f;
    public float fireRate = 15f;
    public float health = 3f;

    public GameObject aviaomid, aviaoleft, aviaoright;

    public GameObject crosshair;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash2;
    public GameObject impactEffect;
    public GameObject explode;

    private float nextTimeToFire;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (health <= 0)
        {
            Debug.Log("Game Over.");
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        muzzleFlash2.Play();
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                return;
            }
            DroneController drone = hit.transform.GetComponent<DroneController>();
            if (drone != null)
            {
                drone.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Drone")
        {
            GameObject explosion = Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(gameObject);
               health -= 1f;
        }
    }
}
