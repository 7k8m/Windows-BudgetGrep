﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WindowsGrep.Common;
using WindowsGrep.Engine;

namespace WindowsGrep.Test.ChainCommands
{
    public class ChainCommandTests : TestBase
    {
        #region Member Variables..
        private string _TestDataRelativePath = @"ChainCommands\TestData";
        #endregion Member Variables..

        #region Properties..
        #endregion Properties..

        #region Setup
        [SetUp]
        public void Setup()
        {
            TestDataDirectory = Path.Combine(TestConfigurationManager.ProjectDirectory, _TestDataRelativePath);
        }
        #endregion Setup

        #region Tests..
        #region ChainCommands_One
        [Test]
        public void ChainCommands_One()
        {
            string SearchTerm = "fox jumps over";
            string Command = $"-d '{TestDataDirectory}' -k ChainCommands | -r -i {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count == 3);
        }
        #endregion ChainCommands_One 

        #region ChainCommands_Two
        [Test]
        public void ChainCommands_Two()
        {
            string SearchTerm = "fox jumps over";
            string Command = $"-d '{TestDataDirectory}' -k ChainCommands | -r -i {SearchTerm} | -k Two";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count == 1);
        }
        #endregion ChainCommands_Two 
        #endregion Tests..
    }
}
