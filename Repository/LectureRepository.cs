using Contracts;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LectureRepository : RepositoryBase<Lecture>, ILectureRepository
    {
        public LectureRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
