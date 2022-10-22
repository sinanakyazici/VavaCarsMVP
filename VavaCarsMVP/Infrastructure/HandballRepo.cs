using VavaCarsMVP.Domains.Handball;

namespace VavaCarsMVP.Infrastructure;

public interface IHandballRepo : IRepository<HandballPlayer>
{
}

public class HandballRepo : Repository<HandballPlayer>, IHandballRepo
{
    public HandballRepo(string fileName) : base(fileName)
    {
    }
}