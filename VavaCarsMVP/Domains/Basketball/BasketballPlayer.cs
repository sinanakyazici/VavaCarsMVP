using VavaCarsMVP.Domains.Handball;

namespace VavaCarsMVP.Domains.Basketball;

public class BasketballPlayer : Player
{
    // customized feature for handball player
    public int ScoredPoints { get; set; }
    public int Rebounds { get; set; }
    public int Assists { get; set; }

    public BasketballPlayer(string name, string nickname, int number, string teamName, char position) : base(name, nickname, number, teamName, position)
    {
    }

    public override int RatingPoints()
    {
        return Position switch
        {
            (char)BasketballPlayerPosition.Guard => (ScoredPoints * 2 + Rebounds * 3 + Assists * 1),
            (char)BasketballPlayerPosition.Forward => (ScoredPoints * 2 + Rebounds * 2 + Assists * 2),
            (char)BasketballPlayerPosition.Center => (ScoredPoints * 2 + Rebounds * 1 + Assists * 3),
            _ => throw new ArgumentException("Invalid basketball position")
        };
    }

    public override int TeamPoint()
    {
        return ScoredPoints;
    }
}