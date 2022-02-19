using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float hitForce = 5f;
    public ParticleSystem flash;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit[] hits;
        flash.Play();
        hits = Physics.RaycastAll(fpsCam.transform.position, fpsCam.transform.forward, range);
        foreach (RaycastHit hit in hits)
        {
            if(hit.rigidbody != null)
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    rb.AddForce(transform.forward * hitForce, ForceMode.Impulse);
                }
            }
        }


    }
}
