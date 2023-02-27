using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeManager : MonoBehaviour
{
    [SerializeField]
    private Button[] buttonList;

    [SerializeField]
    private Button[,] buttons = new Button[3,3];

    [SerializeField]
    private Sprite x;

    [SerializeField]
    private Sprite o;

    [SerializeField]
    private Sprite blank;

    private bool chance = false;
    
    private Button GetButton(int index)
    {
        return buttons[index / 3, index % 3];
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            buttons[i / 3, i % 3] = buttonList[i];
        }
    }

    public void ResetButtons()
    {
        for(int i = 0; i < 9; i++)
        {
            buttons[i / 3, i % 3].image.sprite = blank;
        }
    }

    void Start()
    {
        InitializeButtons();
    }

    private bool IsOccupied(Button button)
    {
        return button.image.sprite == x || button.image.sprite == o;
    }

    private void Occupy(Button button)
    {
        button.image.sprite = chance ? x : o;
        chance = !chance;
    }

    private bool AreEqual(Button button1, Button button2)
    {
        return (IsOccupied(button1) && IsOccupied(button2) && button1.image.sprite == button2.image.sprite);
    }

    private bool IsGameOver()
    {
        bool gameOver = false;
        for(int i = 0; i < 3; i++)
        {
            gameOver |= AreEqual(buttons[i, 0], buttons[i, 1]) && AreEqual(buttons[i, 1], buttons[i, 2]);
        }

        for (int j = 0; j < 3; j++)
        {
            gameOver |= AreEqual(buttons[0, j], buttons[1, j]) && AreEqual(buttons[1, j], buttons[2, j]);
        }

        gameOver |= AreEqual(buttons[0, 0], buttons[1, 1]) && AreEqual(buttons[1, 1], buttons[2, 2]);

        gameOver |= AreEqual(buttons[0, 2], buttons[1, 1]) && AreEqual(buttons[1, 1], buttons[2, 0]);

        return gameOver;
    }
    
    public void OnButtonClick(int index)
    {
        if (!IsGameOver() && !IsOccupied(GetButton(index)))
        {
            Occupy(GetButton(index));
        }
        
    }
    

}
