using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance{get; private set;}

    public List<Plant> plantPrefabList;
    
    private Plant currentPlant;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
    }

    public bool AddPlant(PlantType plantType)
    {
        if (currentPlant != null) return false;
        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null)
        {
            print("要种植的植物不存在");
            return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        return true;
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabList)
        {
            if (plant.plantType == plantType)
            {
                return plant;
            }
        }
        return null;
    }

    void FollowCursor()
    {
        if (currentPlant == null) return;
        Vector3 mouseWordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWordPosition.z = 0;
        currentPlant.transform.position = mouseWordPosition;
        
    }
}
