using UnityEngine;

[CreateAssetMenu(fileName = "TalkSo", menuName = "ScriptableObjects/TalkSo", order = 1)]
public class TalkSo : ScriptableObject
{
    public DialogLine[] DialogLines;
}

[System.Serializable]
public class DialogLine
{
    public NPCSo Actor;
    public string Text;
}