using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collectItemParticle;
    [SerializeField] private ParticleSystem _newLevelParticle;

    private void OnEnable()
    {
        ItemCollector.Collect += PlayCollectItemParticle;
        PlayerScore.OnLevelUp += PlayNewLevelParticle;
    }

    private void PlayCollectItemParticle()
    {
        ActivateParticle(_collectItemParticle);
        StartCoroutine(PlayParticleAndDeactivate(_collectItemParticle));
    }

    private void PlayNewLevelParticle()
    {
        ActivateParticle(_newLevelParticle);
        StartCoroutine(PlayParticleAndDeactivate(_newLevelParticle));
    }

    private void ActivateParticle(ParticleSystem particle)
    {
        if (!particle.gameObject.activeSelf)
        {
            particle.gameObject.SetActive(true);
        }
    }

    private void DeactivateParticle(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
    }

    private IEnumerator PlayParticleAndDeactivate(ParticleSystem particle)
    {
        particle.Play();
        yield return new WaitForSeconds(particle.duration);
        DeactivateParticle(particle);
    }

    private void OnDisable()
    {
        ItemCollector.Collect -= PlayCollectItemParticle;
        PlayerScore.OnLevelUp -= PlayNewLevelParticle;
    }
}
