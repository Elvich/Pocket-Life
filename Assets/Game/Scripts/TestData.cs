using System;
using UnityEngine;
using YG;

public class TestData : MonoBehaviour
{
    
    void Start()
    {
        Up();
    }

    private void Up()
    {
        YG2.saves.gameData.money += 5;
        YG2.SaveProgress();
        Debug.Log($"Money - {YG2.saves.gameData.money}");
    }
}
