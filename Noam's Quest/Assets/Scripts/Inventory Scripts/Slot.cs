﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler{

	private Stack<Item> items;
	public Text stackTxt;
	public Sprite slotEmpty;
	public Sprite slotHighlighted;

	public bool IsEmpty {
		get { return items.Count == 0; }
	}

	public bool IsAvailable {
		get {return CurrentItem.maxSize > items.Count;}
	}

	public Item CurrentItem {
		get { return items.Peek (); }
	}

	// Use this for initialization
	void Start () {
		items = new Stack<Item> ();
		RectTransform slotRect = GetComponent<RectTransform> ();
		RectTransform txtRect = stackTxt.GetComponent<RectTransform> ();
		int txtScaleFactor = (int)(slotRect.sizeDelta.x * 0.75);
		stackTxt.resizeTextMaxSize = txtScaleFactor;
		stackTxt.resizeTextMinSize = txtScaleFactor;
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem(Item item){
		items.Push (item);
		if (items.Count > 1) {
			stackTxt.text = items.Count.ToString ();
		}
		ChangeSprite (item.spriteNeutral, item.spriteHighlighted);
	}

	private void ChangeSprite (Sprite neutral, Sprite highlight){
		GetComponent<Image> ().sprite = neutral;
		SpriteState st = new SpriteState ();
		st.highlightedSprite = highlight;
		st.pressedSprite = neutral;
		GetComponent<Button> ().spriteState = st;
	}

	private void UseItem () {
		if (!IsEmpty) {
			items.Pop ().Use ();
			stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;
			if (IsEmpty) {
				ChangeSprite (slotEmpty, slotHighlighted);
				Inventory.EmptySlots++;
			}
		}
	}

	public void OnPointerClick (PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Right) {
			UseItem ();
		}
	}
}
