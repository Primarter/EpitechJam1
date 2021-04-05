using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    [Header("Spawn Period in milliseconds")]
    [SerializeField] public int period = 3000;
    [Header("Sources")]
    [Space]
    [SerializeField] public GameObject[] spawnSources;

    void Start()
    {
        sw.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSources.Length == 0) {
            sw.Stop();
            return;
        }
        if (sw.ElapsedMilliseconds >= period) {
            Instantiate<GameObject>(
                spawnSources[Random.Range(0, spawnSources.Length)],
                this.transform.position, Quaternion.identity,
                this.transform
            );
            sw.Restart();
        }
    }
}
