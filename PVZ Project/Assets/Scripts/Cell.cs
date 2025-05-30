using UnityEngine;

public class Cell : MonoBehaviour
{
    public Plant currentPlant;
    private void OnMouseDown()
    {
        HandManager.Instance.OnCellClick(this);
    }

    public bool AddPlant(Plant plant)
    {
        if (currentPlant != null) return false;
        currentPlant = plant;
        currentPlant.transform.position = transform.position;
        plant.TransitionToEnable();
        return true;
    }
}
