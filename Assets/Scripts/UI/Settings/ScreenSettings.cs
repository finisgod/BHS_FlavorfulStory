using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Класс, отвечающий за настройки разрешения и режима окна, в котором будет находится игра.
/// </summary>
public class ScreenSettings : MonoBehaviour
{
    /// <summary>Ссылка на выпадающий список с разрешениями.</summary>
    [SerializeField] private TMP_Dropdown _screenModeDropdown;
    /// <summary>Ссылка на выпадающий список с типами окна.</summary>
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    /// <summary>Метод, для получения и установки максимального значения обновления монитора.</summary>
    private double MaxRefreshRate { get; set; }
    /// <summary>Список разрешений.</summary>
    private readonly List<Resolution> _resolutions = new();
    /// <summary>Список режимов окна.</summary>
    private List<string> _screenModeOptions = new() {
        "Окно",
        "Полный экран",
    };
    /// <summary>Инициализация разрешений и рижемов окна и обновление значений в выпадаюзих списках.</summary>
    private void Start()
    {
        InitializeResolutions();
        InitializeScreenModes();
        UpdateDropdownValues();
    }
    /// <summary>Метод для обновления значений выпадающих списков.</summary>
    private void UpdateDropdownValues()
    {
        _resolutionDropdown.RefreshShownValue();
        _screenModeDropdown.RefreshShownValue();
    }
    /// <summary>Метод для получения всех поддерживаемых разрешений экрана и добавления их в соответствующий выпадающий список.</summary>
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
    /// <summary>Метод для получения всех поддерживаемых режимов экрана и добавления их в соответствующий выпадающий список.</summary>
    private void InitializeScreenModes()
    {
        _screenModeDropdown.ClearOptions();

        List<string> _screenModeDropdownOptions = _screenModeOptions;
        _screenModeDropdown.AddOptions(_screenModeDropdownOptions);

        _screenModeDropdown.value = 1;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        _screenModeDropdown.RefreshShownValue();
    }
    /// <summary>Метод для установки выбранного разрешения экрана.</summary>
    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreenMode);
    }
    /// <summary>Метод, слушающий выбор пользователя в выпадающем списке разрещений.</summary>
    public void OnResolutionOptionChanged()
    {
        Resolution resolution = _resolutions[_resolutionDropdown.value];
        SetResolution(resolution.width, resolution.height);
    }
    /// <summary>Метод, слушающий выбор пользователя в выпадающем списке режимов окна.</summary>
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