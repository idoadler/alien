using I2.Loc;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswersManager : MonoBehaviour {
    public const int SENTENCES_NUM = 5;
    static public AnswersManager Instance;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI[] options;

    public int languageIndex = 1;

    private List<string> languages;
    private int currectAnswer;

    private void Awake()
    {
        Instance = this;
        languages = LocalizationManager.GetAllLanguages();
    }

    public int SetTexts(int stage)
    {
        int correctAnswer = Random.Range(0, options.Length);
        int sentence = Random.Range(0, SENTENCES_NUM)+1;
        titleText.text = LocalizationManager.GetTranslation("right" + stage + "." + sentence, false, 0, true, false, null, languages[languageIndex]);
        titleText.isRightToLeftText = (languageIndex == 1 || languageIndex == 2);
        for (int i = 0; i < options.Length; i++)
        {
            int lng = i;// Random.Range(0, languages.Count - 1);
            if (lng >= languageIndex)
            {
                lng++;
            }

            string type = (i == correctAnswer) ? "right" : "wrong";

            options[i].text = LocalizationManager.GetTranslation(type + stage + "." + sentence, false, 0, true, false, null, languages[lng]);

            // if hebrew set rtl
            options[i].isRightToLeftText = (lng == 1 || lng == 2);
        }
        return correctAnswer;
    }
}
