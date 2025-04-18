using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeController : MonoBehaviour
{
    private static TimeController instance;

    public static TimeController Instance { get { return instance; } }

    public float slowMotionTimeScale = 0.3f;
    public float slowMotionDuration = 0.5f; //?ฌ๋ก์ฐ ๋ชจ์ ์ง?? ?๊ฐ?
    private float slowMotionTimer = 0f;   //????ด๋จ?

    public bool isSlowMotion { get; private set; }

    [Header("Post Processing")]
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private ColorGrading colorGrading;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    void Start()
    {
        //Post Processing ์ปดํฌ??ธ ๊ฐ?? ธ?ค๊ธ?
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);

    }


    void Update()
    {
        if(isSlowMotion)
        {
            slowMotionTimer += Time.deltaTime;
            if(slowMotionTimer >= slowMotionDuration)
            {
                SetSlowMotion(false);
                slowMotionTimer = 0f;
            }
        }
    }
    //?ฌ๋ก์ฐ?จ๊ณผ์ ?ฌ?ฉ?๊ธ?
    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeScale : 1f;
    }


    public void SetSlowMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            // ?ฌ๋ก์ฐ ๋ชจ์ ?? ? ?จ๊ณ? ?ค? 
            slowMotionTimer = 0f;
            vignette.intensity.value = 0.8f;         // ๋น๋ค?ธ ๊ฐ๋ ????ญ ์ฆ๊??
            colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
            colorGrading.saturation.value = -40f;    // ์ฑ๋ ??ฑ ?ฎ๊ฒ?
            colorGrading.temperature.value = -25f;    // ๋งค์ฐ ์ฐจ๊???ด ?๊ฐ?
            colorGrading.contrast.value = 20f;        // ???๋น? ? ๊ฐํ๊ฒ?
            colorGrading.postExposure.value = -1.0f;  // ? ์ฒด์ ?ผ๋ก? ? ?ด?ก๊ฒ?
            colorGrading.tint.value = 10f;           // ?ฝ๊ฐ์ ์ด๋ก๋น? ์ถ๊??
        }
        else
        {
            // ?ฌ๋ก์ฐ ๋ชจ์ ์ข๋ฃ ? ?จ๊ณ? ์ด๊ธฐ?
            vignette.intensity.value = 0f;
            colorGrading.saturation.value = 0f;
            colorGrading.temperature.value = 0f;
            colorGrading.contrast.value = 0f;
            colorGrading.postExposure.value = 0f;
            colorGrading.tint.value = 0f;
        }
    }
}