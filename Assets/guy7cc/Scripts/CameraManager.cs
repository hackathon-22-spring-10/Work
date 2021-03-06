using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public PlayerManager playerManager;

    public CinemachineVirtualCamera camReal;
    public CinemachineVirtualCamera camGhost;

    public PostProcessVolume ppv;

    private Bloom bloom;
    private Grain grain;
    private ColorGrading grading;
    private ChromaticAberration chroma;
    private Vignette vig;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out bloom);
        ppv.profile.TryGetSettings(out grain);
        ppv.profile.TryGetSettings(out grading);
        ppv.profile.TryGetSettings(out chroma);
        ppv.profile.TryGetSettings(out vig);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            ManageCamera();
            ManagePostProcessing();
        }
        else
        {
            ManageDeadPostProcessing();
        }
    }

    private void ManageCamera()
    {
        switch (playerManager.mode)
        {
            case PlayerManager.Mode.Real:
                camReal.Priority = 1;
                camGhost.Priority = 0;
                break;
            case PlayerManager.Mode.Ghost:
                camReal.Priority = 0;
                camGhost.Priority = 1;
                break;
        }
    }

    private void ManagePostProcessing()
    {
        float s = playerManager.SwapRate;
        bloom.intensity.Interp(0, 20, s);
        grain.intensity.Interp(0, 0.5f, s);
        grading.temperature.Interp(0, -20, s);
        grading.brightness.Interp(0, 100, 4 * s * (1 - s));
        grading.contrast.Interp(0, 100, 4 * s * (1 - s));
        chroma.intensity.Interp(0, 1, 1.77777f * s * (1.5f - s));
        vig.intensity.Interp(0, 0.48f, s);
    }

    private void ManageDeadPostProcessing()
    {
        bloom.intensity.Interp(0, 13.3f, 1);
        grain.intensity.Interp(0, 1, 1);
        grading.hueShift.Interp(0, -180, 1);
        grading.saturation.Interp(0, 40, 1);
        grading.brightness.Interp(0, -78, 1);
        grading.contrast.Interp(0, 80, 1);
        vig.intensity.Interp(0, 0.544f, 1);
    }

    public void SetDeadEffect()
    {
        dead = true;
    }
}
