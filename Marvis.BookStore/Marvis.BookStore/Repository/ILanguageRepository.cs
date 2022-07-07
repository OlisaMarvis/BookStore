using Marvis.BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marvis.BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}