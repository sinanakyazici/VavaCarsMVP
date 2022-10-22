namespace VavaCarsMVP.Domains.Handball;

public class HandballPlayer : Player
{
    // customized feature for handball player
    public int GoalsMade { get; set; }
    public int GoalReceived { get; set; }

    public HandballPlayer(string name, string nickname, int number, string teamName, char position) : base(name, nickname, number, teamName, position)
    {
    }

    public override int RatingPoints()
    {
        return Position switch
        {
            (char)HandballPlayerPosition.Goalkeeper => (50 + GoalsMade * 5 + GoalReceived * -2),
            (char)HandballPlayerPosition.FieldPlayer => (20 + GoalsMade * 1 + GoalReceived * -1),
            _ => throw new ArgumentException("Invalid basketball position")
        };
    }

    public override int TeamPoint()
    {
        return GoalsMade;
    }
}
