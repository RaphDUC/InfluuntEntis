using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown textureQualityDropdown;
    public Dropdown shadowResolutionDropdown;
    public Dropdown antiAliasingDropdown;
    public Dropdown effectQualityDropdown;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle vSyncToggle;
    public Slider musicSlider;
    public Slider soundEffectsSlider;

    private Resolution[] resolutions;

    void Start()
    {
        // Récupération des résolutions supportées par l'écran
        resolutions = Screen.resolutions;

        // Vidage des options du dropdown de résolution
        resolutionDropdown.ClearOptions();

        // Création d'une liste de chaînes de caractères représentant chaque résolution
        List<string> options = new List<string>();

        // Index de la résolution courante
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Si la résolution courante correspond à la résolution actuelle de l'écran, on enregistre son index
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Ajout des options de résolution au dropdown
        resolutionDropdown.AddOptions(options);

        // Sélection de la résolution actuelle
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Chargement des réglages sauvegardés
        LoadSettings();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffectsVolume", volume);
    }

    public void SetTextureQuality(int qualityIndex)
    {
        QualitySettings.masterTextureLimit = qualityIndex;
    }

    public void SetShadowResolution(int resolutionIndex)
    {
        QualitySettings.shadowResolution = (ShadowResolution)resolutionIndex;
    }

    public void SetAntiAliasing(int qualityIndex)
    {
        QualitySettings.antiAliasing = qualityIndex == 0 ? 0 : (int)Mathf.Pow(2, qualityIndex);
    }

    public void SetEffectQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVSync(bool isVSync)
    {
        QualitySettings.vSyncCount = isVSync ? 1 : 0;
    }


    public void LoadSettings()
    {
        // Chargement du volume de la musique
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        musicSlider.value = musicVolume;
        SetMusicVolume(musicVolume);

        // Chargement du volume des effets sonores
        float soundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectsVolume", 0f);
        soundEffectsSlider.value = soundEffectsVolume;
        SetSoundEffectsVolume(soundEffectsVolume);

        // Chargement de la qualité des textures
        int textureQuality = PlayerPrefs.GetInt("TextureQuality", 0);
        textureQualityDropdown.value = textureQuality;
        SetTextureQuality(textureQuality);

        // Chargement de la résolution des ombres
        int shadowResolution = PlayerPrefs.GetInt("ShadowResolution", 0);
        shadowResolutionDropdown.value = shadowResolution;
        SetShadowResolution(shadowResolution);

        // Chargement de la qualité de l'anti-aliasing
        int antiAliasingQuality = PlayerPrefs.GetInt("AntiAliasingQuality", 0);
        antiAliasingDropdown.value = antiAliasingQuality;
        SetAntiAliasing(antiAliasingQuality);

        // Chargement de la qualité des effets
        int effectsQuality = PlayerPrefs.GetInt("EffectsQuality", 0);
        effectQualityDropdown.value = effectsQuality;
        SetEffectQuality(effectsQuality);

        // Chargement de la résolution du jeu
        int resolution = PlayerPrefs.GetInt("Resolution", 0);
        resolutionDropdown.value = resolution;
        SetResolution(resolution);

        // Chargement du mode d'affichage
        bool isFullscreen = PlayerPrefs.GetInt("DisplayMode", 0) == 1 ? true : false;
        fullscreenToggle.isOn = isFullscreen;
        SetFullscreen(isFullscreen);

        // Chargement de la synchronisation verticale
        bool vSync = PlayerPrefs.GetInt("VSync", 0) == 1 ? true : false;
        vSyncToggle.isOn = vSync;
        SetVSync(vSync);
    }


    public void GoBackToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    //Transforme un pourcentage de volume en difference de decibels pour les audio mixers
    public static float ConvertToDecibels(float percentage)
    {
        return (1 - percentage) * (-80);
    }
}
