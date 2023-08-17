using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    bool afterTurn = false;
    int ailment = 0;
    public void Interact(InputAction.CallbackContext context) {
        if (context.performed) {
            if (TextUI.warning != "") {
                TextUI.warning = "";
            }
            if (Fight.state == Fight.FightState.Wait) {
                TextUI.bottomText = "Please pick a move";
            }
            else if (Fight.state != Fight.FightState.None & Fight.state != Fight.FightState.Wait) {
                
                if (afterTurn) {
                    if (Fight.state == Fight.FightState.Player) {
                        if (ailment < Fight.playerAilments.Count) {
                            Fight.playerAilments[ailment] = Fight.Ailments(true, Fight.playerAilments[ailment]);
                            if (Fight.playerAilments[ailment][0]== -1) {
                                Fight.playerAilments.RemoveAt(ailment);
                            }
                            else {
                                ailment++;
                            }
                        }
                        else {
                            afterTurn = false;
                            ailment = 0;
                            Interact(context);
                        }
                    }
                    else if (Fight.state == Fight.FightState.Enemy) {
                        if (ailment < Fight.enemyAilments.Count) {
                            Fight.enemyAilments[ailment] = Fight.Ailments(false, Fight.enemyAilments[ailment]);
                            if (Fight.enemyAilments[ailment][0] == -1) {
                                Fight.enemyAilments.RemoveAt(ailment);
                            }
                            else {
                                ailment++;
                            }
                        }
                        else {
                            afterTurn = false;
                            ailment = 0;
                            Interact(context);
                        }
                    }
                } if (!afterTurn) {
                    Fight.Attack();
                    afterTurn = true;
                }
                
                

            }
        }
        
        
        
    }
}
