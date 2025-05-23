using UnityEngine;


enum PlantState
{
    Disable,
    Enable,
}
public class Plant : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.Sunflower;
    void Start()
    {
        TransitionToDisable();
    }
    
    void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
            default:
                break;
        }
    }

    void DisableUpdate()
    {
        
    }

    protected virtual void EnableUpdate()
    {
        
    }

    void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
    }

    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
    }


}
