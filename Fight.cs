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
        Debug.Log(state);
        switch (state) {
            case FightState.None:
                if (Enemies.enemyName == null) {
                    TextUI.bottomText = "There is no enemy";
                } else {
                    TextUI.bottomText = "The battle begins!!!";
                    state = FightState.Wait;
                }
                break;
            case FightState.Wait:
                int chooseFirsty = Random.Range(0, 2);
                if (chooseFirsty == 0) {
                    TextUI.bottomText = "You attack first!!!";
                    state = FightState.Player;
                } else {
                    TextUI.bottomText = "The " + Enemies.enemyName + " attacks first!!!";
                    state = FightState.Enemy;
                }
                combatStarter = true;
                Attack();
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
                Player.health += CombatTurn(false, Enemies.attack, enemyMovePower, Player.defence, enemyMoveType,playerAilments);
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
    public static void ChooseEnemy() {
        Enemies.ChooseEnemy(Random.Range(0, 3));
    }
    private static int CombatTurn(bool player, int attack, int movePower, int defence, int moveType, List<List<int>> ailments) {
        int damage = 0;
        bool exists = false;
        if (moveType == 0)
        {
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
                    ailments[0].Add(1);
                    ailments[0].Add(movePower / 25);
                    ailments[0].Add(0);
                }

            }
            if (!player) {
                playerAilments = ailments;
            }
            else {
                enemyAilments = ailments;
            }
        }
        Debug.Log(damage);
        return damage;
    }

    public static void Ailments(bool player, List<int> ailment) {
        if (ailment[0] == 1) {
            ailment[2] += ailment[1];
            if (player) { 
                Player.health -= ailment[2];
                TextUI.bottomText = "You take " + ailment[2] + " damage from poison";
            }
        }
        Debug.Log("yes yes yes yes");
    }

    private static int move = 0;
    public static int poisonDartPower = 25;
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
        
        if (currentMove == 0) {
            Enemies.health += CombatTurn(true, Player.attack, 100, Enemies.defence, 0,enemyAilments);
        } else if (currentMove == 1) {
            Enemies.health += CombatTurn(true, Player.attack, poisonDartPower, Enemies.defence, 1, enemyAilments);
        }
            
    }
        

    
    public static int move1 = 0;
    public static int move2 = 0;
    public static int move3 = 0;
    public static int move4 = 0;

    public static void MagicButton1() {
        move = 1;
        move1 = 1;
        if (move1 != 0) {
            Attack();
        }
        else {
            TextUI.warning = "You do not have a spell in that slot";
        }
        
    }
    public static void MagicButton2() {
        move = 2;
        if (move2 != 0) {
            Attack();
        }
        else {
            TextUI.warning = "You do not have a spell in that slot";
        }
    }
    public static void MagicButton3() {
        move = 3;
        if (move3 != 0) {
            Attack();
        }
        else {
            TextUI.warning = "You do not have a spell in that slot";
        }
    }
    public static void MagicButton4() {
        move = 4;
        if (move4 != 0) {
            Attack();
        }
        else {
            TextUI.warning = "You do not have a spell in that slot";
        }
    } 
}
  