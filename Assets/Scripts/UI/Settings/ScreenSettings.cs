using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// �����, ���������� �� ��������� ���������� � ������ ����, � ������� ����� ��������� ����.
/// </summary>
public class ScreenSettings : MonoBehaviour
{
    /// <summary>������ �� ���������� ������ � ������������.</summary>
    [SerializeField] private TMP_Dropdown _screenModeDropdown;
    /// <summary>������ �� ���������� ������ � ������ ����.</summary>
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    /// <summary>�����, ��� ��������� � ��������� ������������� �������� ���������� ��������.</summary>
    private double MaxRefreshRate { get; set; }
    /// <summary>������ ����������.</summary>
    private readonly List<Resolution> _resolutions = new();
    /// <summary>������ ������� ����.</summary>
    private List<string> _screenModeOptions = new() {
        "����",
        "������ �����",
    };
    /// <summary>������������� ���������� � ������� ���� � ���������� �������� � ���������� �������.</summary>
    private void Start()
    {
        InitializeResolutions();
        InitializeScreenModes();
        UpdateDropdownValues();
    }
    /// <summary>����� ��� ���������� �������� ���������� �������.</summary>
    private void UpdateDropdownValues()
    {
        _resolutionDropdown.RefreshShownValue();
        _screenModeDropdown.RefreshShownValue();
    }
    /// <summary>����� ��� ��������� ���� �������������� ���������� ������ � ���������� �� � ��������������� ���������� ������.</summary>
    private void InitializeResolutions()
    {
        var allResolutions = Screen.resolutions;
        MaxRefreshRate = allResolutions[^1].refreshRateRatio.value;
        var uniqueResolutions = new List<string>();

        foreach (var resolution in allResolutions)
        {
            if (resolution.refreshRateRatio.value == MaxRefreshRate)
            {
                uniqueResolutions.Add($"{resolution.width}x{resolution.height}");
                _resolutions.Add(resolution);
            }
        }

        _resolutionDropdown.ClearOptions();
        _resolutionDropdown.AddOptions(uniqueResolutions);
        _resolutionDropdown.value = uniqueResolutions.Count - 1;
        _resolutionDropdown.RefreshShownValue();
    }
    /// <summary>����� ��� ��������� ���� �������������� ������� ������ � ���������� �� � ��������������� ���������� ������.</summary>
    private void InitializeScreenModes()
    {
        _screenModeDropdown.ClearOptions();

        List<string> _screenModeDropdownOptions = _screenModeOptions;
        _screenModeDropdown.AddOptions(_screenModeDropdownOptions);

        _screenModeDropdown.value = 1;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        _screenModeDropdown.RefreshShownValue();
    }
    /// <summary>����� ��� ��������� ���������� ���������� ������.</summary>
    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreenMode);
    }
    /// <summary>�����, ��������� ����� ������������ � ���������� ������ ����������.</summary>
    public void OnResolutionOptionChanged()
    {
        Resolution resolution = _resolutions[_resolutionDropdown.value];
        SetResolution(resolution.width, resolution.height);
    }
    /// <summary>�����, ��������� ����� ������������ � ���������� ������ ������� ����.</summary>
    public void OnScreenModeChanged()
    {
        switch (_screenModeDropdown.value)
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