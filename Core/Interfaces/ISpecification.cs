using System.Linq.Expressions;

namespace Core.Interfaces;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; }
}