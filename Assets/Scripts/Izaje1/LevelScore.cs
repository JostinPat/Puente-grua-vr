using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum ScoreData_Enum
{
    Pendulos,
    T_traslado,
    T_apilado,
    Caidas
}
public class LevelScore : MonoBehaviour
{
    public static LevelScore instance;
    [SerializeField] TextMeshProUGUI textoPendulo;
    [SerializeField] TextMeshProUGUI textoT_traslado;
    [SerializeField] TextMeshProUGUI textoT_apilado;
    [SerializeField] TextMeshProUGUI textoT_Caidas;

    private void Awake()
    {
        instance = this;
    }

    public void setData(int NumPendulos, int TiempoTraslado, int IntentosDeIzaje, int CaidasDeCargas) 
    {
        textoPendulo.text = "Pendulos registrados: " + NumPendulos.ToString();
        textoT_traslado.text = string.Format("Tiempo de traslado: {0}s", TiempoTraslado);
        textoT_apilado.text = "Intentos de izaje descuidando el alineamiento con el aditamneto: " + IntentosDeIzaje.ToString();
        textoT_Caidas.text = "Caidas de tubos: "  + CaidasDeCargas.ToString();
    }
    public void updateScores(ScoreData_Enum scoreData_Enum, int valor) 
    {
        switch (scoreData_Enum)
        {
            case ScoreData_Enum.Pendulos:
                textoPendulo.text = "Pendulos registrados: " + valor;
                break;
            case ScoreData_Enum.Caidas:
                textoT_Caidas.text = "Caidas de bobinas: " + valor;
                break;
            case ScoreData_Enum.T_apilado:
                textoT_apilado.text = string.Format("Tiempo en apilado: {0}s", valor);
                break;
            case ScoreData_Enum.T_traslado:
                textoT_traslado.text = string.Format("Tiempo de traslado: {0}s", valor);
                break;
            default:
                break;
        }
    }
}
