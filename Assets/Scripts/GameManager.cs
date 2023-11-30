using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public player playerScript;

    private void Awake()
    {
        Camera.main.backgroundColor = Random.ColorHSV();
        Spawner.countOfRocks += 5;
    }
    public void Play()
    {
        SceneManager.LoadScene("1");
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    public IEnumerator NextLevel()
    {
        winScreen.SetActive(true);
        playerScript.enabled = false;
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("SmallMeteor"))
        {
            Destroy(o);
        }
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("1");
    }
}
