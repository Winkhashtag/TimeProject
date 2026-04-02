using UnityEngine;

public class Switcher : Interactable
{
    public bool state;

    public override void Interact()
    {
        state = !state;
    }
}
