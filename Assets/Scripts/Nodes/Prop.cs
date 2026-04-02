using UnityEngine;

public class Prop : Node
{
    public Location loc;
    Interactable inter;

    private void Start()
    {
        inter = GetComponent<Interactable>();
    }

    public override void Arrive()
    {
        if (inter != null && inter.enabled)
        {
            inter.Interact();
            return;
        } 
            

        base.Arrive();

        //make this object interactable if prerequisite is met
        if (inter != null)
        {
            if (GetComponent<Prerequisite>() != null && !GetComponent<Prerequisite>().Complete)
            { 
                return;
            }
                col.enabled = true;


                inter.enabled = true;
            
        }
    }

    public override void Leave()
    {
        base.Leave();

        if (inter != null)
        {
            inter.enabled = false;
        }
    }
}
