using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Shirt> playerInventory;
    public List<Shirt> shopkeeperInventory;

	private void Start()
	{
		playerInventory = FindObjectOfType<Player>().inventoryCurrent;
		shopkeeperInventory = FindObjectOfType<Shopkeeper>().inventory;
	}

	public void purchaseSomething(int index)
	{
        playerInventory.Add(shopkeeperInventory.ToArray()[index]);
        shopkeeperInventory.RemoveAt(index);
        int count = shopkeeperInventory.Count;
		for (int i = 0; i < count; i++)
		{
            if(shopkeeperInventory[i] == null)
			{
                int newCount = i++;
				for (; i < count; i++)
				{
					if (shopkeeperInventory[i] != null)
					{
						shopkeeperInventory[newCount++] = shopkeeperInventory[i];
					}
				}
				shopkeeperInventory.RemoveRange(newCount, count - newCount);
				break; 
			}
		}
	}
}
