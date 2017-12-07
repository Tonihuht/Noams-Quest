using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
	//Instantiates the variables needed
	private Stack<Item> items;
	public Text stackTxt;
	public Sprite slotEmpty;
	public Sprite slotHighlighted;

	/// <summary>
	/// Gets a value indicating whether the slot is empty or not.
	/// </summary>
	/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>

	public bool IsEmpty {
		get { return items.Count == 0; }
	}

	/// <summary>
	/// Gets a value indicating whether the slot is available or not.
	/// </summary>
	/// <value><c>true</c> if this instance is available; otherwise, <c>false</c>.</value>
	public bool IsAvailable {
		get { return CurrentItem.maxSize > items.Count; }
	}

	/// <summary>
	/// Gets the current item.
	/// </summary>
	/// <value>The current item.</value>
	public Item CurrentItem {
		get { return items.Peek (); }
	}


	void Start ()
	{
		//Instantiates the items list and defines the size of the slots
		items = new Stack<Item> ();
		RectTransform slotRect = GetComponent<RectTransform> ();
		RectTransform txtRect = stackTxt.GetComponent<RectTransform> ();
		int txtScaleFactor = (int)(slotRect.sizeDelta.x * 0.6);
		stackTxt.resizeTextMaxSize = txtScaleFactor;
		stackTxt.resizeTextMinSize = txtScaleFactor;
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);

	}

	/// <summary>
	/// Adds the item.
	/// </summary>
	/// <param name="item">Item.</param>
	public void AddItem (Item item)
	{
		items.Push (item);
		if (items.Count > 1) {
			stackTxt.text = items.Count.ToString ();
		}
		ChangeSprite (item.spriteNeutral, item.spriteHighlighted);
	}

	/// <summary>
	/// Changes the sprite of the item selected in the inventory.
	/// </summary>
	/// <param name="neutral">Neutral.</param>
	/// <param name="highlight">Highlight.</param>
	private void ChangeSprite (Sprite neutral, Sprite highlight)
	{
		GetComponent<Image> ().sprite = neutral;
		SpriteState st = new SpriteState ();
		st.highlightedSprite = highlight;
		st.pressedSprite = neutral;
		GetComponent<Button> ().spriteState = st;
	}

	/// <summary>
	/// Uses the item selected from the inventory
	/// </summary>
	private void UseItem ()
	{
		if (!IsEmpty) {
			items.Pop ().Use ();
			stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;
			if (IsEmpty) {
				ChangeSprite (slotEmpty, slotHighlighted);
				Inventory.current.EmptySlots++;
			}
		}
	}

	/// <summary>
	/// Raises the pointer click event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			UseItem ();
		}
	}
}
