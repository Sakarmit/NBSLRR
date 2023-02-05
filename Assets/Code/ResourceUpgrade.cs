using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceUpgrade : MonoBehaviour
{
    [SerializeField] int startUpgradeCost;
    int upgradeCost;
    [SerializeField] int startCostScaler;
    int costScaler;
    [SerializeField] PlayerBase playerBase;

    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        text.text = "Cost: " + startUpgradeCost.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnMouseDown();
        }
    }
    private void OnMouseDown()
    {
        if (playerBase.gameObject.activeSelf && playerBase.sunResource >= upgradeCost)
        {
            playerBase.sunResource -= upgradeCost;
            playerBase.resourceRate++;
            upgradeCost *= costScaler;
            GetComponent<AudioSource>().Play();
            text.text = "Cost: " + upgradeCost.ToString();
        }
    }
    public void SetDefaults()
    {
        upgradeCost = startUpgradeCost;
        costScaler = startCostScaler;
    }
}
