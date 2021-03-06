using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0); 
        highScoreText.text = $"HighScore: {highScore.ToString()}";

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if(energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if(energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);   

            if(DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }         
        }

        energyText.text = $"Play ({energy})";
    }

    public void Play()
    {
        if(energy < 1) { return; }

        energy--;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#endif
        }

        SceneManager.LoadScene(1);
    }
}
