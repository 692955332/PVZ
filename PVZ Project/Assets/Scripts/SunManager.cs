using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance { get; private set; }

    [SerializeField]
    private int sunPoint;
    public TextMeshProUGUI sunPointText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        sunPoint = 0;
        UpdateSunPointText();
    }
    public int SunPoint
    {
        get { return sunPoint; }
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
}
