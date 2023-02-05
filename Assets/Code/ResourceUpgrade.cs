using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUpgrade : MonoBehaviour
{
    [SerializeField] float upgradeCost;
    [SerializeField] float costScaler;
    [SerializeField] PlayerBase playerBase;
    private void OnMouseDown()
    {
        if (playerBase.sunResource >= upgradeCost)
        {
            playerBase.resourceRate++;
            upgradeCost *= costScaler;
        }
    }
}
