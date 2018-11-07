// Terry James Project 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillingDisplay : MonoBehaviour {

    // Creates a BillingInfo object to allow use of all its methods
    public BillingInfo items;

    // Display variables to output onto the screen
    public Text orderTotal;
    public Text tip;
    public Text finalAmount;
    public Text customerCount;
    public Text evenBilling;


	// Use this for initialization
	void Start () {

        // Displays the initial values held for each variable
        orderTotal.text = items.getOrderTotal().ToString(); 
        tip.text = items.tip.ToString(); 
        finalAmount.text = items.finalAmount.ToString(); 
        customerCount.text = items.customerCount.ToString(); 
        evenBilling.text = items.evenBill.ToString();

	}
	
	
}
