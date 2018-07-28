using System.Collections.Generic;
using UnityEngine;

public class GreenHoopPool : MonoBehaviour
{
    private IncomingArrowPool arrowPool;

    public int currentObstacle = 0;
    public int poolSize = 5;
    public GameObject prefab;
    public float timeSinceLastSpawn = 0;
    public float spawnRateMin = .5f;
    public float spawnRateMax = 5f;
    public float timeLeftForNextSpawn;

    public ObjectPool pool;

    void Awake()
    {
        arrowPool = GetComponent<IncomingArrowPool>();

        ResetTimeForNextSpawn();
        PoolConfiguration config = new PoolConfiguration
        {
            prefab = prefab,
            prefabTagName = "GreenHoop",
            poolSize = poolSize,
            initialPosition = GameConstants.poolStartPosition
        };

        pool = new ObjectPool(config);
    }

    // contains the logic of when this object should appear
    void Update()
    {
        if (GameController.instance.gameover)
        {
            return;
        }


        System.DateTime now = System.DateTime.UtcNow;
        double secondsSinceLastSpawn = (now - GameConstants.timeOfLastSpawn).TotalSeconds;

        if (secondsSinceLastSpawn < GameConstants.timeBetweenSpawns)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (TimeForNextSpawn())
        {
            float randomX = UnityEngine.Random.Range(GameConstants.hoopMinX, GameConstants.hoopMaxX);
            GameObject greenHoop = pool.BorrowFromPool();
            MoveChildren(greenHoop, new Vector2(randomX, GameConstants.spawnY));
            GameController.instance.SetTimeOfLastSpawn(now);
            timeSinceLastSpawn = 0;
            ResetTimeForNextSpawn();
        }
    }

    private bool TimeForNextSpawn()
    {
        return timeSinceLastSpawn >= timeLeftForNextSpawn;
    }

    private void ResetTimeForNextSpawn()
    {
        timeLeftForNextSpawn = UnityEngine.Random.Range(spawnRateMin, spawnRateMax);
    }

    private void MoveChildren(GameObject parent, Vector2 newPosition)
    {
        Vector2 bottomHoopPos = newPosition + new Vector2(0, -.24f);
        foreach (Transform child in parent.transform)
        {
            child.position = child.name.Equals("BottomHoop") ? bottomHoopPos : newPosition;
            SetDistanceMeter(child);
        }
    }

    private void SetDistanceMeter(Transform other)
    {
        arrowPool.SetArrow(GameConstants.ArrowColor.Green, other);
    }
}

