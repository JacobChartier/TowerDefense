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
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.6f);
                var enemy = Instantiate(prefab, GameManager.Instance.spawnTile.transform.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().SetPath(GameManager.Instance.pathToGoal);
            }

            yield return new WaitForSeconds(2f);
        }
    }
}
