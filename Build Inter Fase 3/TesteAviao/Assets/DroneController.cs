using UnityEngine;

public class DroneController : MonoBehaviour {

    public float health = 1000f;
    public GameObject explode;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f) {
            Die();
        }
    }

    void Die()
    {
        GameObject explosion = Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(explosion, 3f);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100.0f);

        if(transform.position.x >= 400f)
        {
            Destroy(gameObject);
        }
    }
}
