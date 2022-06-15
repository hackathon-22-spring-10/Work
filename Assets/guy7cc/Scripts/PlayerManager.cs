using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    public PlayerConfig config = new PlayerConfig();  //default value

    public RealPlayer realPlayer;

    public GhostPlayer ghostPlayer;

    public Mode mode;

    public PostProcessVolume ppv;

    private Bloom bloom;
    private Grain grain;
    private ColorGrading grading;
    private ChromaticAberration chroma;
    private Vignette vig;

    private float swapTime;
    private float SwapRate { 
        get
        {
            return Mathf.Max(0, Mathf.Min(1f, swapTime / swapTimeMax));
        } 
    }

    private const float swapTimeMax = 0.15f;

    public void Initialize(PlayerConfig config)
    {
        this.config = config;
        realPlayer.config = config;
        ghostPlayer.config = config;
    }

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.Real;
        ppv.profile.TryGetSettings(out bloom);
        ppv.profile.TryGetSettings(out grain);
        ppv.profile.TryGetSettings(out grading);
        ppv.profile.TryGetSettings(out chroma);
        ppv.profile.TryGetSettings(out vig);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(config.swap))
        {
            switch (mode) 
            {
                case Mode.Real:
                    if(swapTime <= 0f) mode = Mode.Ghost;
                    break;
                case Mode.Ghost:
                    if(swapTime >= swapTimeMax) mode = Mode.Real;
                    break;
            }
        }
        switch (mode)
        {
            case Mode.Real:
                realPlayer.active = true;
                ghostPlayer.active = false;
                if (swapTime > 0) swapTime = Mathf.Max(swapTime - Time.deltaTime, 0);
                break;
            case Mode.Ghost:
                realPlayer.active = false;
                ghostPlayer.active = true;
                if (swapTime < swapTimeMax) swapTime = Mathf.Min(swapTime + Time.deltaTime, swapTimeMax);
                break;
        }

        ghostPlayer.SetAlpha(SwapRate * SwapRate);

        ManagePostProcessing();
    }

    private void ManagePostProcessing()
    {
        bloom.intensity.Interp(0, 20, SwapRate);
        grain.intensity.Interp(0, 0.5f, SwapRate);
        grading.temperature.Interp(0, -20, SwapRate);
        grading.brightness.Interp(0, 100, 4 * SwapRate * (1 - SwapRate));
        grading.contrast.Interp(0, 100, 4 * SwapRate * (1 - SwapRate));
        chroma.intensity.Interp(0, 1, 1.77777f * SwapRate * (1.5f - SwapRate));
        vig.intensity.Interp(0, 0.48f, SwapRate);
    }

    public enum Mode
    {
        Real = 0,
        Ghost = 1
    }
}
