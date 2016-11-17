using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using FindXpert.Repository.Contracts;
using FindXpert.Repository.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FindXpert.Tests.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void test_repository_mocking()
        {
            List<Expert> experts = new List<Expert>()
            {
                new Expert() { Id = 1, FirstName = "John", LastName = "Silver", Projects = new List<Project>()},
                new Expert() { Id = 2, FirstName = "Don", LastName = "Pon", Projects = new List<Project>()}
            };

            Mock<IExpertRepository> mockExpertRepository = new Mock<IExpertRepository>();
            mockExpertRepository.Setup(obj => obj.Get()).Returns(experts);

            RepositoryTestClass repositoryTest = new RepositoryTestClass(mockExpertRepository.Object);

            IEnumerable<Expert> ret = repositoryTest.GetExperts();

            Assert.IsTrue(ret == experts);
        }

        [TestMethod]
        public void test_factory_mocking2()
        {
            List<Expert> experts = new List<Expert>()
            {
                new Expert() { Id = 1, FirstName = "John", LastName = "Silver", Projects = new List<Project>()},
                new Expert() { Id = 2, FirstName = "Don", LastName = "Pon", Projects = new List<Project>()}
            };

            Mock<IExpertRepository> mockExpertRepository = new Mock<IExpertRepository>();
            mockExpertRepository.Setup(obj => obj.Get()).Returns(experts);

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IExpertRepository>()).Returns(mockExpertRepository.Object);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<Expert> ret = factoryTest.GetExperts();

            Assert.IsTrue(ret == experts);
        }
        
    }


    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
        }

        public RepositoryTestClass(IExpertRepository expertRepository)
        {
            _ExpertRepository = expertRepository;
        }

        IExpertRepository _ExpertRepository;

        public IEnumerable<Expert> GetExperts()
        {
            IEnumerable<Expert> experts = _ExpertRepository.Get();

            return experts;
        }
    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _DataRepositoryFactory;

        public IEnumerable<Expert> GetExperts()
        {
            IExpertRepository carRepository = _DataRepositoryFactory.GetDataRepository<IExpertRepository>();

            IEnumerable<Expert> experts = carRepository.Get();

            return experts;
        }
    }

}
