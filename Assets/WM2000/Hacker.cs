using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "type menu to get back.";
    string[] level1Password = {"books", "pencil", "shelf", "password", "font", "pen"};
    string[] level2Password = {"gun", "officer", "prison", "scape", "cell", "crime"};
    string[] level3Password = {"star", "telescope", "environment", "exploration", "astronaut", "moon"};
    
    // Game State
    int level = 0;
    string password;
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
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("application is quited");
            Application.Quit();
        }

        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
   
        else
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
        Terminal.WriteLine("press 3 for the ordibehesht");
        Terminal.WriteLine("enter your selection");
    }

    void RunMainMenu(string input)
    {
        bool isValidnumber = (input == "1" || input == "2" || input == "3");

        if (isValidnumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else
        {
            Terminal.WriteLine("Please select a valid level");
            Terminal.WriteLine(menuHint);
            }
    }
    

    void AskForPassword()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();

        SetRandomPassword();
        
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;            
            case 3:
                password = level3Password[Random.Range(0, level2Password.Length)];
                break;
            default:
                Debug.LogError("invalid error number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (password == input.Replace(" ", string.Empty))
        {
            DisplayWinScreen();
        }
        else if (password != input)
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);

    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You Won Level One Bitch");
                Terminal.WriteLine(@"
     ___________
    /_________//
   /_________//
  /_________//
 /_________//
(_________(/

                ");
                break;
            case 2:
                Terminal.WriteLine("here have an apple for your troubles");
                Terminal.WriteLine(@"
          .:'
      __ :'__
   .'`__`-'__``.
  :__________.-'
  :_________:
   :_________`-;
    `.__.-.__.'
                ");
                break;
            case 3:
                Terminal.WriteLine("You Won Level One Bitch");
                Terminal.WriteLine("Play Again for a Greater Challenge");
                Terminal.WriteLine(@"
        _____
    ,-:` \;',`'-, 
  .'-;_,;  ':-;_,'.
 /;   '/    ,  _`.-\
| '`. (`     /` ` \`|
|:.  `\`-.   \_   / |
|     (   `,  .`\ ;'|
 \     | .'     `-'/
  `.   ;/        .'
    `'-._____.


                ");
                break;
        }

    }
}