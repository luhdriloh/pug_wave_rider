using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    private IncomingArrowPool arrowPool;

    public int poolSize = 5;
    public GameObject fatMissile;
    public GameObject missile;
    public float timeSinceLastSpawn = 0;
    public float spawnRateMin = .5f;
    public float spawnRateMax = 5f;
    public float timeLeftForNextSpawn;

    public ObjectPool missilePool;
    public ObjectPool fatMissilePool;

    // Use this for initialization
    void Awake()
    {
        arrowPool = GetComponent<IncomingArrowPool>();
        PoolConfiguration missileConfig = new PoolConfiguration
        {
            prefab = missile,
            prefabTagName = "Missile",
            poolSize = poolSize,
            initialPosition = GameConstants.poolStartPosition
        };

        PoolConfiguration fatMissileConfig = new PoolConfiguration
        {
            prefab = fatMissile,
            prefabTagName = "Missile",
            poolSize = poolSize,
            initialPosition = GameConstants.poolStartPosition
        };

        missilePool = new ObjectPool(missileConfig);
        fatMissilePool = new ObjectPool(fatMissileConfig);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameover)
        {
            return;
        }

        if (GameConstants.scrollingSpeed <= -14)
        {
            spawnRateMax = 2f;
        }
        else if (GameConstants.scrollingSpeed <= -10)
        {
            spawnRateMax = 4f;
        }
        else
        {
            spawnRateMax = 5f;
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
            float randomX = Random.Range(GameConstants.obstacleMinX, GameConstants.obstacleMaxX);
            GameObject obj;

            if (GameConstants.scrollingSpeed <= -14 && Random.value > .8f)
            {
                obj = fatMissilePool.BorrowFromPool();
            }
            else
            {
                obj = missilePool.BorrowFromPool();
            }

            obj.transform.position = new Vector2(randomX, GameConstants.spawnY);

            // rotate the missile 180 on the z axis
            obj.transform.rotation = Quaternion.Euler(0, 0, 180);
            arrowPool.SetArrow(GameConstants.ArrowColor.Red, obj.transform);

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
}
