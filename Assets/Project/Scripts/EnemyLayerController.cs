using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLayerController : MonoBehaviour
{
    public static int enemy_score;
    [SerializeField]
    LayerMask enemyDeadLayer;

    private void Start()
    {
        enemy_score = 0;
    }

    public void ChangeEnemyLayerToDead()
    {
        var layerID = (int)Mathf.Log(enemyDeadLayer.value, 2);
        SetLayerRecursively(gameObject, layerID);
        enemy_score += 1;
        //Debug.Log(enemy_score);
    }
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
