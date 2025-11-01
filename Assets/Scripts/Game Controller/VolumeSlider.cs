using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string parameter;
    private Slider slider;
    public float Volume
    {
        get
        {
            if (audioMixer.GetFloat(parameter, out float db))
            {
                return DBToRatio(db);
            }
            return 1.0f;
        }
        set
        {
            float dB = RatioToDB(value);
            audioMixer.SetFloat(parameter, dB);
        }
    }
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = Volume;
        slider.onValueChanged.AddListener(OnValueChanged);
    }
    private void OnValueChanged(float x)
    {
        Volume = x;
    }
    private float RatioToDB(float volumeRatio)
    {
        float dB = -144.0f;
        if (volumeRatio > 0)
            dB = 20.0f * Mathf.Log10(volumeRatio);
        return dB;
    }
    private float DBToRatio(float dB)
    {
        float volumeRatio = 0;
        if (volumeRatio > -144.0f)
            volumeRatio = Mathf.Pow(10, dB / 20.0f);
        return volumeRatio;
    }
}
