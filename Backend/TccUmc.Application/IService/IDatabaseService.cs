namespace TccUmc.Application.IService
{
  
  public interface IDatabaseService
  {
    void Reload<T>(T entity);
  }

}