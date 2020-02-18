using UnityEngine;
using System.Collections;
using System;

public class Torchelight : MonoBehaviour {
	
	public GameObject TorchLight;
	public GameObject MainFlame;
	public GameObject BaseFlame;
	public GameObject Etincelles;
	public GameObject Fumee;
	public float MaxLightIntensity;
	public float IntensityLight;

    void Start () {

        TorchLight.GetComponent<Light>().intensity = IntensityLight;

        TorchLight.GetComponent<Light>().intensity = IntensityLight = MaxLightIntensity;

        var mainFlameEmissionRate = MainFlame.GetComponent<ParticleSystem>().emission;
        mainFlameEmissionRate.rateOverTime = IntensityLight * 20f;

        var baseFlameEmissionRate = BaseFlame.GetComponent<ParticleSystem>().emission;
        baseFlameEmissionRate.rateOverTime = IntensityLight*15f;

        var entincellesEmissionRate = Etincelles.GetComponent<ParticleSystem>().emission; 
        entincellesEmissionRate.rateOverTime = IntensityLight*7f;

        var fumeeEmissionRate = Fumee.GetComponent<ParticleSystem>().emission; 
        fumeeEmissionRate.rateOverTime = IntensityLight*12f;
	}
	

	void Update () {
		if (IntensityLight<0) IntensityLight=0f;
		if (IntensityLight>MaxLightIntensity) IntensityLight=MaxLightIntensity;

		TorchLight.GetComponent<Light>().color=new Color(Mathf.Min(IntensityLight/1.5f,1f),Mathf.Min(IntensityLight/2f,1f),0f);

        var mainFlameEmissionRate = MainFlame.GetComponent<ParticleSystem>().emission;
        mainFlameEmissionRate.rateOverTime = IntensityLight * 20f;

        var baseFlameEmissionRate = BaseFlame.GetComponent<ParticleSystem>().emission;
        baseFlameEmissionRate.rateOverTime = IntensityLight * 15f;

        var entincellesEmissionRate = Etincelles.GetComponent<ParticleSystem>().emission;
        entincellesEmissionRate.rateOverTime = IntensityLight * 7f;

        var fumeeEmissionRate = Fumee.GetComponent<ParticleSystem>().emission;
        fumeeEmissionRate.rateOverTime = IntensityLight * 12f;

    }
}
