using UnityEngine;

public class Sunflower : Plant
{
    public float produceDuration = 5f;
    private float produceTimer = 0f;
    
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceDuration)
        {
            produceTimer = 0f;
            anim.SetTrigger("IsGlowing");
        }
    }
    public void ProduceSun()
    {
        print("ProduceSun");
    }
}
