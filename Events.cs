using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ChooseEvent(){
        return eventType = Random.Range(0,3);
    
    private void LootBox(int difficulty, int area) {
        int[] items;
        if (area == 0) {
            if (difficulty == 0) {
                items = new int[] { 0, 6, 12, 17, 21, 25 };
            }
            if (difficulty == 1) {
                items = new int[] { 0, 1, 6, 7, 12, 17, 21, 25 };
            }
            if (difficulty == 2) {
                items = new int[] { 1, 7, 12, 17, 21, 25 };
            }
        }
        if (area == 1) {
            if (difficulty == 0) {
                items = new int[] { 1, 7, 12, 17, 21, 25 };
            }
            if (difficulty == 1) {
                items = new int[] { 1, 2, 7, 8, 12, 15, 17, 18, 21, 22, 25 };
            }
            if (difficulty == 2) {
                items = new int[] { 2, 3, 8, 9, 12, 15, 17, 18, 21, 22, 25 };
            }
        }
        if (area == 2) {
            if (difficulty == 0) {
                items = new int[] { 2, 7, 8, 12, 17, 21, 25 };
            }
            if (difficulty == 1) {
                items = new int[] { 2, 3, 8, 9, 12, 15, 17, 18, 21, 22, 25 };
            }
            if (difficulty == 2) {
                items = new int[] { 3, 4, 9, 12, 13, 15, 17, 18, 21, 22, 25 };
            }
        }
        if (area == 3) {
            if (difficulty == 0) {
                items = new int[] { 3, 9, 10, 13, 15, 17, 18, 22, 25 };
            }
            if (difficulty == 1) {
                items = new int[] { 3, 4, 10, 11, 13, 16, 18, 19, 22, 23, 25 };
            }
            if (difficulty == 2) {
                items = new int[] { 4, 5, 11, 13, 14, 16, 19, 20, 23, 24, 25 };
            }
        }
        if (area == 4) {
            if (difficulty == 0) {
                items = new int[] { 3, 4, 10, 13, 14, 15, 18, 19, 22, 25 };
            }
            if (difficulty == 1) {
                items = new int[] { 4, 5, 10, 11, 14, 16, 19, 20, 22, 23, 25 };
            }
            if (difficulty == 2) {
                items = new int[] { 5, 11, 14, 16, 20, 23, 24, 25 };
            }
        }
        return items;
    }
    private int[] Chest(int difficulty, int area){
        int[] items = LootBox(difficulty, area);
        item = items[Random.Range(0,items.Length)];
        return [item];
        
    }
    private int[] CoinShop(int difficulty, int area){
        int[] items = LootBox(difficulty, area);
        int option1 = items[Random.Range(0,items.Length)];
        int option2 = items[Random.Range(0,items.Length)];
        while (option1 == option2){
            option2 = items[Random.Range(0,items.Length)];
        }
        int option3 = items[Random.Range(0,items.Length)];
        while ((option1 == option3) || (option2 == option3)){
            option3 = items[Random.Range(0,items.Length)];
        }
        return [option1, option2, option3];
    }
    private int[] SoulShop(){
        int option1 = Random.Range(0,14);
        int option2 = Random.Range(0,14);
        while (option1 == option 2){
            option2 = Random.Range(0,14);
        }
        int option3 = Random.Range(0,14);
        while ((option1 == option3) || (option2 == option3)){
            option = Random.Range(0,14)
        }
        return [option1, option2, option3];
    }
}
