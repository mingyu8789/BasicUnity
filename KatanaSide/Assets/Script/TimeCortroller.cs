using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeController : MonoBehaviour
{
    private static TimeController instance;

    public static TimeController Instance { get { return instance; } }

    public float slowMotionTimeScale = 0.3f;
    public float slowMotionDuration = 0.5f; //?Š¬ë¡œìš° ëª¨ì…˜ ì§??† ?‹œê°?
    private float slowMotionTimer = 0f;   //????´ë¨?

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
        //Post Processing ì»´í¬?„Œ?Š¸ ê°?? ¸?˜¤ê¸?
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
    //?Š¬ë¡œìš°?š¨ê³¼ì— ?‚¬?š©?•˜ê¸?
    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeScale : 1f;
    }


    public void SetSlowMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            // ?Š¬ë¡œìš° ëª¨ì…˜ ?‹œ?‘ ?‹œ ?š¨ê³? ?„¤? •
            slowMotionTimer = 0f;
            vignette.intensity.value = 0.8f;         // ë¹„ë„¤?Š¸ ê°•ë„ ????­ ì¦ê??
            colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
            colorGrading.saturation.value = -40f;    // ì±„ë„ ?”?š± ?‚®ê²?
            colorGrading.temperature.value = -25f;    // ë§¤ìš° ì°¨ê???š´ ?ƒ‰ê°?
            colorGrading.contrast.value = 20f;        // ???ë¹? ?” ê°•í•˜ê²?
            colorGrading.postExposure.value = -1.0f;  // ? „ì²´ì ?œ¼ë¡? ?” ?–´?‘¡ê²?
            colorGrading.tint.value = 10f;           // ?•½ê°„ì˜ ì´ˆë¡ë¹? ì¶”ê??
        }
        else
        {
            // ?Š¬ë¡œìš° ëª¨ì…˜ ì¢…ë£Œ ?‹œ ?š¨ê³? ì´ˆê¸°?™”
            vignette.intensity.value = 0f;
            colorGrading.saturation.value = 0f;
            colorGrading.temperature.value = 0f;
            colorGrading.contrast.value = 0f;
            colorGrading.postExposure.value = 0f;
            colorGrading.tint.value = 0f;
        }
    }
}