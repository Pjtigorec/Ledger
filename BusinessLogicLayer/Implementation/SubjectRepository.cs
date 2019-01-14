using Common.Core;
using Common.Interfaces;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        IDataAccess _db;

        public SubjectRepository(IDataAccess db)
        {
            _db = db;
        }

        public List<Subject> GetSubjects()
        {
            return _db.Subjects.GetSubjects();
        }

        public Subject GetSubjectById(int id)
        {
            return _db.Subjects.GetSubjectById(id);
        }

        public void Create(Subject subject)
        {
            _db.Subjects.Create(subject);
        }

        public void Update(Subject subject)
        {
            _db.Subjects.Update(subject);
        }

        public void Delete(int id)
        {
            _db.Subjects.Delete(id);
        }

        public State GetSubjectState(int stateId)
        {
            return _db.Subjects.GetSubjectState(stateId);
        }

        public List<State> GetAllStates()
        {
            return _db.Subjects.GetAllStates();
        }
    }
}
