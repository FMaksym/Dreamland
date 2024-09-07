using System;
using System.Collections;
using UnityEngine;

public class AdRewardZoneTrigger : MonoBehaviour
{
    [SerializeField] private ZoneReward _reward;

    public delegate void PlayerInAdRewardZoneDelegate(ZoneReward reward);
    public static event PlayerInAdRewardZoneDelegate OnPlayerInAdRewardZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerTouchMovement>())
        {
            OnPlayerInAdRewardZone?.Invoke(_reward);
        }
    }
}
