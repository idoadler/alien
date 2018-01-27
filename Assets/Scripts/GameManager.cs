using UnityEngine;

public class GameManager : MonoBehaviour {
    public const int MAX_ATTEMPTS = 3;

    public AudioSource bgmusic;
    public AudioSource soundfx;
    public AudioClip talk;
    public AudioClip explode;
    public AudioClip cheer;

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
        bgmusic.Stop();
        soundfx.Stop();
    }

    public void NewGame()
    {
        gameScreen.SetActive(true);
        bgmusic.volume = (attempts + 1.0f) / (MAX_ATTEMPTS + 3);
        correct = AnswersManager.Instance.SetTexts(attempts+1);
        soundfx.Stop();
        soundfx.clip = talk;
        soundfx.Play();
    }

    public void SetLang(int i)
    {
        AnswersManager.Instance.languageIndex = i;
        langScreen.SetActive(false);
        bgmusic.Play();
        NewGame();
    }

    public void Check(int i)
    {
        attempts++;
        if (i != correct)
        {
            gameScreen.SetActive(false);
            loseScreen.SetActive(true);
            bgmusic.Stop();
            soundfx.Stop();
            soundfx.clip = explode;
            soundfx.Play();
        }
        else if (attempts == MAX_ATTEMPTS)
        {
            gameScreen.SetActive(false);
            winScreen.SetActive(true);
            bgmusic.Stop();
            soundfx.Stop();
            soundfx.clip = cheer;
            soundfx.Play();
        }
        else
        {
            NewGame();
        }
    }
}
