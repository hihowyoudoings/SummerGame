using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public static object[,] enemiesStats = {/*Area1 difficulty 1*/  { "Slime", 5, 5, 5 }, { "Rat", 4, 7, 3 } ,{ "Small Dog", 10, 4, 5 }, {"Cat",6,7,3},
        /*Area1 difficulty 2*/ {"Small Snake", 10 ,8,6},{"Child",9,7,8},{"Average Dog", 12,6,7},{"Swine",10,8,8},
        /*Area1 difficulty 3*/{"Large Dog",15,8,9},{"Skeleton",10,12,8},{"Zombie",13,8,12}, {"Man",10,10,10},
        /*Area2 difficulty 1*/ {"Anaconda",15,8,5},{"Wolf",12,11,8},{"Hyena",8,13,8},{"Snapping Turtle",5,14,15},
        /*Area2 difficulty 2*/ {"Small Golem",20,14,15},{"Lion",13,17,12},{"Skunk",10,10,10},{"Crocodile",12,15,15},
        /*Area2 difficulty 3*/ {"Golem",30,20,20},{"Elephant",40,20,10},{"Giraffe",20,25,10},{"Hunter",10,30,12},
        /*Area3 difficulty 1*/ {"Ghoul",12,12,8},{"Ghost",2,20,2},{"Giagantic Snail",10,12,10},{"Dark",20,8,9},
        /*Area3 difficulty 2*/ {"Vampire",10,15,12},{"Imp",14,15,13},{"Poison Slime",15,14,15},{"Big Foot",17,17,15},
        /*Area3 difficulty 3*/{"Pure Blood",25,20,17},{"Werewolf",20,20,20},{"Witch",15,20,10},{"Ogre",30,25,15},
        /*Area4 difficulty 1*/{"Refrigerator",50,15,20},{"Wood Spoon",25,20,15},{"Clown",20,20,20},{"Couch",100,20,0},
        /*Area4 difficulty 2*/{"Eye",30,30,25},{"Teeth",20,40,20},{"orb",30,30,30},{"puddle",30,34,24 },
        /*Area4 difficulty 3*/{"Sun",50,40,30 },{"Moon",50,30,40 },{"House",120,25,15 },{"???",40,40,40},
        /*Area5 difficulty 1*/{"Baby Drag-on",25,30,25 },{"Large Golem",50,30,30 },{"Red Skeleton",30,35,30 },{"Death Slime",30,40,20 },
        /*Area5 difficulty 2*/{"Small Wyvern", 40,40,40},{"Troll",50,40,30 },{"MinoTaur",40,50,30 },{"Giant",60,30,30 },
        /*Area5 difficulty 3*/{"Small Drag-on",50,60,50 },{"Colassal Golem",70,45,45 },{"Hydra",75,50,30 },{"Tank",60,40,55},
        /*Boss for the areas*/{"Fighter",30,15,15 },{"Hob Goblin",50,30,25 },{"Demon",70,35,30},{"Jester",100,50,40 },{"Last Drag-on-deez Erorth",250,75,75 } };

    public static object[,] moves = { /*0*/{"Slither",200,0,"leaving a trail of slime over you" },{"Spew Slime",100,1,"spewing slime all over you" },
    /*2*/{"Weak Bite",100,0,"chomping into your leg" },{"Ram",75,0,"running into you" },{"Scratch",49,4,"swiping at your chest" },
    /*5*/{"Squish", 100,0,"wrapping around your body and squeezing"},{"Bite",150,0,"tearing at your leg with it's mouth" },
    /*7*/{"Punch",100,0,"punching you" }, {"Bow",50,4,"Shooting you in the chest with an arrow" },{"Dagger",74,4,"slashing at you with a small Dagger" },
    /*10*/{"Strong Bite",200,0,"crushing your leg with it's maw" }, {"Slam",100,0,"smashing into with its arms"},
    /*12*/{"Crush",150,0,"slamming down on your shoulders" },{"Stink",200,1,"it stinks" },{"Kick",150,0,"slamming it's foot into your chest" },
    /*15*/{"Soul Steal",100,1,"tugging at your soul" },{"Blaze",50,2,"lighting you on fire" },{"Blood Extrusion",74,4,"forcing open your veins" },
    /*18*/{"FireBreath",124,4,"spewing fire out of it's mouth" },{"Beam",50,3,"shooting out a beam from it's eye" },
    /*20*/{"Slash",174,4,"slashing at you with a sword" },{"Black Death",250, 1,"shooting hazardous particles into the air" },
    /*22*/{"Claw",149,4,"clawing at your arms and legs" },{"Explosive round",150,0,"shooting a shell that explodes in your face" },
    /*24*/{"Armour Piercing Round",100,3,"shooting a shell that passes through your armour" },{"Incindiary Round",100,2,"shooting a shell that bursts into fire" } };

    public static object[][] enemiesMoves = { /*Area1 difficulty 1*/new object[] { 0,1 }, new object[] { 2 }, new object[] { 2,3 }, new object[] { 2, 4 }, 
        /*Area1 difficulty 2*/new object[] { 2,5 }, new object[] { 2,3,4 }, new object[] { 6,3 }, new object[] { 3, 6 },
        /*Area1 difficulty 3*/new object[] { 6,3 }, new object[] { 7,8,9 }, new object[] { 6,4,5 }, new object[] { 7,9,3 },
        /*Area2 difficulty 1*/new object[] { 6,5 }, new object[] { 6,4,3 }, new object[] {10,4}, new object[] { 10 },
        /*Area2 difficulty 2*/new object[] { 3,11,12 }, new object[] { 10,4,3 }, new object[] { 6,3 }, new object[] { 13},
        /*Area2 difficulty 3*/new object[] { 3,11,12 }, new object[] { 3,12 }, new object[] { 14,12 }, new object[] { 7,8,9,12 },
        /*Area3 difficulty 1*/new object[] { 15,10,13,5 }, new object[] { 15 }, new object[] { 0 }, new object[] { 15,16 },
        /*Area3 difficulty 2*/new object[] { 10,16,15 }, new object[] { 16,15,14 }, new object[] { 0,1 }, new object[] { 12,13,14,7 },
        /*Area3 difficulty 3*/new object[] { 10,16,15 }, new object[] { 10,4,7,12 }, new object[] { 16,13,17,15 }, new object[] { 7,12,13,14,5,3 },
        /*Area4 difficulty 1*/new object[] { 18,12,14 }, new object[] { 15,16,9 }, new object[] { 13,8,1,16 }, new object[] { 12 },
        /*Area4 difficulty 2*/new object[] { 19,10,3 }, new object[] { 2,6,10 }, new object[] { 19,3,15 }, new object[] { 13 },
        /*Area4 difficulty 3*/new object[] { 16,19,18 }, new object[] { 19,17,15,13 }, new object[] { 12,0 }, new object[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25 } ,
        /*Area5 difficulty 1*/new object[] { 18,19,4 }, new object[] { 3,11,12 }, new object[] { 14,20,13 }, new object[] { 0,1,21 },
        /*Area5 difficulty 2*/new object[] { 18,22,19}, new object[] { 13,7,12,14 }, new object[] { 20,13,14 }, new object[] { 12,14,5 },
        /*Area5 difficulty 3*/new object[] {18,22,19,21,10 }, new object[] { 3,11,12 }, new object[] { 21,18,12,10,14 }, new object[] { 23,24,25 },
        /*Boss for the areas*/new object[] { 7,14,3,5 }, new object[] { 8,9,12,14,15 }, new object[] { 15,18,22,19 }, new object[] { 13,16,19,23,17 },new object[] { 21,22,18,19,10 }};  

    public static string enemyName;
    public static int health;
    public static int maxHealth;
    public static int attack;
    public static int defence;
    public static int movesID;
    public static int numOfMoves;

    public static void ChooseEnemy(int difficulty, int area) {
        int enemyID = Random.Range(0,3) + (4*difficulty) + (12* area);
        enemyName = enemiesStats[enemyID, 0].ToString();
        maxHealth = (int)enemiesStats[enemyID, 1];
        health = maxHealth;
        attack = (int)enemiesStats[enemyID, 2];
        defence = (int)enemiesStats[enemyID, 3];
        movesID = enemyID;
        numOfMoves = 0;
        foreach (object move in enemiesMoves[enemyID]) {
            numOfMoves++;
        }

        TextUI.bottomText = "The current enemy is a " + Enemies.enemyName;
        Fight.state = Fight.FightState.Wait;

    }

}




