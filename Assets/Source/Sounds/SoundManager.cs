using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip levelUpSound;
    public AudioClip collectItemSound;
    public AudioClip buyLandSound;
    public AudioClip buyBuildSound;

    [SerializeField] private AudioSource audioSource;

    void OnEnable()
    {
        PlayerScore.OnLevelUp += PlayLevelUpSound;
        ItemCollector.Collect += CollectItemSound;
        PlayerLandPurchase.BuyLand += PlayBuyLandSound;
        PlayerBildPurchase.BuyBuild += PlayBuyBuildSound;
    }

    public void PlayButtonSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    private void PlayLevelUpSound()
    {
        audioSource.PlayOneShot(levelUpSound);
    }

    private void CollectItemSound()
    {
        audioSource.PlayOneShot(collectItemSound);
    }

    private void PlayBuyLandSound()
    {
        audioSource.PlayOneShot(buyLandSound);
    }

    private void PlayBuyBuildSound()
    {
        audioSource.PlayOneShot(buyBuildSound);
    }

    void OnDestroy()
    {
        PlayerScore.OnLevelUp -= PlayLevelUpSound;
        ItemCollector.Collect -= CollectItemSound;
        PlayerLandPurchase.BuyLand -= PlayBuyLandSound;
        PlayerBildPurchase.BuyBuild -= PlayBuyBuildSound;
    }
}
