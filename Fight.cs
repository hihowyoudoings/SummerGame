using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fight : MonoBehaviour {

    public enum FightState {
        None,
        Wait,
        Player,
        Enemy
    }
    public static List<List<int>> enemyAilments = new List<List<int>>();
    public static List<List<int>> playerAilments = new List<List<int>>();
    public static FightState state = FightState.None;
    static bool combatStarter = false;
    public static void Attack() {
        string currentEnemyMove = Enemies.moves[(int)Enemies.enemiesMoves[Enemies.movesID][Random.Range(0, Enemies.numOfMoves)], 0].ToString();
        int enemyMovePower = (int)Enemies.moves[(int)Enemies.enemiesMoves[Enemies.movesID][Random.Range(0, Enemies.numOfMoves)], 1];
        int enemyMoveType = (int)Enemies.moves[(int)Enemies.enemiesMoves[Enemies.movesID][Random.Range(0, Enemies.numOfMoves)], 2];
        string enemyMoveDescription = Enemies.moves[(int)Enemies.enemiesMoves[Enemies.movesID][Random.Range(0, Enemies.numOfMoves)], 3].ToString();

        switch (state) {
            case FightState.None:
                if (Enemies.enemyName == null) {
                    TextUI.bottomText = "There is no enemy";
                }
                else {
                    TextUI.bottomText = "The battle begins!!!";
                    state = FightState.Wait;
                }
                break;
            case FightState.Wait:
                int chooseFirsty = Random.Range(0, 2);
                if (chooseFirsty == 0) {
                    TextUI.bottomText = "You attack first!!!";
                    state = FightState.Player;
                }
                else {
                    TextUI.bottomText = "The " + Enemies.enemyName + " attacks first!!!";
                    state = FightState.Enemy;
                }
                combatStarter = true;
                break;
            case FightState.Player:
                PlayerMove();
                if (combatStarter == true) {
                    state = FightState.Enemy;
                }
                else {
                    state = FightState.Wait;
                }
                combatStarter = false;
                break;
            case FightState.Enemy:
                TextUI.bottomText = "The "+ Enemies.enemyName + " used " + currentEnemyMove + " "+ enemyMoveDescription;
                int damage = CombatTurn(false, Enemies.attack, enemyMovePower, Player.defence, enemyMoveType, playerAilments);
                if (damage < 0) {
                    Player.health += damage;
                    TextUI.bottomText += "\nThe " + Enemies.enemyName + " did " + damage + " to you";
                } else {
                    TextUI.bottomText += "\nThe " + Enemies.enemyName + " did no damage to you";
                }
                
                if (combatStarter == true) {
                    state = FightState.Player;
                }
                else {
                    state = FightState.Wait;
                }
                combatStarter = false;
                break;
        }




    }
    public static void AttackButton() {
        if (state == FightState.Wait) {
            Attack();
        }
    }
    private static int CombatTurn(bool player, int attack, int movePower, int defence, int moveType, List<List<int>> ailments) {
        int damage = 0;
        bool exists = false;
        if (moveType == 0) {
            damage -= (attack * (movePower + Random.Range(-20, 21)) / 100 - defence);
        }
        if (moveType == 1) {
            damage -= (attack * (movePower + Random.Range(-20, 21)) / 100 - defence);
            if (damage < 0) {
                for (int i = 0; i < ailments.Count; i++) {
                    if (ailments[i][0] == 1) {
                        ailments[i][1] += (movePower / 25);
                        exists = true;
                    }
                }
                if (!exists) {
                    ailments.Add(new List<int>(3));
                    ailments[^1].Add(1);
                    ailments[^1].Add(movePower / 25);
                    ailments[^1].Add(0);
                }

            }
        }
        if (moveType == 2) {
            damage -= (attack * (movePower + Random.Range(-20, 21)) / 100 - defence);
            for (int i = 0; i < ailments.Count; i++) {
                if (ailments[i][0] == 2) {
                    ailments[i][2] += (15 * movePower / 25);
                    exists = true;
                }
            }
            if (!exists) {
                ailments.Add(new List<int>(3));
                ailments[^1].Add(2);
                ailments[^1].Add(15);
                ailments[^1].Add(15 * movePower / 25);
            }
        }
        if (moveType == 3) {
            damage -= (attack * (movePower + Random.Range(-20, 21)) / 100);
        }
        if (moveType == 4) {
            damage -= (attack * (movePower + Random.Range(-20, 21)) / 100 - defence);
            if (damage < 0) {
                for (int i = 0; i < ailments.Count; i++) {
                    if (ailments[i][0] == 3) {
                        ailments[i][1] += (3);
                        exists = true;
                    }
                }
                if (!exists) {
                    ailments.Add(new List<int>(3));
                    ailments[^1].Add(3);
                    ailments[^1].Add(3);
                    ailments[^1].Add(10 * movePower / 25);
                }
            }
        }
        if (!player) {
            playerAilments = ailments;
        }
        else {
            enemyAilments = ailments;
        }

        return damage;
    }

    public static List<int> Ailments(bool player, List<int> ailment) {
        if (ailment[0] == 1) {
            ailment[2] += ailment[1];
            if (player) {
                if (ailment[2] > 0) {
                    Player.health -= ailment[2];
                    TextUI.bottomText = "You take " + ailment[2] + " damage from poison";
                }
                else {
                    TextUI.bottomText = "You are no longer poisoned";
                    ailment[0] = -1;
                }
                
            }
            else {
                if (ailment[2] > 0) {
                    Enemies.health -= ailment[2];
                    TextUI.bottomText = "The " + Enemies.enemyName + " takes " + ailment[2] + " damage from poison";
                }
                else {
                    TextUI.bottomText = "The " + Enemies.enemyName + " is no longer poisoned";
                    ailment[0] = -1;
                }
                
                
            }
        }
        if (ailment[0] == 2) {
            ailment[2] -= ailment[1];
            if (player) {
                if (ailment[2] - Player.defence > 0) {
                    Player.health -= (ailment[2] - Player.defence);
                    TextUI.bottomText = "You take " + ailment[2] + " damage from burning alive";
                }
                else {
                    TextUI.bottomText = "You are no longer burning";
                    ailment[0] = -1;
                }

            }
            else {
                if (ailment[2] - Enemies.defence > 0) {
                    Enemies.health -= (ailment[2] - Enemies.defence);
                    TextUI.bottomText = "The " + Enemies.enemyName + " takes " + ailment[2] + " damage from burning alive";
                }
                else {
                    TextUI.bottomText = "The " + Enemies.enemyName + " is no longer Burning";
                    ailment[0] = -1;
                }
            }
        }
        if (ailment[0] == 3) {
            ailment[1] -= 1;
            if (player) {
                if (ailment[1] > 0) {
                    Player.health -= (ailment[2]);
                    TextUI.bottomText = "You take " + ailment[2] + " damage from bleeding";
                }
                else {
                    TextUI.bottomText = "You are no longer bleeding";
                    ailment[0] = -1;
                }
                
            }
            else {
                if (ailment[1] > 0) {
                    Enemies.health -= (ailment[2] - Enemies.defence);
                    TextUI.bottomText = "The " + Enemies.enemyName + " takes " + ailment[2] + " damage from bleeding";
                }
                else {
                    TextUI.bottomText = "The " + Enemies.enemyName + " is no longer Bleeding";
                    ailment[0] = -1;
                }
                
            }
            
        }return ailment;
        }

    private static int move = 0;
    public static int poisonDartPower = 25;
    public static int fireBallPower = 25;
    public static int spearPower = 25;
    public static int magicGashPower = 25;
    public static void PlayerMove() {
        int currentMove = 0;
        if (move == 1) {
            currentMove = move1;
        }
        else if (move == 2) {
            currentMove = move2;
        }
        else if (move == 3) {
            currentMove = move3;
        }
        else if (move == 4) {
            currentMove = move4;
        }
        int damage = 0;
        if (currentMove == 0) {
            damage = CombatTurn(true, Player.attack, 100, Enemies.defence, 0, enemyAilments);
            if (damage < 0) {
                Enemies.health += damage;
            }
            
        }
        else if (currentMove == 1) {
            damage = CombatTurn(true, Player.attack, poisonDartPower, Enemies.defence, 1, enemyAilments);
            if (damage < 0) {
                Enemies.health += damage;
            }
        }
        else if (currentMove == 2) {
            damage = CombatTurn(true, Player.attack, fireBallPower, Enemies.defence, 2, enemyAilments);
            if (damage < 0) {
                Enemies.health += damage;
            }
        }
        else if (currentMove == 3) {
            damage = CombatTurn(true, Player.attack, spearPower, Enemies.defence, 3, enemyAilments);
            if (damage < 0) {
                Enemies.health += damage;
            }
        }
        else if (currentMove == 4) {
            damage = CombatTurn(true, Player.attack, magicGashPower, Enemies.defence, 4, enemyAilments);
            if (damage < 0) {
                Enemies.health += damage;
            }
        }
        if (damage < 0) {
            TextUI.bottomText = "You did "+ -damage + " damage to the "+Enemies.enemyName;
        }
        else {
            TextUI.bottomText = "You did no damage to the " + Enemies.enemyName;
        }

    }



    public static int move1 = 0;
    public static int move2 = 0;
    public static int move3 = 0;
    public static int move4 = 0;

    public static void MagicButton1() {
        if (state == FightState.Wait){
            move = 1;
            move1 = 1;
            if (move1 != 0) {
                Attack();
            }
            else {
                TextUI.warning = "You do not have a spell in that slot";
            }
        }
        

    }
    public static void MagicButton2() {
        if (state == FightState.Wait) {
            move = 2;
            move2 = 2;
            if (move2 != 0) {
                Attack();
            }
            else {
                TextUI.warning = "You do not have a spell in that slot";
            }
        }
    }
    public static void MagicButton3() {
        if (state == FightState.Wait) {
            move = 3;
            move3 = 3;
            if (move3 != 0) {
                Attack();
            }
            else {
                TextUI.warning = "You do not have a spell in that slot";
            }
        }
    }
    public static void MagicButton4() {
        if (state == FightState.Wait) {
            move = 4;
            move4 = 4;
            if (move4 != 0) {
                Attack();
            }
            else {
                TextUI.warning = "You do not have a spell in that slot";
            }
        }
    }
}
