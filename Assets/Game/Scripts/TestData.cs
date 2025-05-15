using UnityEngine;
using YG;

public class TestData : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Coins - {YG2.saves.coins}");
        
        Debug.Log($"Money - {YG2.saves.gameData.money}");
    }
    
}
