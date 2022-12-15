using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Preferencias : MonoBehaviour
{
    [SerializeField]
    Slider mSlider;

    [SerializeField]
    TMP_InputField mInput;


    private void Awake()
    {
        //PlayerPrefs.DeleteAll();

        mInput.text = PlayerPrefs.GetString("nombre", "Escribe tu nombre...");
        mSlider.value = PlayerPrefs.GetFloat("volumen", 0.5f);
    }

    public void GuardarTodo()
    {
        PlayerPrefs.SetString("nombre", mInput.text);
        PlayerPrefs.SetFloat("volumen", mSlider.value);
        PlayerPrefs.Save();

        Debug.Log(mInput.text);
        Debug.Log(mSlider.value);        
    }

    public void Borrar()
    {
        PlayerPrefs.DeleteAll();
        mInput.text = PlayerPrefs.GetString("nombre", "Escribe tu nombre...");
        mSlider.value = PlayerPrefs.GetFloat("volumen", 0.5f);

    }
}
