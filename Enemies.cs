using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public static object[,] enemiesStats = {  { "Slime", 5, 5, 5 }, { "Rat", 4, 7, 3 } ,
        { "Small Dog", 10, 4, 5 }, {"Cat",6,7,3}, {"Small Snake", 10 ,8,6},{"Child",9,7,8},{"Average Dog", 12,6,7},{"Swine",10,8,8},{"Large Dog",15,8,9},
        {"Skeleton",10,12,10},{"Zombie",13,8,12}, {"Man"}};

    public static object[,] moves = { { "testmove",40, 0, "a test-tacular move" }, { "testmove2",80, 1, "a test-tacular move squared" } };

    public static object[][] enemiesMoves = { new object[] { 0 }, new object[] { 0, 1 }, new object[] { 1 } };

    public static string enemyName;
    public static int health;
    public static int maxHealth;
    public static int attack;
    public static int defence;
    public static int movesID;
    public static int numOfMoves;

    public static void ChooseEnemy(int rnd) {
        int difficulty = 0;
        int area = 1;
        enemyName = enemiesStats[rnd,0].ToString();
        maxHealth = (int)enemiesStats[rnd, 1];
        health = maxHealth;
        attack = (int)enemiesStats[rnd, 2];
        defence = (int)enemiesStats[rnd, 3];
        movesID = rnd;
        numOfMoves = 0;
        foreach (object move in enemiesMoves[rnd])
        {
            numOfMoves++;
        }

        TextUI.bottomText = "The current enemy is a " + Enemies.enemyName;
        Fight.state = Fight.FightState.Wait;

    }
    
}
        
        
        


