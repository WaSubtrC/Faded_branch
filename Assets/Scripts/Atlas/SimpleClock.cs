using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class SimpleClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    private DateTime time;

    void Start()
    {
        time = new DateTime(3059, 3, 1, 9, 10, 0);
    }

    void Update()
    {
        time = time.AddMinutes(Time.deltaTime);
        clockText.text = $"Year:{time.Year} Mouth:{time.Month} Day:{time.Day}  {time.Hour}:{time.Minute}";
    }
}