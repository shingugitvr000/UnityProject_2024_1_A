using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UI
using UnityEngine.Audio;                //Audio

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;     //private ������ �͵��� �ν����� â���� �������� 
    [SerializeField] private Slider MusicMasterSlider;     //UI Slider
    [SerializeField] private Slider MusicBGMSlider;     //UI Slider
    [SerializeField] private Slider MusicSFXSlider;     //UI Slider
    //�����̴� Minvalue�� 0.001
    private void Awake()
    {
        MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);     //UI slider�� ���� ���� �Ǿ��� ��� SetMasterVolume �Լ��� ȣ�� �Ѵ�.
        MusicBGMSlider.onValueChanged.AddListener(SetBGMVolume);     //UI slider�� ���� ���� �Ǿ��� ��� SetMasterVolume �Լ��� ȣ�� �Ѵ�.
        MusicSFXSlider.onValueChanged.AddListener(SetSFXVolume);     //UI slider�� ���� ���� �Ǿ��� ��� SetMasterVolume �Լ��� ȣ�� �Ѵ�.
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);            //���������� 0 ~ 1 <- Mathf.Log10(volume) * 20
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);            //���������� 0 ~ 1 <- Mathf.Log10(volume) * 20
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);            //���������� 0 ~ 1 <- Mathf.Log10(volume) * 20
    }
}
