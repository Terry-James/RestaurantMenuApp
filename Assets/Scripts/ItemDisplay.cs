// Terry James Project 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

    // create and item class object to allow use of its methods
    public ItemClass item;

    // Display objects
    public Text itemName;
    public Text price, totalCost;
    public Text itemDescription;
    public Text quantity;
    public Image image;


	// Use this for initialization
	void Start () {
        // display initial values held by objects
        itemName.text = item.itemName;
        price.text = item.price.ToString();
        itemDescription.text = item.itemDescription;
        quantity.text = item.getQuantity().ToString();
        image.sprite = item.image;
        totalCost.text = item.getTotalCost().ToString();
	}
	

}
