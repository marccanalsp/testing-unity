using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject trail, blood, bulletHitFX;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.forward * speed;

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(EnableTrailBullet());
    }

    public IEnumerator EnableTrailBullet() {
        yield return new WaitForSecondsRealtime(0.05f);
        trail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<BulletTarget>() != null)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Debug.Log("I hit the target");
        }
        else {
            Debug.Log("I missed the target");
        }
        Instantiate(bulletHitFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
