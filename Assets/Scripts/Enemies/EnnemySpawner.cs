using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    [SerializeField] private static GameObject prefab;

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/basic_enemy");
    }

    public static IEnumerator Spawn()
    {
        while (LevelManager.Wave.Current != LevelManager.Wave.MaxValue)
        {
            var num = Random.Range(0, 16);

            for (int i = 0; i < num; i++)
            {
                yield return new WaitForSeconds(0.5f);
                var enemy = Instantiate(prefab, GameManager.Instance.spawnTile.transform.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().SetPath(GameManager.Instance.pathToGoal);
            }

            LevelManager.EndWave();

            yield return new WaitForSeconds(2f);
        }
    }
}
