using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

using Faded.Town;

public class VFXManager : Singleton<VFXManager>
{
    public static VFXManager instance;

    [SerializeField] private Volume volume; 

    [Header("Bloom")]
    private Bloom bloom;
    [SerializeField] private float intensityMin = 0f; 
    [SerializeField] private float intensityMax = 1f; 
    [SerializeField] private float cycleDuration = 2f; 
    private float bloomTimer = 0f;

    void Start()
    {
        volume.profile.TryGet<Bloom>(out bloom);
    }

    void Update()
    {
        OnUpdateBloom();
    }

    private void OnUpdateBloom()
    {
        bloomTimer += Time.deltaTime;
        float cycleFraction = bloomTimer / cycleDuration;
        float intensity = Mathf.Lerp(intensityMin, intensityMax, Mathf.Sin(cycleFraction * 2 * Mathf.PI) * 0.5f + 0.5f);
        //float intensity = Mathf.Lerp(intensityMin, intensityMax, Mathf.PerlinNoise1D(cycleFraction * 0.1f) * 0.5f + 0.5f);
        
        bloom.intensity.Override(intensity);
    }


}
