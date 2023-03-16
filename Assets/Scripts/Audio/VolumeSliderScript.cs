using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider, _sliderSFX;
    [SerializeField] bool isSliderForSFX;
    [SerializeField] private TextMeshProUGUI musiqueLabel = null;
    [SerializeField] private TextMeshProUGUI  sfxLabel = null;


    // Start is called before the first frame update
    void Start()
    {
        isSliderForSFX = false;
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    }

  

    private void Update()
    {
        if(isSliderForSFX == true)
        {
            _sliderSFX.onValueChanged.AddListener(value => SoundManager.Instance.ChangeSfxVolume(value));
        }
    } 
    public void musicLabelSlider(float volume)
    {
        float volumePercent = volume*100;
        volumePercent  = Mathf.Floor(volumePercent);
        musiqueLabel.text = volumePercent.ToString() + " %";
    }

    public void sfxLabelSlider(float volume)
    {   
        float volumePercent = volume*100;
        volumePercent  = Mathf.Floor(volumePercent);
        sfxLabel.text = volumePercent.ToString()+ " %";
    }
}