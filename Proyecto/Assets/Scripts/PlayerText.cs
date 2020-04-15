using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerText : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI CorrectText;
    public TextMeshProUGUI IncorrectText;
    private Vector2 rightAnswer;
    private Vector2 wrongAnswer;
    public static string usada;
    public static string pregunta;
    public static string correcta;
    public static string incorrecta;
    System.Random r = new System.Random();
    private int which;
    Questions question = new Questions();
    // Start is called before the first frame update
    void Start()
    {
        
        which = r.Next(1,26);
        GetText();
    }
    public void GetText()
    {
        RetrieveFromDatabase();
    }
    private void RetrieveFromDatabase()
    {
        RestClient.Get<Questions>("https://preguntas-13b3b.firebaseio.com/"+which+".json").Then(response =>
        {
            question= response;
            UpdateText();
        });
        
    }
    public void NextButton()
    {
        which = r.Next(1, 8);
        GetText();
        randomAnswer();
    }
    public void randomAnswer()
    {
        rightAnswer = CorrectText.rectTransform.position;
        wrongAnswer = IncorrectText.rectTransform.position;
        System.Random o = new System.Random();
        int cambia = o.Next(2);
        if (cambia == 0)
        {
            CorrectText.rectTransform.SetPositionAndRotation(wrongAnswer, CorrectText.rectTransform.rotation);
            IncorrectText.rectTransform.SetPositionAndRotation(rightAnswer, IncorrectText.rectTransform.rotation);
        }
    }

    // Update is called once per frame
    private void UpdateText()
    {
        QuestionText.text = question.pregunta;
        CorrectText.text = question.correcta;
        IncorrectText.text = question.incorrecta;

    }
}
