using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Inherent properties")]
    [SerializeField]private float heatlh;
    [SerializeField] private int wealth;
    public List<Shirt> inventoryCurrent = new List<Shirt>();
    public GameObject playerHead;
    public GameObject playerBody;
    public string currentlyEquipedHead;
    public string currentlyEquipedBody;
    public GameObject inventoryMenu, shopMenu;
    public Image[] shopPlayerInventory;
    public Image[] InventoryMenuIcons;



    public bool shopOpenable;
    private int currentInvSlot = 1;
    public Shirt blueShirt, redShirt, greenShirt;
    
    


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
        equipedNow = blueShirt;
        inventoryCurrent.Add(equipedNow);

        currentlyEquipedBody = equipedNow.name;
        updateItems();
        
    }

    // Update is called once per frame
    public void Update()
	{
		if(playerMover.inventoryKey)
		{
            
            inventoryMenu.SetActive(!inventoryMenu.activeSelf);
            updateItems();
        }
        if (playerMover.interactKey && shopOpenable)

        {
            shopMenu.SetActive(!shopMenu.activeSelf);
        }

    }


    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + playerMover.movedirection.normalized * playerMover.Speed * Time.fixedDeltaTime);
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

        playerAnimatorBody.runtimeAnimatorController = (RuntimeAnimatorController) Resources.Load("Animations/Body/"+currentlyEquipedBody, typeof(RuntimeAnimatorController));
    }

    public void inventoryQuickSlots(int index)
	{

	}

    public void updateItems()
	{
		foreach (Image item in InventoryMenuIcons)
		{
            item.sprite = null;

		}
        foreach (Image item in shopPlayerInventory)
        {
            item.sprite = null;

        }
        int index = 0;
        foreach (Shirt item in inventoryCurrent)
        {
            try
            {
                InventoryMenuIcons[index].sprite = item.shirtIcon;
                shopPlayerInventory[index].sprite = item.shirtIcon;
                index++;
            }
            catch
            {
                break;
            }
        }
        index = 0;
    }
}
