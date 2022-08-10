using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain.Cosmos;
using Blogger.Domain.Entities;

namespace Blogger.Domain.Interfaces
{
    public interface ICosmosPostRepository
    {
        Task<IEnumerable<CosmosPost>> GetAllAsync();
        Task<CosmosPost> GetByIdAsync(string id);
        Task<CosmosPost> AddAsync(CosmosPost post);
        Task UpdateAsync(CosmosPost post);
        Task DeleteAsync(CosmosPost post);
    }
}
