using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Functions;

public class CompanyLogo : MonoBehaviour
{
    public TimerFinishedEvent timerEvents;
    public Image background;
    public Image logo;
    public Color color = Color.black;
    public Sprite sprite;
    public Timer timer = new Timer();
    public string sceneName;
    public float fadeInTime = 1;
    public float fadeOutTime = 1;

    [Header("OnEnable Functions")]
    public bool setImageColor = true;
    public bool setImageSprite = true;

    [Header("Update Functions")]
    public bool updateTimer = true;
    public bool loadScene = true;
    public bool fadeIn = true;
    public bool fadeOut = true;
    public bool rToRestart = true;

    private void OnEnable()
    {
        if (setImageColor) SetImageColor(background, color);
        if (setImageSprite) SetImageSprite(logo, sprite);
    }

    private void Update()
    {
        if (updateTimer) UpdateTimer(timer, timerEvents);
        if (loadScene && timerEvents.Contains(timer)) LoadScene(sceneName);
        if (fadeIn) FadeIn(logo, timer, fadeInTime);
        if (fadeOut) FadeOut(logo, timer, fadeOutTime);
        if (rToRestart) RestartTimer(timer);
    }
}
