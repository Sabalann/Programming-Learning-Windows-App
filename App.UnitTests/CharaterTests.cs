using Moq;
using NUnit.Framework;
using Programming_Learning_Windows_App;


namespace App.UnitTests
{
    [TestFixture]
    public class CharacterTests
    {
        private Grid _grid;
        private Character _character;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(10, 10);
            _character = new Character(_grid);
        }

        [Test]
        public void Character_ShouldStartAtPosition_0_0()
        {
            Assert.AreEqual((0, 0), _character.Position);
        }

        [Test]
        public void Character_ShouldStartFacingEast()
        {
            Assert.AreEqual(Facing.East, _character.Facing);
        }

        [Test]
        public void Character_InitialPath_ShouldContainStartPosition()
        {
            CollectionAssert.AreEqual(new List<(int, int)> { (0, 0) }, _character.Path);
        }

        [Test]
        public void Character_MoveEast_ShouldUpdatePosition()
        {
            _character.Move(3);
            Assert.AreEqual((3, 0), _character.Position);
        }

        [Test]
        public void Character_MoveEast_ShouldUpdatePath()
        {
            _character.Move(2);
            var expectedPath = new List<(int, int)> { (0, 0), (1, 0), (2, 0) };
            CollectionAssert.AreEqual(expectedPath, _character.Path);
        }

        [Test]
        public void Character_TurnLeft_FromEast_ShouldFaceNorth()
        {
            _character.Turn(Direction.Left);
            Assert.AreEqual(Facing.North, _character.Facing);
        }
    }
}
