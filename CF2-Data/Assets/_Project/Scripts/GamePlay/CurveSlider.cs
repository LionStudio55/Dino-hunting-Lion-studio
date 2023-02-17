using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurveSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public Image _Bar;
    public RectTransform button;
    public float _ScopeValue;

   

    // Update is called once per frame
    void Update()
    {
        ZoomControl(_ScopeValue);
    }
    void ZoomControl(float ScopeValue)
    {
        float amount = (ScopeValue / 100.0f) * 180.0f / 360.0f;
        _Bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);

    }
}
