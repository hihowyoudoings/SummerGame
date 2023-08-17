using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    int area = 0;
    int room1;
    int room2;
    private void Start() {
        SelectRooms();
    }
    private void SelectRooms() {
        room1 = Random.Range(0, 3);
        room2 = Random.Range(0, 3);
        while (room1 == room2) { 
            room2 = Random.Range(0, 3);
        }
        Debug.Log(room1 + " " + room2);
    }
    public void Room1() {
        Enemies.ChooseEnemy(room1,area);
    }
    public void Room2() {
        Enemies.ChooseEnemy(room2, area);
    }
}
