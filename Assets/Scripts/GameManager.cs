using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject langScreen;
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    private int attempts = 0;
    private int correct =  0;
	// Use this for initialization
	void Start () {
        Init();
	}

    public void Init()
    {
        attempts = 0;
        langScreen.SetActive(true);
        gameScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void NewGame()
    {
        gameScreen.SetActive(true);
        correct = AnswersManager.Instance.SetTexts(attempts+1);
    }

    public void SetLang(int i)
    {
        AnswersManager.Instance.languageIndex = i;
        langScreen.SetActive(false);
        NewGame();
    }

    public void Check(int i)
    {
        attempts++;
        if (i != correct)
        {
            gameScreen.SetActive(false);
            loseScreen.SetActive(true);
        } else if (attempts == 3)
        {
            gameScreen.SetActive(false);
            winScreen.SetActive(true);
        } else
        {
            NewGame();
        }
    }
}
