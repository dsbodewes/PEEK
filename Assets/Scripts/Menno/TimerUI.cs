using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    float TimerCount = 0.1f;
    float HoldCount;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>();
        HoldCount = TimerCount;
    }

    // Update is called once per frame
    void Update()
    {
        HoldCount += Time.deltaTime;
        SetValue();
    }

    public void SetValue()
    {
        GetComponent<Slider>().value = HoldCount;
    }

    public void ResetValue()
    {
        HoldCount = 0.0f;
        SetValue();
    }
}
