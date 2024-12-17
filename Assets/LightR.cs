using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightR : MonoBehaviour
{
    [SerializeField] public Light2D c;
    [SerializeField] public Light2D b;
    [SerializeField] public Light2D d;
    [SerializeField] public Light2D e;
    [SerializeField] public Light2D f;
    [SerializeField] public Light2D g;
    [SerializeField] public Light2D h;
    [SerializeField] public Light2D i;
    [SerializeField] public Light2D j;
    [SerializeField] public Light2D k;
    [SerializeField] public Light2D l;
    [SerializeField] public Light2D m;

    List<Light2D> lights;

    private void Start()
    {
        lights = new List<Light2D>();
        lights.Add(c);
        lights.Add(b);
        lights.Add(d);
        lights.Add(e);
        lights.Add(f);
        lights.Add(g);
        lights.Add(h);
        lights.Add(i);
        lights.Add(j);
        lights.Add(k);
        lights.Add(l);
        lights.Add(m);
     
    }
    void Update()
    {
        foreach(var a in lights) {
            if (GameManager.Instance.dayTimeController.Hours >= 18)
            {
                if (a.intensity >= 2)
                {
                    a.intensity += 0;
                }
                else
                {
                    a.intensity += (GameManager.Instance.dayTimeController.Hours - 18) / 70;
                }

            } else if (GameManager.Instance.dayTimeController.Hours <= 6 && a.intensity >= 0)
            {
                a.intensity -= (GameManager.Instance.dayTimeController.Hours) / 100;
            }
            else
            {
                a.intensity = 0;

            }
        }
        
    }
}
