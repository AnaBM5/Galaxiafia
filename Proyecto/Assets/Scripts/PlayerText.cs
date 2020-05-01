using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PlayerText : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI CorrectText;
    public TextMeshProUGUI IncorrectText;
    private Vector2 rightAnswer;
    private Vector2 wrongAnswer;
    private List<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
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
        int Nrandom = r.Next(0, data.Count());
        which = data[Nrandom];
        data.Remove(which);
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
        int Nrandom = r.Next(0, data.Count());
        which = data[Nrandom];
        data.Remove(which);
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
