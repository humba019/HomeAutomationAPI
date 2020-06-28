using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Persistences.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
