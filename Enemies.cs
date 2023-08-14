using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public static object[,] enemiesStats = {  { "testenemy1", 5, 5, 5 }, { "testenemy2", 25, 25, 25 } ,
        { "testenemy3", 125, 125, 125 }  };

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
        
        
        


