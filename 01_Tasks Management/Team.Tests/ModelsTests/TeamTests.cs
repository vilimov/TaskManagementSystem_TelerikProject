using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    internal class TeamTests
    {
        [TestMethod]
        public void CreateNewMember_When_InputIdIsValid()
        {
            //Arrange
            string teamName = TeamData.ValidName;
            string classType = "Team";
            //Act
            var sut = new Model.Team(teamName);

            //Assert
            Assert.AreEqual(sut.GetType().Name, classType);
        }
    }
}
