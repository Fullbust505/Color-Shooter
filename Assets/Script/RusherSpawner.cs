using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusheurSpawner : MonoBehaviour
{
    public GameObject rusheurPrefab;
    public GameObject warningPrefab;
    public float spawnInterval = 5f;
    public float warningDuration = 1.5f;
    public float spawnDistanceOutside = 8f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            StartCoroutine(SpawnWarningAndEnemy());
            timer = 0f;
        }
    }

    IEnumerator SpawnWarningAndEnemy()
    {
        // 1. Choisir un côté du viewport
        int side = Random.Range(0, 4);
        Vector3 viewportPos = Vector3.zero;

        switch (side)
        {
            case 0: // haut
                viewportPos = new Vector3(Random.Range(0.1f, 0.9f), 0.98f, 10f);
                break;
            case 1: // bas
                viewportPos = new Vector3(Random.Range(0.1f, 0.9f), 0.02f, 10f);
                break;
            case 2: // gauche
                viewportPos = new Vector3(0.02f, Random.Range(0.1f, 0.9f), 10f);
                break;
            case 3: // droite
                viewportPos = new Vector3(0.98f, Random.Range(0.1f, 0.9f), 10f);
                break;
        }

        Vector3 worldTargetPos = Camera.main.ViewportToWorldPoint(viewportPos);
        worldTargetPos.z = 0f;

        // 2. Afficher le warning (!)
        GameObject warning = Instantiate(warningPrefab, worldTargetPos, Quaternion.identity);
        Destroy(warning, warningDuration);

        // 3. Attendre avant de faire apparaître le rusheur
        yield return new WaitForSeconds(warningDuration);

        // 4. Calculer la direction et position de spawn hors écran
        Vector3 dirFromCenter = (worldTargetPos - Camera.main.transform.position).normalized;
        Vector3 spawnPos = worldTargetPos + dirFromCenter * spawnDistanceOutside;

        // 5. Spawn du rusheur
        Instantiate(rusheurPrefab, spawnPos, Quaternion.identity);
    }
}
