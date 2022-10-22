using VavaCarsMVP.Infrastructure;

namespace VavaCarsMVP.Domains.Match;

public class MatchStats<T> where T : Player
{
    // just can be two teams for a match
    private readonly List<T> _teamOne;
    private readonly List<T> _teamTwo;

    private string? _winnerTeam;
    public string WinnerTeamName
    {
        get
        {
            if (_winnerTeam == null) CalculateMatchScore();
            return _winnerTeam!;
        }
    }

    public List<T> Players { get; }

    public MatchStats(IEnumerable<T> players)
    {
        Players = players.ToList();
        var teams = Players.GroupBy(x => x.TeamName).Select(x => new { TeamName = x.Key, Players = x.ToList() }).ToList();
        _teamOne = teams[0].Players;
        _teamTwo = teams[1].Players;
    }

    private void CalculateMatchScore()
    {
        var teamOneScore = _teamOne.Sum(x => x.TeamPoint());
        var teamTwoScore = _teamTwo.Sum(x => x.TeamPoint());
        if (teamOneScore > teamTwoScore)
        {
            _winnerTeam = _teamOne.First().TeamName;
        }
        else if (teamOneScore < teamTwoScore)
        {
            _winnerTeam = _teamTwo.First().TeamName;
        }
        else
        {
            throw new OperationCanceledException("Match cancelled. Every match must have a winner team.");
        }
    }
}