//Terry James Project 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates and asset in the UI menu that creates the fields based on the variable in this object
[CreateAssetMenu(fileName = "New Item", menuName ="ItemClass")]
public class ItemClass : ScriptableObject {

    // Variables used for Item Class object
    public string itemName;
    public double price, totalCost;
    public string itemDescription;
    private int quantity;
    public Sprite image;

    // gets the current item name
    public string getItemName(){
        return this.itemName;
    }

    // gets the current item price
    public double getPrice(){
        return this.price;
    }

    // gets the current total cost for an item
    public double getTotalCost(){
        return this.totalCost;
    }

    // sets the total of an item to whatever amount is
    public void setTotalCost(double amount){
        this.totalCost = amount;
    }

    // set the name of an item
    public void newName(string name){
        this.itemName = name;
    }

    // get the current quantity for an item
    public int getQuantity(){
        return this.quantity;
    }

    // increase the quantity of an item
    public void incQuantity(){
        this.quantity++;
    }

    // decrease the quantity of an item
    public void decQuantity(){
        if(this.quantity == 0){ // make sure quantity can not go below zero
            this.quantity = 0;

        }
        else{
            this.quantity--;
        }
    }

    // resets value for app restart
    public void resetValue(){
        this.quantity = 0;
        this.totalCost = 0;
    }
}
