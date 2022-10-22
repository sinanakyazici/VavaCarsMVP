using System.Security.AccessControl;

namespace VavaCarsMVP.Domains;

public abstract class Player
{
    protected Player(string name, string nickname, int number, string teamName, char position)
    {
        Name = name;
        Nickname = nickname;
        Number = number;
        TeamName = teamName;
        Position = position;
    }

    public string Name { get; set; }
    public string Nickname { get; set; }
    public int Number { get; set; }
    public string TeamName { get; set; }
    public char Position { get; set; }

    public abstract int RatingPoints();
    public abstract int TeamPoint();
}