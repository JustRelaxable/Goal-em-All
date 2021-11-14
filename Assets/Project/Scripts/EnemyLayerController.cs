using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLayerController : MonoBehaviour
{
    [SerializeField]
    LayerMask enemyDeadLayer;

    public void ChangeEnemyLayerToDead()
    {
        var layerID = (int)Mathf.Log(enemyDeadLayer.value, 2);
        SetLayerRecursively(gameObject, layerID);
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
