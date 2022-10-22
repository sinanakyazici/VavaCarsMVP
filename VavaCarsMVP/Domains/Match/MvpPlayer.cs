namespace VavaCarsMVP.Domains.Match;

public class MvpPlayer
{
    private MvpPlayer()
    {
    }

    public static string Get<T>(List<MatchStats<T>> matchList) where T : Player
    {
        var dict = new Dictionary<string, int>();
        foreach (var matchScore in matchList)
        {
            var winnerTeamName = matchScore.WinnerTeamName;
            foreach (var player in matchScore.Players)
            {
                var rating = player.RatingPoints();
                if (player.TeamName == winnerTeamName)
                {
                    rating += 10;
                }

                if (dict.ContainsKey(player.Name))
                {
                    dict[player.Name] += rating;
                }
                else
                {
                    dict.Add(player.Name, rating);
                }
            }
        }

        return dict.MaxBy(x => x.Value).Key;
    }
}