using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimecontro : MonoBehaviour
{
    const float secondsInDay = 86400f;

    
    [SerializeField] Color morCol;
    [SerializeField] Color dayCol;
    [SerializeField] Color eveCol;
    [SerializeField] Color nightCol;
    [SerializeField] AnimationCurve nightMorning;
    [SerializeField] AnimationCurve morningDay;
    [SerializeField] AnimationCurve dayEvening;
    [SerializeField] AnimationCurve eveningNight;
    

    public float time { get; private set; }
    public int days { get ; private set; }  
    [SerializeField] float timeScale;
    [SerializeField] TMP_Text text;
    [SerializeField] Light2D globalLight;
    [SerializeField] GameObject[] targetObjects;
    public float Hours
    {
        get { return time / 3600f; }
        private set { }
    }

    public float Minutes
    {
        get { return time / 60f; }
        private set { }
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;
        text.text = Hours.ToString();
        
        float nM = nightMorning.Evaluate(Hours);
        float mD = morningDay.Evaluate(Hours);
        float dE = dayEvening.Evaluate(Hours);
        float eN = eveningNight.Evaluate(Hours);
        Color c = Color.white;
        if (Hours >= 6 && Hours < 11) 
        {
            c = Color.Lerp(morCol, dayCol, mD);
        }
        else if (Hours >= 11 && Hours < 16)
        {
            c = Color.Lerp(dayCol,  eveCol, dE);
        }
        else if (Hours >= 16 && Hours < 25) 
        {
            c = Color.Lerp(eveCol, nightCol, eN);
        }
        else if (Hours < 6) 
        {
            c = Color.Lerp(nightCol, morCol, nM);
        }
        
        globalLight.color = c;
        if (time > secondsInDay) {
            NextDay();

        }

        if (Hours >= 18 && Hours <= 24)
        {
            ToggleVisible(true); // Make all targets visible
        }
        else
        {
            ToggleVisible(false); // Hide all targets
        }

    }
    private void ToggleVisible(bool isVisible)
    {
        foreach (GameObject target in targetObjects)
        {
            if (target != null && target.activeSelf != isVisible)
            {
                target.SetActive(isVisible);
                //Debug.Log($"{target.name} visibility set to: {isVisible}");
            }
        }
    }
    private void NextDay()
    {
        time = 0;
        days += 1;
    } 
}
