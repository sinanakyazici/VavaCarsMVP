using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using VavaCarsMVP.Domains;

namespace VavaCarsMVP.Infrastructure;


public interface IRepository<out T>
{
    IEnumerable<T> GetPlayers();
}

public class Repository<T> : IRepository<T> where T : Player
{
    private readonly string _fileName;
    public Repository(string fileName)
    {
        _fileName = fileName;
    }

    public IEnumerable<T> GetPlayers()
    {
        var list = new List<T>();
        string[] headers = { };
        var counter = 0;
        foreach (var line in File.ReadLines(_fileName))
        {
            if (counter == 0) headers = line.Split(';');
            else
            {
                var items = line.Split(';');
                var dict = new Dictionary<string, string>();
                for (var i = 0; i < items.Length; i++)
                {
                    dict.Add(headers[i], items[i]);
                }
                var json = JsonSerializer.Serialize(dict);
                var obj = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { NumberHandling = JsonNumberHandling.AllowReadingFromString });
                if (obj != null)
                {
                    // unique index for player name
                    if (list.Any(x => x.Name == obj.Name))
                    {
                        throw new DuplicateNameException($"Duplicated player name: ${obj.Name}");
                    }
                    list.Add(obj);
                }
            }
            counter++;
        }

        return list;
    }
}