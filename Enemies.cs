using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public static object[,] enemiesStats = {/*Area1 difficulty 1*/  { "Slime", 5, 5, 5 }, { "Rat", 4, 7, 3 } ,{ "Small Dog", 10, 4, 5 }, {"Cat",6,7,3},
        /*Area1 difficulty 2*/ {"Small Snake", 10 ,8,6},{"Child",9,7,8},{"Average Dog", 12,6,7},{"Swine",10,8,8},
        /*Area1 difficulty 3*/{"Large Dog",15,8,9},{"Skeleton",10,12,8},{"Zombie",13,8,12}, {"Man",10,10,10},
        /*Area2 difficulty 1*/ {"Anaconda",15,8,5},{"Wolf",12,11,8},{"Hyena",8,13,8},{"Snapping Turtle",5,14,15},
        /*Area2 difficulty 2*/ {"Small Golem",20,14,15},{"Lion",13,17,12},{"Skunk",10,10,10},{"Crocodile",12,15,15},
        /*Area2 difficulty 3*/ {"Golem",30,20,20},{"Elephant",40,20,10},{"Giraffe",20,25,10},{"Hunter",10,30,12}
        /*Area3 difficulty 1*/ {"Ghoul",12,12,8},{"Ghost",2,20,2},{"Giagantic Snail",10,12,10},{"Dark",20,8,9},
        /*Area3 difficulty 2*/ {""}};

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
        
        
        


