using VavaCarsMVP.Domains.Basketball;

namespace VavaCarsMVP.Infrastructure;

public interface IBasketballRepo : IRepository<BasketballPlayer>
{
}

public class BasketballRepo : Repository<BasketballPlayer>, IBasketballRepo
{
    public BasketballRepo(string fileName) : base(fileName)
    {
    }
}