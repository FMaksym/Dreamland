using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyObjectParticleHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _buyObjectParticle;
    private IPurchasable _buyingObject;

    private void OnEnable()
    {
        _buyingObject = GetComponentInParent<IPurchasable>();
        PlayParticle();
    }

    private void PlayParticle()
    {
        if (_buyingObject != null && _buyingObject.ObjectIsActive())
        {
            ActivateParticle(_buyObjectParticle);
            StartCoroutine(PlayParticleAndDeactivate(_buyObjectParticle));
        }
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
}
