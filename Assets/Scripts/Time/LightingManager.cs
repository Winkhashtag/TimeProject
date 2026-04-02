using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{

    //Refereness
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField] private float dayDuration = 120f; //duration in seconds
    private int lastDay = 0;

    //variables
    [SerializeField, Range(0,24)] private float timeOfDay;

    private void Update()
    {
        if (preset == null)
            return;

        if(Application.isPlaying)
        {
            timeOfDay += Time.deltaTime /dayDuration * 24;
            timeOfDay %= 24;

            //convert to int day number
            int currentDayNumber = Mathf.FloorToInt(timeOfDay);

            //if we crossed 23 to 0, trigger DayManager
            if (currentDayNumber < lastDay)
            {
                DayManager.ins.CompleteDay();
            }
            lastDay = currentDayNumber;

            UpdateLighting(timeOfDay / 24f);
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if(directionalLight!= null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360) - 90f, 170f, 0));
        }
    }
    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsByType<Light>(FindObjectsSortMode.None);
            foreach (Light light in lights)
            {

                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
