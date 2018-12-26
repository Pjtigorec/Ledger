using Common.Core;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        List<Subject> GetSubjects();

        Subject GetSubjectById(int id);
    }
}
