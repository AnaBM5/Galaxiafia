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
    public static string usada;
    public static string pregunta;
    public static string correcta;
    public static string incorrecta;
    Questions question = new Questions();
    // Start is called before the first frame update
    void Start()
    {
        GetText();
    }
    public void GetText()
    {
        RetrieveFromDatabase();
    }
    private void RetrieveFromDatabase()
    {
        RestClient.Get<Questions>("https://preguntas-13b3b.firebaseio.com/1.json").Then(response =>
        {
            question= response;
            UpdateText();
        });
        
    }

    // Update is called once per frame
    private void UpdateText()
    {
        QuestionText.text = question.pregunta;
        CorrectText.text = question.correcta;
        IncorrectText.text = question.incorrecta;

    }
}
