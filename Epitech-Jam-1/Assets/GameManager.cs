using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>().gameObject.GetComponent<HealthManager>().getHealth() < 100) {
            SceneManager.LoadScene("Defeat");
        }
        if (FindObjectsOfType<Spawner>().Length == 0) {
            SceneManager.LoadScene("Victory");
        }
    }
}
