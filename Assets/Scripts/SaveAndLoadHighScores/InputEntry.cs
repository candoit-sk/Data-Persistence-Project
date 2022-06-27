using System;

[Serializable]
public class InputEntry
{
    
    public string playerName;
    public int points;

    public InputEntry(string Name, int points)
    {
        playerName = Name;
        this.points = points;
    }
}