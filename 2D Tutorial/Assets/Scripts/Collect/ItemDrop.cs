
using UnityEngine;
[System.Serializable]

public class ItemToSpawn
{
    public GameObject item;
    public float spawnRate;
    public float minSpawnProb, maxSpawnProb;
}

public class ItemDrop : MonoBehaviour
{
    public ItemToSpawn[] itemToSpawn;
    void Start()
    {
        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (i == 0)
            {
                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;
            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate - 1;
            }
        }
    }

    public void Spawmner()
    {
        float RandomNum = UnityEngine.Random.Range(1, 100);
        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (RandomNum >= itemToSpawn[i].minSpawnProb && RandomNum <= itemToSpawn[i].maxSpawnProb)
            {
                Debug.Log(RandomNum + " " + itemToSpawn[i].item.name);
                Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
