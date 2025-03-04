namespace AirBelgie.Data;

public interface IRepository<T>
{
    // This is a placeholder interface for repositories
    // These repositories are the classes that interact with the database.
    T GetById(int id);
}