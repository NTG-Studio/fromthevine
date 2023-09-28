using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nova;

public class buttonHover : MonoBehaviour
{
    public Interactable Button = null;
    public AudioClip hoverSound;
    // Start is called before the first frame update
    void OnEnable()
    {
        Button = GetComponent<Interactable>();
        Button.UIBlock.AddGestureHandler<Gesture.OnHover>(HandleHoverEvent);
    }

    private void HandleHoverEvent(Gesture.OnHover evt)
    {
        gameManager.instance.SpawnSound(hoverSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
