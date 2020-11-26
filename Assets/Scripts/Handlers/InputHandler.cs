using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public float Speed;
    public float HorizontalAxis;
    public float VerticalAxis;
    public bool interactKey;
    public bool fightKey;
    public bool inventoryKey;

    public Vector2 movedirection;


    // Update is called once per frame
    void Update()
    {

        HorizontalAxis = Input.GetAxisRaw("Horizontal");
        VerticalAxis = Input.GetAxisRaw("Vertical");
        movedirection.x = HorizontalAxis;
        movedirection.y = VerticalAxis;
        movedirection = (movedirection * Speed);
        interactKey = Input.GetKeyDown(KeyCode.E);
        fightKey = Input.GetKeyDown(KeyCode.Space);
        inventoryKey = Input.GetKeyDown(KeyCode.Tab);
    }
}
