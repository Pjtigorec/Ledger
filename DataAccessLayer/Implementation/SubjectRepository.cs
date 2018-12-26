using Common.Core;
using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        public List<Subject> GetSubjects()
        {
            List<Subject> list = new List<Subject>();
            for(int i = 1; i < 11; i++)
            {
                Subject subject = new Subject
                {
                    Id = i,
                    Name = "Предмет №" + i,
                    InventoryNumber = i.ToString(),
                    Description = "Это предмет №" + i
                };
                list.Add(subject);
            }
            return list;
        }

        public Subject GetSubjectById(int id)
        {
            Subject subject = new Subject
            {
                Id = id,
                Name = "Предмет №" + id,
                InventoryNumber = id.ToString(),
                Description = "Это предмет №" + id
            };
            return subject;
        }

        public void Create(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void Update(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
