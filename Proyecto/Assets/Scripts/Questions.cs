using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Questions
{
    public string correcta;
    public string incorrecta;
    public string pregunta;
    public string usada;
    public void Question()
    {
        pregunta = PlayerText.pregunta;
        correcta= PlayerText.correcta;
        incorrecta = PlayerText.incorrecta;
        usada = PlayerText.usada;
    }
}
