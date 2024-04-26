using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetValueAudio : MonoBehaviour
{
    private AudioMixer audioMixer;
    private Slider scroller;
    private const float disableVolume = -80f;
    private const float minimumVolume = -30f;
    [SerializeField]
    private string nameGroups;
    private Image image;
    [SerializeField] private Sprite volumeOffSprite;
    [SerializeField] private Sprite volumeOnSprite;
    private static bool isActivate = true;
    private void Awake()
    {
        audioMixer = FindObjectOfType<AudioManager>().audioMixer;
        scroller = GetComponent<Slider>();
        image = GetComponent<Image>();
    }
    public void SetVolume()
    {
        float volumeValue = Mathf.Lerp(minimumVolume,0,scroller.value);
        if(scroller.value == 0f)
            audioMixer.SetFloat(nameGroups,disableVolume);
        else
        {

            audioMixer.SetFloat(nameGroups,volumeValue);
        }
    }
    private float GetMixerVolume()
    {
        audioMixer.GetFloat(nameGroups, out float currentVolume);
        if(currentVolume == minimumVolume)
        return 0;
        else
            return Mathf.Lerp(1,0, currentVolume / minimumVolume);
    }
    public void VolumeButton()
    {
        if(isActivate)
        {
            OffValue();
        }
        else
        {
            OnValue();
        }
    }
    public void OffValue()
    {
        isActivate = false;
        audioMixer.SetFloat(nameGroups,disableVolume);
        image.sprite = volumeOffSprite;
    }
    public void OnValue()
    {
        isActivate = true;
        audioMixer.SetFloat(nameGroups,0);
        image.sprite = volumeOnSprite;
    }
}
