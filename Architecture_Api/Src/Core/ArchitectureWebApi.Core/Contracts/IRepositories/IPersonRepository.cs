namespace ArchitectureWebApi.Core.Contracts.IRepositories;

public  interface IPersonRepository<T> where T : class
{
    Task<(bool, String)> Create(T person);
    Task<List<T>> GetStdDetails();
    Task<T> GetStdDetailsById(int id);
    Task<(bool, string)> Delete(int id);
    Task<(bool, String)> Update(T person);
    Task<(bool, T)> PersonExists(int id);
}
