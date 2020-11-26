using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Inherent properties")]
    [SerializeField]private float heatlh;
    [SerializeField] private int wealth;
    private List<Shirt> inventory;
    public GameObject playerHead;
    public GameObject playerBody;
    public string currentlyEquipedHead;
    public string currentlyEquipedBody;
    public GameObject inventoryMenu, shopMenu;
    public bool shopOpenable;
    private int currentInvSlot = 1;
    


    [Header("Animator properties")]
    public Animator playerAnimatorHead;
    public Animator playerAnimatorBody;
    public string equipedItemName;
    public Shirt equipedNow;


    public InputHandler playerMover;
    public Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerMover = GetComponent<InputHandler>();
        playerRB = GetComponent<Rigidbody2D>();
        inventory.Add(equipedNow);

    }

	// Update is called once per frame
	public void Update()
	{
		if(playerMover.inventoryKey)
		{
            inventoryMenu.SetActive(!inventoryMenu.activeSelf);
		}
        if (playerMover.interactKey && shopOpenable)
        {
            shopMenu.SetActive(!shopMenu.activeSelf);
        }

    }


    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + playerMover.movedirection * Time.fixedDeltaTime);
        CombinedAnimationController();
        
    }

    public void CombinedAnimationController()
	{
        //Controls the animation for the head
        playerAnimatorHead.SetFloat("Horizontal", playerMover.HorizontalAxis);
        playerAnimatorHead.SetFloat("Vertical", playerMover.VerticalAxis);
        playerAnimatorHead.SetFloat("Speed", playerMover.movedirection.sqrMagnitude);

        //Controls the animation for the body
        playerAnimatorBody.SetFloat("Horizontal", playerMover.HorizontalAxis);
        playerAnimatorBody.SetFloat("Vertical", playerMover.VerticalAxis);
        playerAnimatorBody.SetFloat("Speed", playerMover.movedirection.sqrMagnitude);
    }

    public void EquipItem()
	{

        playerAnimatorBody.runtimeAnimatorController = (RuntimeAnimatorController) Resources.Load("Animations/Body/"+equipedItemName, typeof(RuntimeAnimatorController));
    }

    public void inventoryQuickSlots(int index)
	{

	}
}
