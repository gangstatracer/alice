using System.Linq;
using CookAssistant.Storage;
using FluentAssertions;
using NUnit.Framework;

namespace CookAssistant.Test
{
    public class RecepiesStorageTests
    {
        private RecepiesStorage _recepiesStorage;

        [SetUp]
        public void SetUp()
        {
            _recepiesStorage = new RecepiesStorage();
        }

        [Test]
        public void TestGetAll()
        {
            _recepiesStorage.GetAll().Count().Should().BeGreaterOrEqualTo(1);
        }

        [Test]
        public void TestGetRandom()
        {
            _recepiesStorage.GetRandom().Should().NotBeNull();
        }

        [Test]
        public void TestGetByName()
        {
            var recepie = _recepiesStorage.GetByName("пюре");
            recepie.Should().NotBeNull();
            recepie.GetComponentsText().Should().Be("масло, картофель");
        }
    }
}