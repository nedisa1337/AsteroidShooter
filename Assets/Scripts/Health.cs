using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 20;
    public TextMeshProUGUI hpText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            health -= 2;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("SmallMeteor"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        hpText.text = health.ToString();
        if (health <= 0) GameManager.RestartGame();
    }
}
