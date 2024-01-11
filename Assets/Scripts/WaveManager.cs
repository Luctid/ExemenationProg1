using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bulletPrefab; // Added bulletPrefab field
    public int initialWaveCount = 1;
    public int enemiesPerWave = 3;
    public float timeBetweenWaves = 5f;
    public float destroyAfterSeconds = 20f; // Adjust this value as needed

    private bool wavesComplete = false;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        int waveNumber = 1;
        int totalWaves = 3; // Set the total number of waves here

        while (waveNumber <= totalWaves)
        {
            Debug.Log("Wave " + waveNumber);

            for (int i = 0; i < initialWaveCount + (enemiesPerWave * (waveNumber - 1)); i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f); // Adjust this delay as needed
            }

            // Check if all enemies from the last wave are destroyed
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);

            yield return new WaitForSeconds(timeBetweenWaves);
            waveNumber++;

            // Check if all waves are complete
            if (waveNumber > totalWaves)
            {
                wavesComplete = true;

                // Switch to the "NextLevel" scene once all waves are complete
                SceneManager.LoadScene("Next Level");
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Get the EnemyShooting component from the enemy
        EnemyShooting enemyShooting = enemy.GetComponent<EnemyShooting>();

        // Set the bullet prefab for the enemy
        if (enemyShooting != null)
        {
            enemyShooting.SetBulletPrefab(bulletPrefab);
        }

        // Destroy enemy and bullets after a certain duration
        Destroy(enemy, destroyAfterSeconds);

        // If there is a bulletSpawnPoint in the EnemyShooting script, you may want to destroy bullets separately
        // Example: DestroyBullets(enemyShooting.GetBulletSpawnPoint(), destroyAfterSeconds);
    }

    // Optionally, you can use this method to destroy bullets separately
    void DestroyBullets(Transform bulletSpawnPoint, float delay)
    {
        if (bulletSpawnPoint != null)
        {
            foreach (Transform bullet in bulletSpawnPoint)
            {
                Destroy(bullet.gameObject, delay);
            }
        }
    }
}
