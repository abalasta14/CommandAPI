using System;
using Xunit;
using CommandAPI.Model;

namespace CommandAPI.Tests 
{
    public class CommandTests : IDisposable
    {

        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange

            //Act
            testCommand.HowTo = "Execute Unit Tests";

            //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {

            testCommand.Platform = "xUnit";

            Assert.Equal("xUnit", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {

            testCommand.CommandLine = "dot net add package <Name of package>";

            Assert.Equal("dot net add package <Name of package>", testCommand.CommandLine);
        }

       
    }
}