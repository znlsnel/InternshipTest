using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> monsterPrefabs;

    private void Start()
    {
        Managers.Game.onGameStart += () => StartCoroutine(GameStart());
        
    }

    private IEnumerator GameStart() 
    {
        GameObject player = PlayerController.player; 

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3f));

            int N = Random.Range(1, 3);
            for (int i = 0; i < N; i++)
            {
                Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
 
                GameObject monster = Managers.Pool.Get(monsterPrefabs[Random.Range(0, monsterPrefabs.Count)]);
                monster.transform.position = spawnPos; 
                monster.SetActive(true);

                MonsterController controller = monster.GetComponent<MonsterController>();
                controller.Setup();
                controller.onDead += () => Managers.Pool.Release(monster, 1.5f);
            } 
        }
        
    }
}
