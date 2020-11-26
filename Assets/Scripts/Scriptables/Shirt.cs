using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Shirts", order = 1)]
public class Shirt : ScriptableObject
{
	public Sprite shirtIcon;
	public string equipedName;
}
