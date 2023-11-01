using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform LeftTop;
    [SerializeField] private Transform RightBottom;
    float minScale = 0.5f; // 最小のスケール
    float maxScale = 1.0f; // 最大のスケール
    private float minX, maxX, minZ, maxZ;
    private int enemyCount;
    private void Start()
    {
        minX = LeftTop.position.x;
        maxX = RightBottom.position.x;
        minZ = RightBottom.position.z;
        maxZ = LeftTop.position.z;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "GameScene") {
            StartCoroutine(SpawnEnemy());
        }
    }
    private IEnumerator SpawnEnemy()
    {
        
        for (int i = 0; i < 100; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX),0.8f , Random.Range(minZ, maxZ));

            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject instantiatedEnemy = Instantiate(enemy, position, Quaternion.identity, transform);
            float randomScale = Random.Range(minScale, maxScale);
            Vector3 scale = new Vector3(randomScale, randomScale, randomScale);
            instantiatedEnemy.transform.localScale = scale;
            yield return new WaitForSeconds(1.0f);
        }
    }
}