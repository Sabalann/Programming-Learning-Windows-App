using Programming_Learning_Windows_App;
using Moq;
using NUnit.Framework;
using Programming_Learning_App;

namespace App.UnitTests
{
    [TestFixture]
    public class CommandTests
    {
        private Character _character;
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(10, 10);
            _character = new Character(_grid); 
        }


        [Test]
        public void MoveCommand_ExecutesCorrectly()
        {

            _character.Move(3);


            Assert.AreEqual((3, 0), _character.Position);
        }


        [Test]
        public void TurnCommand_ExecutesCorrectly()
        {

            _character.Turn(Direction.Right);


            Assert.AreEqual(Facing.South, _character.Facing);
        }


        [Test]
        public void RepeatCommand_ExecutesAllCommands1Correctly()
        {

            var character = new Character(_grid);
            var moveCommand = new Move(2);
            var turnCommand = new Turn(Direction.Right);

            var commands = new List<Command> { moveCommand, turnCommand };
            var repeatCommand = new Repeat(2, commands);


            repeatCommand.Execute(character);



            Assert.AreEqual((2,2), character.Position);
        }

        [Test]
        public void RepeatCommand_ExecutesAllCommands2Correctly()
        {

            var character = new Character(_grid);
            var moveCommand = new Move(2);
            var turnCommand = new Turn(Direction.Right);

            var commands = new List<Command> { moveCommand, turnCommand };
            var repeatCommand = new Repeat(2, commands);


            repeatCommand.Execute(character);


            Assert.AreEqual(Facing.West, character.Facing);
        }
    }
}
