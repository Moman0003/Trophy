using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trophy.Tests
{
    [TestClass]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new TrophiesRepository();
        }

        [TestMethod]
        public void Add_ShouldAssignIdAndAddTrophy()
        {
            var newTrophy = new Trophy
            {
                Competition = "Champions League Final",
                Year = 2021
            };

            var added = repo.Add(newTrophy);

            Assert.IsNotNull(added);
            Assert.IsTrue(added.Id > 0, "Id skal være tildelt og > 0");
            var retrieved = repo.GetById(added.Id);
            Assert.IsNotNull(retrieved, "Trophy skal kunne hentes efter tilføjelsen");
            Assert.AreEqual("Champions League Final", retrieved.Competition);
            Assert.AreEqual(2021, retrieved.Year);
        }

        [TestMethod]
        public void Remove_ShouldReturnRemovedTrophyAndDeleteIt()
        {
            var newTrophy = new Trophy
            {
                Competition = "Europa League Final",
                Year = 2020
            };
            var added = repo.Add(newTrophy);

            var removed = repo.Remove(added.Id);

            Assert.IsNotNull(removed, "Removed skal ikke være null");
            Assert.AreEqual(added.Id, removed.Id, "Fjernede trophy skal have samme id");
            Assert.IsNull(repo.GetById(added.Id), "Efter fjernelse skal GetById returnere null");
        }

        [TestMethod]
        public void Update_ShouldModifyExistingTrophy()
        {
            var newTrophy = new Trophy
            {
                Competition = "National Cup",
                Year = 2019
            };
            var added = repo.Add(newTrophy);
            var updateValues = new Trophy
            {
                Competition = "Updated Cup",
                Year = 2022
            };

            var updated = repo.Update(added.Id, updateValues);

            Assert.IsNotNull(updated, "Updated skal ikke være null");
            Assert.AreEqual(added.Id, updated.Id, "Id skal forblive uændret");
            Assert.AreEqual("Updated Cup", updated.Competition);
            Assert.AreEqual(2022, updated.Year);
        }
    }
}