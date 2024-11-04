using FlavorfulStory.Audio;
using UnityEngine;

namespace FlavorfulStory.Settings
{
    /// <summary> ���������� ��������.</summary>
    public class SavingSettings
    {
        /// <summary> ����� ���������.</summary>
        public static float MasterVolume 
        {
            get => PlayerPrefs.GetFloat("MasterVolume");
            private set => PlayerPrefs.SetFloat("MasterVolume", value);
        }

        /// <summary> ��������� ������.</summary>
        public static float SfxVolume
        {
            get => PlayerPrefs.GetFloat("SfxVolume");
            private set => PlayerPrefs.SetFloat("MasterVolume", value);
        }

        /// <summary> ��������� ������.</summary>
        public static float MusicVolume
        {
            get => PlayerPrefs.GetFloat("MusicVolume");
            private set => PlayerPrefs.SetFloat("MusicVolume", value);
        }

        public static void SetVolumeFromType(VolumeType volumeType, float value)
        {
            switch (volumeType)
            {
                case VolumeType.Master:
                    MasterVolume = value;
                    break;
                case VolumeType.SFX:
                    SfxVolume = value;
                    break;
                case VolumeType.Music:
                    MusicVolume = value;
                    break;
            }
        }
    }
}