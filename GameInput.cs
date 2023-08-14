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
            else if (Fight.state != Fight.FightState.None & Fight.state != Fight.FightState.Wait) {
                
                if (afterTurn) {
                    if (Fight.state == Fight.FightState.Player) {
                        Debug.Log("Interact");
                        if (ailment < Fight.playerAilments.Count) {
                            Fight.Ailments(true, Fight.playerAilments[ailment]);
                            ailment++;
                            Debug.Log("Yes Ailments");
                        }
                        else {
                            Debug.Log("No Ailments");
                            afterTurn = false;
                            ailment = 0;
                        }
                    }
                    else if (Fight.state == Fight.FightState.Enemy) {
                        if (ailment < Fight.enemyAilments.Count) {
                            Fight.Ailments(false, Fight.enemyAilments[ailment]);
                            ailment++;
                        }
                        else {
                            afterTurn = false;
                            ailment = 0;
                        }
                    }
                }
                else {
                    Fight.Attack();
                    afterTurn = true;
                }
                

            }
        }
        
        
        
    }
}
