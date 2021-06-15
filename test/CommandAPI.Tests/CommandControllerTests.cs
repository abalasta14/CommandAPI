using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Model;
using CommandAPI.Data;
using Xunit;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Profiles;

namespace CommandAPI.Tests
{
    public class CommandControllerTests
    {
        [Fact]
        public void GetCommands_Return200Ok_WhenDBIsEmpty()
        {
            //Arrange

            var mockRepo = new Mock<ICommandAPIRepo>();

            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));

            var realProfile = new CommandsProfile();
            var configuration = new MapperConfiguration(config => config.AddProfile(realProfile));
            IMapper mapper = new Mapper(configuration);

            var controller = new CommandsController(mockRepo.Object, mapper);
        }

        private List<Command> GetCommands(int num)
        {
            var commands  = new List<Command>();
            if(num > 0)
            {
                commands.Add(new Command 
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"   
                });
            }
           
           return commands;
        }
    }

}