using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GridSpace : MonoBehaviour
{

    public int index;
    public Button button;
    public Text buttonText;

    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();

        if (IsBomb()) {

            for (int i = 0; i < 9; i++) {    

                if ((i % 3 == index % 3 || Convert.ToInt32(Math.Floor((double)i / 3)) == Convert.ToInt32(Math.Floor((double)index / 3))) && i != index) {
                    GridSpace gs = gameController.buttonList[i].GetComponentInParent<GridSpace>();
                    gs.GetComponent<Animation>().Play("Explosion");
                    gs.Clear();
                }
            } 
        }

        button.interactable = false;
        gameController.EndTurn();
    }

    public void Clear()
    {
        buttonText.text = "";
        button.interactable = true;
    }

    bool IsBomb() {
        return UnityEngine.Random.value <= 0.35;
    }
}