using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string[] noramlItems = {/*0*/"Wooden Sword", "Bronze Sword", "Iron Sword", "Steel Sword", "Mythril Sword", "Adamantite Sword",
        /*6*/"Paper Armour","Bronze Armour","Iron Armour","Steel Armour","Mythril Armour","Adamantite Armour",
        /*12*/"Weak Antidote","Strong Antidote","Perfect Antidote","Cure 1","Cure All",
        /*17*/"Weak Health Potion","Health Potion","Strong Health Potion","Full Restore",
        /*21*/"Weak MP Potion", "MP Potion", "Strong MP Potion","Full Fill","Whetstone"};
    public string[] magicItems = {/*0*/"Attack up 1","Attack up 3","Attack up 5",
    /*3*/"Defence up 1","Defence up 3","Defence up 5",
    /*6*/"Health up 3","Health up 5","Health up 10",
    /*9*/"Poison Dart","Fire Ball","Spear","Magic Gash","Heal","Cure"};
    int slot1 = -1;
    int slot2 = -1;
    int slot3 = -1;
    int slot4 = -1;
    int slot5 = -1;
    int slot6 = -1;
    int slot7 = -1;
    int slot8 = -1;
    public void NewEquipment(int equipment) {
        if (slot1 == -1) {
            slot1 = equipment;
        }
        else if (slot2 == -1) {
            slot2 = equipment;
        }
        else if (slot3 == -1) {
            slot3 = equipment;
        }
        else if (slot4 == -1) {
            slot4 = equipment;
        }
        else if (slot5 == -1) {
            slot5 = equipment;
        }
        else if (slot6 == -1) {
            slot6 = equipment;
        }
        else if (slot7 == -1) {
            slot7 = equipment;
        }
        else if (slot8 == -1) {
            slot8 = equipment;
        }
        else{
            TextUI.warning = "You must remove an item first";
        }   
    }
    public void Item1(){
        if (slot1 != -1){
            
        }
    }
}
