using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDecay : MonoBehaviour
{
    public GameObject TorchLight;

    [SerializeField] ParticleSystem mainFlame;
    [SerializeField] ParticleSystem baseFlame;
    [SerializeField] ParticleSystem enticelles;
    [SerializeField] ParticleSystem fumee;

    ParticleSystem.MainModule mainFlameMain;
    ParticleSystem.MainModule baseFlameMain;
    ParticleSystem.MainModule enticellesMain;
    ParticleSystem.MainModule fumeeMain;

    [SerializeField] float lightDecay;
    [SerializeField] float emissionDecay;

    public float mainFlameSizeOverTime;
    public float baseFlameSizeOverTime;
    public float enticellesSizeOverTime;
    public float fumeeSizeOverTime;

    public float mainFlameSizeMax;
    public float baseFlameSizeMax;
    public float enticellesSizeMax;
    public float fumeeSizeMax;

    float maxLightIntensity; 

    Light flameLight;

    private void Awake()
    {
        mainFlameSizeMax = mainFlameSizeOverTime;
        baseFlameSizeMax = baseFlameSizeOverTime;
        enticellesSizeMax = enticellesSizeOverTime;
        fumeeSizeMax = fumeeSizeOverTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainFlameMain = mainFlame.main;
        baseFlameMain = baseFlame.main;
        enticellesMain = enticelles.main;
        fumeeMain = fumee.main;

        flameLight = TorchLight.GetComponent<Light>();
        maxLightIntensity = flameLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {       
        DescreaseLightIntensity();
        DecreaseEmissionsSize();
    }

    private void DescreaseLightIntensity()
    {
        if (mainFlameSizeOverTime <= 0f)
        {
            flameLight.intensity = 0f;
        }
        else if (mainFlameSizeOverTime > 0f)
        {
            flameLight.intensity -= lightDecay * Time.deltaTime;
        }
    }

    private void DecreaseEmissionsSize()
    {
        mainFlameMain.startSize = mainFlameSizeOverTime;
        baseFlameMain.startSize = baseFlameSizeOverTime;
        enticellesMain.startSize = enticellesSizeOverTime;
        fumeeMain.startSize = fumeeSizeOverTime;

        if (mainFlameSizeOverTime >= 0f)
        {
            mainFlameSizeOverTime -= emissionDecay * Time.deltaTime;
        }

        if (baseFlameSizeOverTime >= 0f)
        {
            baseFlameSizeOverTime -= emissionDecay * Time.deltaTime;
        }

        if (enticellesSizeOverTime >= 0f)
        {
            enticellesSizeOverTime -= emissionDecay * Time.deltaTime;
        }

        if (fumeeSizeOverTime >= 0f)
        {
            fumeeSizeOverTime -= emissionDecay * Time.deltaTime;
        }
    }

    public void RelightTorch()
    {
        mainFlameSizeOverTime = mainFlameSizeMax;

        baseFlameSizeOverTime = baseFlameSizeMax;
        enticellesSizeOverTime = enticellesSizeMax;
        fumeeSizeOverTime = fumeeSizeMax;

        flameLight.intensity = maxLightIntensity;
    }

}
