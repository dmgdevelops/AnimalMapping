using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField] private Material one;
    [SerializeField] private Material two;
    [SerializeField] private Material three;
    //Variables
    [SerializeField, Range(0, 300)] public int TimeOfDay; //cycle last 10 minutes



    // below all the numbers are hardcoded so that the cycle lasts 10 minutes
    // the left product in the conditional represents the time of day in a 24 hour system
    // the right product represents how many seconds wihtin each hour for a 10 minute cycle

    private void Update()
    {
        if (Preset == null)
            return;

        
    }

    private void Start()
    {
        StartCoroutine(TimeCycle());
    }

    

    IEnumerator TimeCycle()
    {
        

 
        while(Application.isPlaying)
        {
            yield return new WaitForSeconds(1);
            TimeOfDay += 1;
            TimeOfDay %= 300; //Clamp between 0-24
            UpdateLighting(TimeOfDay / 300f);

            if (TimeOfDay >= 5 * 12.5 && TimeOfDay < 7 * 12.5)
            {
                RenderSettings.skybox = two;
            }
            else if (TimeOfDay >= 7 * 12.5 && TimeOfDay < 17 * 12.5)
            {
                RenderSettings.skybox = three;
            }
            else if (TimeOfDay >= 17 * 12.5 && TimeOfDay < 19 * 12.5)
            {
                RenderSettings.skybox = two;
            }
            else
            {
                RenderSettings.skybox = one;
            }

            
        }
            
        //}
        //else
        //{
        //    UpdateLighting(TimeOfDay / 180f);
        //}
    }





    public float getTimeOfDay()
    {
        return TimeOfDay;
    }


    

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }




    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
