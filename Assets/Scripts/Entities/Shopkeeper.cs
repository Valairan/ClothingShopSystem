using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{

    public TextMeshProUGUI interactionText;
    public List<Shirt> inventory = new List<Shirt>();
    [SerializeField] Shirt redShirt, blueShirt, greenShirt;
    public Image[] shopkeeperCanvas;

    // Start is called before the first frame update
    void Start()
    {
        interactionText.SetText("");
        inventory.Add(redShirt);
        inventory.Add(blueShirt);
        inventory.Add(greenShirt);
        UpdateItems();

    }

    // Update is called once per frame


	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("Collided with something");
		if (collision.gameObject.CompareTag("Player"))
		{
            interactionText.SetText("Press E to interact...");
            collision.gameObject.GetComponent<Player>().shopOpenable = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
        interactionText.SetText("");
        Debug.Log("Something left");
        other.gameObject.GetComponent<Player>().shopOpenable = false;

    }


	public void UpdateItems()
	{
		foreach (Image item in shopkeeperCanvas)
		{
            item.sprite = null;
		}
        int index = 0;
        foreach (Shirt shirt in inventory)
        {
            try
            {
                shopkeeperCanvas[index].sprite = shirt.shirtIcon;
                index++;
            }
            catch
            {
                shopkeeperCanvas[index].sprite = null;
                continue;
            }

        }
        index = 0;

    }
}
