using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    private string[] level1Password = {"books", "aisle", "self", "password", "font", "borrow"};
    private string[] level2Password = {"manije", "khadije", "hamide", "salite", "gharibe", "faride"};
    
    // Game State
    int level = 0;
    private string password;
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };

    private Screen CurrentScreen;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }


    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
   
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("what would you like to hack into?");
        Terminal.WriteLine("press 1 for the local library");
        Terminal.WriteLine("press 2 for the police station");
        Terminal.WriteLine("enter your selection");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = level1Password[2];
            StartGame(input);
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Password[2];
            StartGame(input);
        }
    }

    void StartGame(string input)
    {
        CurrentScreen = Screen.Password;
        Terminal.WriteLine("You Have chosen level " + level);
        Terminal.WriteLine("please enter your password: ");
    }

    private void CheckPassword(string input)
    {
        if (password == input)
        {
            Terminal.WriteLine("NIIIIIIIIIIIIIIIICE");
            CurrentScreen = Screen.Win;
        }
        else if (password != input)
        {
            Terminal.WriteLine("try again");
        }
    }
    
}