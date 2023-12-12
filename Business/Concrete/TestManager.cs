using Business.Abstract;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TestManager : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestManager(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public void Add(Test test)
        {
            _testRepository.Add(test);
        }

        public List<Test> GetTests()
        {
           return _testRepository.GetList();
        }
    }
}
