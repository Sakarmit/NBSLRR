using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUpgrade : MonoBehaviour
{
    [SerializeField] int upgradeCost;
    [SerializeField] int costScaler;
    [SerializeField] PlayerBase playerBase;
    private void OnMouseDown()
    {
        if (playerBase.sunResource >= upgradeCost)
        {
            playerBase.sunResource -= upgradeCost;
            playerBase.resourceRate++;
            upgradeCost *= costScaler;
            GetComponent<AudioSource>().Play();
        }
    }
}
