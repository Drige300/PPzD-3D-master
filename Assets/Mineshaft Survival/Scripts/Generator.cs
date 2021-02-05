using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Generator : MonoBehaviour {

    public AudioSource GeneratorAudio;

    [Header("Generator Stats")]
    public float CurrentFuel;
    public float MaxFuel;
    public bool Toggled = false;
    

    [Header("Visuals")]
    public GameObject VisualObjects;

   // [Header("ID")]
    string GeneratorID;

    string GeneratorTogg;
    public void Start()
    {
        GeneratorID = GetInstanceID().ToString() + "GENERATOR";
        GeneratorTogg = GeneratorID + "togg";
        StartCoroutine(autoSave());
        LoadStats();
    }
    public void Update()
    {
        if(CurrentFuel <= 2)
        {
            CurrentFuel = 2;
            Toggled = false;
            GeneratorAudio.Stop();
        }
        
        if(Toggled)
        {
            VisualObjects.SetActive(true);
            CurrentFuel -= 0.03f;
        }
        else
        {
            VisualObjects.SetActive(false);
        }
    }

    public void LoadStats()
    {
        if(PlayerPrefs.GetFloat(GeneratorID) == 0)
        {

        }
        else
        {
            CurrentFuel = PlayerPrefs.GetFloat(GeneratorID);
        }
        if(PlayerPrefs.GetInt(GeneratorTogg) == 1)
        {
            Toggled = true;
        }
        if(PlayerPrefs.GetInt(GeneratorTogg) == 2)
        {
            Toggled = false;
        }
    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat(GeneratorID, CurrentFuel);
        if(Toggled == true)
        {
            PlayerPrefs.SetInt(GeneratorTogg, 1);
            GeneratorAudio.Play();
        }
        else
        {
            PlayerPrefs.SetInt(GeneratorTogg, 2);
            GeneratorAudio.Stop();
        }
        PlayerPrefs.Save();
        Debug.Log("Generator SAVED!");
    }
    public void Toggle()
    {
        Toggled = !Toggled;
    }
    IEnumerator autoSave()
    {
        yield return new WaitForSeconds(5);
        SaveStats();
        StartCoroutine(autoSave());
    }
}
