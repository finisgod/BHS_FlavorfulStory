using System.Collections.Generic;
using UnityEngine;

/// <summary>����� ����������� ������ NPC � ��������� .</summary>
public class ChatNpc : Npc, IIteractiveNpc
{
    /// <summary>������� � ������� .</summary>
    Dictionary<string, string> phrases;

    /// <summary>����� ��� ��������� ����� �� �����  .</summary>
    /// <param name="phraseKey"> . ���� ������ �����</param>
    public string GetPhrase(string phraseKey)
    {
        if (phrases.ContainsKey(phraseKey))
            return phrases[phraseKey];
        return "";
    }

    /// <summary>����� ��� ������� �������������� � NPC. ���������� ���������� IIteractiveNpc .</summary>
    public void Interact()
    {
        Debug.Log("Hi, I'm " + this.Name);
    }
}