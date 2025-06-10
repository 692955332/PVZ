using System;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance { get; private set; }

    [SerializeField]
    private int sunPoint;
    public TextMeshProUGUI sunPointText;
    public float produceTime;
    private float produceTimer;
    private Vector3 sunPointTextPosition;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        sunPoint = 0;
        UpdateSunPointText();
        CalcSunPointTextPosition();
    }
    public int SunPoint
    {
        get { return sunPoint; }
    }

    private void Update()
    {
        ProduceSun();
    }

    private void UpdateSunPointText()
    {
        sunPointText.text = sunPoint.ToString();
    }
    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }

    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPointText();
    }

    void ProduceSun()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer >= produceTime)
        {
            produceTimer = 0;
            
        }
    }

    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }

    private void CalcSunPointTextPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        position.z = 0;
        sunPointTextPosition = position;
    }
}
