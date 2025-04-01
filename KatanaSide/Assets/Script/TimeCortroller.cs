using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeController : MonoBehaviour
{
    private static TimeController instance;

    public static TimeController Instance { get { return instance; } }

    public float slowMotionTimeScale = 0.3f;
    public float slowMotionDuration = 0.5f; //?��로우 모션 �??�� ?���?
    private float slowMotionTimer = 0f;   //????���?

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
        //Post Processing 컴포?��?�� �??��?���?
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
    //?��로우?��과에 ?��?��?���?
    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeScale : 1f;
    }


    public void SetSlowMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            // ?��로우 모션 ?��?�� ?�� ?���? ?��?��
            slowMotionTimer = 0f;
            vignette.intensity.value = 0.8f;         // 비네?�� 강도 ????�� 증�??
            colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
            colorGrading.saturation.value = -40f;    // 채도 ?��?�� ?���?
            colorGrading.temperature.value = -25f;    // 매우 차�???�� ?���?
            colorGrading.contrast.value = 20f;        // ???�? ?�� 강하�?
            colorGrading.postExposure.value = -1.0f;  // ?��체적?���? ?�� ?��?���?
            colorGrading.tint.value = 10f;           // ?��간의 초록�? 추�??
        }
        else
        {
            // ?��로우 모션 종료 ?�� ?���? 초기?��
            vignette.intensity.value = 0f;
            colorGrading.saturation.value = 0f;
            colorGrading.temperature.value = 0f;
            colorGrading.contrast.value = 0f;
            colorGrading.postExposure.value = 0f;
            colorGrading.tint.value = 0f;
        }
    }
}