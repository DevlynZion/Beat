using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> Pools;

    private Dictionary<string, Queue<GameObject>> poolGameObjects;

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        SetupPools();
    }

    public void SetupPools()
    {
        poolGameObjects = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int k = 0; k < pool.Size; k++)
            {
                var gameObject = Instantiate(pool.Prefab);
                gameObject.SetActive(false);
                objectPool.Enqueue(gameObject);
            }

            poolGameObjects.Add(pool.Name, objectPool);
        }
    }

    public GameObject GetFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        if (!poolGameObjects.ContainsKey(poolName))
        {
            Debug.LogWarning(string.Format("Pool '{0}' does not exist", poolName));
            return null;
        }

        var objectPooled = poolGameObjects[poolName].Dequeue();

        objectPooled.SetActive(true);
        objectPooled.transform.position = position;
        objectPooled.transform.rotation = rotation;

        poolGameObjects[poolName].Enqueue(objectPooled);

        return objectPooled;
    }

    public T GetFromPool<T>(string poolName, Vector3 position, Quaternion rotation)
        where T : class
    {
        var objectPooled = GetFromPool(poolName, position, rotation);

        if (objectPooled == null)
            return null;

        return objectPooled.GetComponent<T>();
    }
}
