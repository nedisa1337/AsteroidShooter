using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 20f;
    public GameObject SmallRockPrefab;
    private Vector3 SmallRockSpawnPos;
    void Update()
    {
        if (gameObject.CompareTag("SmallMeteor")) 
        { 
            transform.position += -transform.forward * (speed + 3) * Time.deltaTime;
        }
        else
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("Meteor"))
        {
            Split();
        }
    }

    public void Split()
    {
        int countOfSmallMeteors = Random.Range(2, 3);

        gameObject.SetActive(false);

        for (int i = 0; i <= countOfSmallMeteors; ++i)
        {
            SmallRockSpawnPos = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y, transform.position.z);
            Instantiate(SmallRockPrefab, SmallRockSpawnPos, transform.rotation);
        }
    }
}
