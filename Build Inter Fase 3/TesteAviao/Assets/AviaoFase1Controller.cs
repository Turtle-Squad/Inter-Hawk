using UnityEngine;
using UnityEngine.SceneManagement;

public class AviaoFase1Controller : MonoBehaviour {

    public float damage = 1.0f;
    public float fireRate = 15f;
    public float health = 3f;

    public GameObject aviaomid, aviaoleft, aviaoright;

    public static bool podeAtirar = true;

    public AudioSource machinegun;
    public AudioSource plane;

    public GameObject crosshair;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash2;
    public GameObject impactEffect;
    public GameObject explode;

    private float nextTimeToFire;

    private void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        machinegun = audios[0];
        plane = audios[1];
    }
    // Update is called once per frame
    void Update()
    {
        if (podeAtirar == true)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            if (health <= 0)
            {
                SceneManager.LoadScene("Fase1");
            }
        }

    }

    void Shoot()
    {
        plane.Play();
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
            RobotFase3Controller robot = hit.transform.GetComponent<RobotFase3Controller>();
            if (robot != null)
            {
                robot.TakeDamage(damage);
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
