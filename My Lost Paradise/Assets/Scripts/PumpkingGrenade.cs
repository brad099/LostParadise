using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkingGrenade : MonoBehaviour
{
    [SerializeField] float ThrowForce = 10f;
    [SerializeField] float ExplosionForce = 20f;
    [SerializeField] float ExplosionRange = 5f;
    //public AudioSource explode;
    public GameObject vfx;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * ThrowForce, ForceMode.Impulse);
        StartCoroutine(Explode());
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.8f);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, ExplosionRange);

        foreach (Collider item in colliders)
        {
            Rigidbody hitRb = item.GetComponent<Rigidbody>();
            if (item.transform.CompareTag("Player"))
            {
                hitRb.AddExplosionForce(0,explosionPos,0,0f,ForceMode.Impulse);
            }
            else if(hitRb != null)
            {
                Instantiate(vfx,transform.position,Quaternion.Euler(0,0,0));
                //AudioSource.PlayClipAtPoint(explode.clip,transform.position);
                //hitRb.AddExplosionForce(ExplosionForce, explosionPos, ExplosionRange, 20f, ForceMode.Impulse);
                hitRb.tag = "Untagged";
                hitRb.transform.parent = this.transform;
                hitRb.gameObject.SetActive(false);
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject);
            }
        }
        yield return new WaitForSeconds(1.9f);
        StopCoroutine(Explode());    
    }
}