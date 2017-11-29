using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
	public static Inventory current;

	//Instantiates different variables
	private RectTransform inventoryRect;
	private float inventoryWidth;
	private float inventoryHeight;
	public int slots;
	public int rows;
	public float slotPaddingLeft;
	public float slotPaddingTop;
	public float slotSize;
	public GameObject slotPrefab;
	private List<GameObject> allSlots;

	private int emptySlots;

	public int EmptySlots {
		get { return emptySlots; }
		set { emptySlots = value; }
	}

	void Awake() {
		current = this;
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		CreateLayout ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	/// <summary>
	/// Creates the layout of the inventory
	/// </summary>
	public void CreateLayout ()
	{
		allSlots = new List<GameObject> ();
		emptySlots = slots;
		inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
		inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;
		inventoryRect = GetComponent<RectTransform> ();
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, inventoryWidth);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, inventoryHeight);
		int columns = slots / rows;

		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < columns; x++) {
				GameObject newSlot = (GameObject)Instantiate (slotPrefab);
				RectTransform slotRect = newSlot.GetComponent<RectTransform> ();
				newSlot.name = "Slot";
				newSlot.transform.SetParent (this.transform.parent);
				slotRect.localPosition = inventoryRect.localPosition + new Vector3 (slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);
				allSlots.Add (newSlot);

			}
		}
	}

	/// <summary>
	/// Adds the item to the inventory
	/// </summary>
	/// <returns><c>true</c>, if item was added, <c>false</c> otherwise.</returns>
	/// <param name="item">Item.</param>
	public bool AddItem (Item item)
	{
		if (item.maxSize == 1) {
			PlaceEmpty (item);
			return true;
		} else {
			foreach (GameObject slot in allSlots) {
				Slot tmp = slot.GetComponent<Slot> ();
				if (!tmp.IsEmpty) {
					if (tmp.CurrentItem.type == item.type && tmp.IsAvailable) {
						tmp.AddItem (item);
						return true;
					}
				}
			}
			if (emptySlots > 0) {
				PlaceEmpty (item);
			}
		}
		return false;
	}

	/// <summary>
	/// Places the item into an empty slot if stacks are full
	/// </summary>
	/// <returns><c>true</c>, if empty was placed, <c>false</c> otherwise.</returns>
	/// <param name="item">Item.</param>
	public bool PlaceEmpty (Item item)
	{
		if (emptySlots > 0) {
			foreach (GameObject slot in allSlots) {
				Slot tmp = slot.GetComponent<Slot> ();
				if (tmp.IsEmpty) {
					tmp.AddItem (item);
					emptySlots--;
					return true;
				}
			}
		}
		return false;
	}
}
