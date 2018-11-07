// Terry James Project 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates and asset in the UI menu that creates the fields based on the variable in this object
[CreateAssetMenu(fileName = "The Bill", menuName = "BillingInfo")]
public class BillingInfo : ScriptableObject {

    // variables
    public double orderTotal, tip, finalAmount, evenBill;
    public int percent, customerCount;

    // reset values back to initial
    public void resetValues(){
        this.orderTotal = 0;
        this.tip = 0;
        this.finalAmount = 0;
        this.percent = 0;
        this.customerCount = 1;
        this.evenBill = 0;
    }

    // increase the customer count
    public void incCustomer(){
        this.customerCount++;
    }

    // decrease the customer count
    public void decCustomer(){
        if(customerCount == 1){ // makes sure that the customer count can not fall below 1
            this.customerCount = 1;
        }
        else {
            this.customerCount--;
        }
    }

    public int getCustomerCount(){
        return this.customerCount;
    }

    // set the amount for what each customer should pay
    public void setEvenBill(double amount){
        this.evenBill = amount;
    }

    // get the amount that each customer should pay
    public double getEvenBill(){
        return this.evenBill;
    }

    // set the tip
    public void setTipPercent(int amount){
        this.percent = amount;
    }

    // get the tip percent
    public int getTipPercent(){
        return this.percent;
    }

    // get the final amount 
    public double getFinalAmount(){
        return this.finalAmount;
    }

    // set the final amount
    public void setFinalAmount(double theBill){
        this.finalAmount = theBill;
    }

    // get the tip 
    public double getTip(){
        this.tip = this.orderTotal * (this.percent * .01);
        return this.tip;
    }

    // get the order total
    public double getOrderTotal(){
        return this.orderTotal;
    }

    // increase the order total for each item by adding the new amount to the previous total
    public void incOrderTotal(double amount){
        this.orderTotal += amount;
    }

    // decrease the order total for each item by removing the amount pasted from the current total
    public void decOrderTotal(double amount){
        this.orderTotal -= amount;
    }
}
