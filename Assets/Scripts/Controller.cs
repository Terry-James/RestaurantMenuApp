//Terry James Project 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Objects created to allow for method use
    public List<ItemClass> itemList = new List<ItemClass>();
    public BillingInfo billItem;
    public List<Text> QTNtext = new List<Text>();
    public List<Text> calText = new List<Text>();
    public Slider tipSliderComp;
    public Text orderTotal;
    public Text tip;
    public Text finalAmount;
    public Text evenCustomerBill;
    public Text customerCounter;

    double check;

    // called before screen load to reset inital values
    public void Awake()
    {
        resetValues();
    }

    // called after screen load sets a listener to check when tip slider is moved
    public void Start()
    {
        tipSliderComp.onValueChanged.AddListener(delegate { updateTip(); });
    }

    // update the tip when the slider is moved
    private void updateTip(){
        billItem.setTipPercent((int)tipSliderComp.value);
        updateBillText(); // update the order total, tip, final amound, and customer billing 
        finalBill();
        evenbilling();
    }

    // update the order total, tip, final amound, and customer billing 
    public void updateBillText(){
        orderTotal.text = billItem.getOrderTotal().ToString("C2"); // C2 used to round to 2 decimal places
        tip.text = billItem.getTip().ToString("C2");
        finalAmount.text = billItem.getFinalAmount().ToString("C2");
        evenCustomerBill.text = billItem.getEvenBill().ToString("C2");
    }

    // used to reset initial values
    public void resetValues(){
        for (int i = 0; i < itemList.Count; i++){
            itemList[i].resetValue();
        }
        billItem.resetValues();
    }
    
    // increases the customer count and displays it on the screen
    public void incCustomerCtn(){
        billItem.incCustomer();
        customerCounter.text = billItem.getCustomerCount().ToString(); 
    }

    // decreases the customer count and displays it on the screen
    public void decCustomerCtn(){
        billItem.decCustomer();
        customerCounter.text = billItem.getCustomerCount().ToString();
    }

    // increases the quantity of an item and displays it on the screen
    public void incrementQTN(int index){
        itemList[index].incQuantity();
        increasePrice(index);
        calculateCheck(index);
        //Debug.Log("increased" + itemList[index].getQuantity().ToString() + itemList[index].getTotalCost().ToString());
        //Debug.Log("Bill:" + billItem.getOrderTotal().ToString());
        QTNtext[index].text = itemList[index].getQuantity().ToString();
        calText[index].text = itemList[index].getTotalCost().ToString("C2");
        finalBill();
        updateBillText();
    }

    // decrease the quantity of an item and display it on the screen
    public void decreaseQTN(int index){
        itemList[index].decQuantity();
        decreasePrice(index);
        decreaseCheck(index);
        //Debug.Log("decreased" + itemList[index].getQuantity().ToString() + itemList[index].getTotalCost().ToString());
        //Debug.Log("Bill:" + billItem.getOrderTotal().ToString());
        QTNtext[index].text = itemList[index].getQuantity().ToString();
        calText[index].text = itemList[index].getTotalCost().ToString("C2");
        finalBill();
        updateBillText();
        
    }

    // decreases the price by multipling the price by the quantity and setting total to the new amount
    public void decreasePrice(int index){
        double currentCost = itemList[index].getTotalCost();
        double amount = itemList[index].getPrice();

        double total = currentCost - amount;

        if(itemList[index].getQuantity() == 0){
            itemList[index].setTotalCost(0);
        }
        else{
            itemList[index].setTotalCost(total);
        }
        
    }

    // increases the price by multipling the price by the quantity and setting total to the new amount
    public void increasePrice(int index){
        double amount = itemList[index].getPrice();
        int qtn = itemList[index].getQuantity();

        double total = amount * qtn;

        itemList[index].setTotalCost(total);
    }

    // increases the order total as items are added to it
    public void calculateCheck(int index){
        check = itemList[index].getPrice();
        billItem.incOrderTotal(check);
    }

    // decreases the order total as items are removed from it
    public void decreaseCheck(int index){
        check = itemList[index].getPrice();
        billItem.decOrderTotal(check);
    }

    // calculates the final bill including the tip
    public void finalBill(){
        double theTip = billItem.getTip();
        double theCheck = billItem.getOrderTotal();

        double combineBill = theTip + theCheck;

        billItem.setFinalAmount(combineBill);
    }

    // divides the bill evenly amoung the number of customers
    public void evenbilling(){
        double bill = billItem.getFinalAmount();
        double customerCount = billItem.getCustomerCount();

        double evenTotal = bill / customerCount;

        billItem.setEvenBill(evenTotal);
    }
}