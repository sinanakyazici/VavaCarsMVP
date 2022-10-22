// See https://aka.ms/new-console-template for more information

using VavaCarsMVP.Domains;
using VavaCarsMVP.Domains.Match;
using VavaCarsMVP.Infrastructure;

IBasketballRepo basketballRepo = new BasketballRepo("basketballdata.txt");
IHandballRepo handballRepo = new HandballRepo("handballdata.txt");
var basketballPlayers = basketballRepo.GetPlayers();
var handballPlayers = handballRepo.GetPlayers();

var basketballMatch = new MatchStats<Player>(basketballPlayers);
var handballMatch = new MatchStats<Player>(handballPlayers);
var list = new List<MatchStats<Player>>
{
    basketballMatch,
    handballMatch
};

var mvpPlayer = MvpPlayer.Get(list);

Console.WriteLine($"Mvp Player : {mvpPlayer}");
