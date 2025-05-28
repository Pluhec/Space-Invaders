using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int count = 5;
    public float radius = 8f;
    public float spawnInterval = 0.3f;
}

public class EnemyWaveSpawner : MonoBehaviour
{
    [Header("Waves")]
    public Wave[] waves;
    private int currentWave = 0;

    [Header("Player")]
    public Transform playerTransform;

    [Header("UI")]
    public TextMeshProUGUI waveText;
    public GameObject victoryPanel;

    private void Start()
    {
        if (playerTransform == null)
            playerTransform = GameObject.FindWithTag("Player").transform;

        victoryPanel.SetActive(false);
        StartCoroutine(HandleWaves());
    }

    private IEnumerator HandleWaves()
    {
        int total = waves.Length;
        Debug.Log("metoda HandleWaves se spusi");
        for (currentWave = 0; currentWave < total; currentWave++)
        {
            waveText.text = $"Wave {currentWave + 1}/{total}";
            
            yield return SpawnWave(waves[currentWave]);
            
            yield return new WaitUntil(() =>
                GameObject.FindGameObjectsWithTag("Enemy").Length == 0
            );
            Debug.Log("porda nefungujeme?");
        }

        Debug.Log("Vyhral?");
        ShowVictory();
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            float angle = i * (360f / wave.count);
            Vector2 dir = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad)
            );
            Vector2 spawnPos = (Vector2)playerTransform.position + dir * wave.radius;
            Instantiate(wave.enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(wave.spawnInterval);
        }
    }

    private void ShowVictory()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}