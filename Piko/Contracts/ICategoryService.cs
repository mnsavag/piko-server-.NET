using Piko.Models.Entities;


namespace Piko.Contracts
{
    public interface ICategoryService
    {
        List<Category> GetAll(); 
    }
}