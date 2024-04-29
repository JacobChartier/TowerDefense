using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private static GameObject prefab;
    public static List<GameObject> enemies = new();

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/basic_enemy");
    }

    public static IEnumerator Spawn()
    {
        while (LevelManager.Wave.Current <= LevelManager.Wave.MaxValue)
        {
            var num = Random.Range(5, 16);

            for (int i = 0; i < num; i++)
            {
                yield return new WaitForSeconds(0.5f);
                var enemy = Enemy.Create(Enemy.GetRandom(typeof(BasicEnemy), typeof(HealerEnemy)), GameManager.Instance.spawnTile.transform.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().SetPath(GameManager.Instance.pathToGoal);

                enemies.Add(enemy);
            }

            while (enemies.Count != 0)
            {
                yield return new WaitForSeconds(2f);
            }

            LevelManager.EndWave();
        }
    }
}
