using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown screenModeDropdown;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private int MaxRefreshRate { get; set; }

    private readonly List<Resolution> resolutions = new();

    List<string> screenModeOptions = new() {
            "Окно",
            "Полный экран",
        };

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        InitializeResolutions();
        InitializeScreenModes();
        UpdateDropdownValues();
    }

    private void UpdateDropdownValues()
    {
        resolutionDropdown.RefreshShownValue();

        screenModeDropdown.RefreshShownValue();
    }

    private void InitializeResolutions()
    {
        var allResolutions = Screen.resolutions;
        MaxRefreshRate = allResolutions[^1].refreshRate;
        var uniqueResolutions = new List<string>();

        foreach (var resolution in allResolutions)
        {
            if (resolution.refreshRate == MaxRefreshRate)
            {
                uniqueResolutions.Add($"{resolution.width}x{resolution.height}");
                resolutions.Add(resolution);
            }
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(uniqueResolutions);

        resolutionDropdown.value = uniqueResolutions.Count - 1;

        resolutionDropdown.RefreshShownValue();
    }

    private void InitializeScreenModes()
    {
        screenModeDropdown.ClearOptions();

        List<string> screenModeDropdownOptions = screenModeOptions;
        screenModeDropdown.AddOptions(screenModeDropdownOptions);

        screenModeDropdown.value = 1;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        screenModeDropdown.RefreshShownValue();
    }

    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreenMode);

    }

    public void OnResolutionOptionChanged()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        SetResolution(resolution.width, resolution.height);
    }

    public void OnScreenModeChanged()
    {
        switch (screenModeDropdown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }
}