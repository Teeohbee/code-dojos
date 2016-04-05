using System.Net.NetworkInformation;
using NUnit.Framework;

namespace Sokoban
{
    [TestFixture]
    public class SokobanTests
    {
        [Test]
        public void GridIsCreatedFromGiven5By3Size()
        {
            var sokoban = new Sokoban(5, 3);

            Assert.That(sokoban.Grid[0], Is.EqualTo("#####"));
            Assert.That(sokoban.Grid[1], Is.EqualTo("#   #"));
            Assert.That(sokoban.Grid[2], Is.EqualTo("#####"));
        }

        [Test]
        public void PlaceManOnBoardPlacesMan()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(3, 1);

            Assert.That(sokoban.Grid[1], Is.EqualTo("#  @#"));
        }

        [Test]
        public void PlaceManOnBoardOn21PlacesManAt21()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(2, 1);

            Assert.That(sokoban.Grid[1], Is.EqualTo("# @ #"));
        }

        [Test]
        public void MovingLeftFrom31MovesManLeftTo21()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(3, 1);

            sokoban.Move('A');
            Assert.That(sokoban.Grid[1], Is.EqualTo("# @ #"));
        }

        [Test]
        public void PlaceCrateOnBoardOn11PlacesManAt11()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceCrate(1, 1);

            Assert.That(sokoban.Grid[1], Is.EqualTo("#o  #"));
        }

        [Test]
        public void MovingLeftFrom21MovesManLeftTo11()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(2, 1);

            sokoban.Move('A');
            Assert.That(sokoban.Grid[1], Is.EqualTo("#@  #"));
        }

        [Test]
        public void MovingManLeftFrom31NearCrateMovesManLeftTo21AndCrateTo11()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(3, 1);
            sokoban.PlaceCrate(2, 1);

            sokoban.Move('A');
            Assert.That(sokoban.Grid[1], Is.EqualTo("#o@ #"));
        }

        [Test]
        public void PlaceStorageOnBoardOn11PlacesStorageAt11()
        {
            var sokoban = new Sokoban(5, 3);

            sokoban.PlaceStorage(1, 1);

            Assert.That(sokoban.Grid[1], Is.EqualTo("#.  #"));
        }

        [Test]
        public void MovingCrateOntoStorageShowsCrateOnStorage()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(3, 1);
            sokoban.PlaceCrate(2, 1);
            sokoban.PlaceStorage(1, 1);

            sokoban.Move('A');
            Assert.That(sokoban.Grid[1], Is.EqualTo("#*@ #"));
        }

        [Test]
        public void MovingManOntoStorageShowsManOnStorage()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(3, 1);
            sokoban.PlaceStorage(2, 1);

            sokoban.Move('A');
            Assert.That(sokoban.Grid[1], Is.EqualTo("# + #"));
        }

        [Test]
        public void MovingManIntoWallDoesntMoveMan()
        {
            var sokoban = new Sokoban(5, 3);
            sokoban.PlaceMan(1, 1);

            sokoban.Move('A');
            Assert.That(sokoban.Grid[1], Is.EqualTo("#@  #"));
        }


    }
}