using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnemyCounter : MonoBehaviour
{
    public int EnemyCount { get; private set; }

    private void Awake()
    {
        EnemyCount = GetEnemyCount();
        SubscribeToEnemyPlayerCollisions();
    }

    private int GetEnemyCount()
    {
        int enemyCount = 0;
        try
        {
            enemyCount = FindObjectsOfType<EnemyAIController>().Length;
        }
        catch (System.Exception)
        {
            return 0;
        }
        return enemyCount;
    }

    private void SubscribeToEnemyPlayerCollisions()
    {
        var enemies = FindObjectsOfType<EnemyCollisionController>();
        foreach (var enemy in enemies)
        {
            enemy.OnCollidedWithBall += Enemy_OnCollidedWithBall;
        }
    }

    private void Enemy_OnCollidedWithBall()
    {
        EnemyCount -= 1;
    }
}
