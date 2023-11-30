using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = Shoot.bulletSpeed;
    public Meteor Meteor;
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Destroy(this.gameObject);
            Spawner.rocksRemaining--;
        }
        if (collision.gameObject.CompareTag("SmallMeteor"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
