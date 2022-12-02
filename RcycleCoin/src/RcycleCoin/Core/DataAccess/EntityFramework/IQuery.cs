namespace Core.DataAccess.EntityFramework;

public interface IQuery<T>
{
    IQueryable<T> Query();
}