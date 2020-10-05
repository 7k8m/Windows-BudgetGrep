﻿using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WindowsGrep.Common;
using WindowsGrep.Engine;

namespace WindowsGrep.Test.Flags.Delete
{
    public class DeleteTests : TestBase
    {
        #region Member Variables..
        private string _FlagDescriptorShort;
        private string _FlagDescriptorLong;
        private string _TestDataRelativePath = @"Flags\Delete\TestData";
        private string _TestFilePath;
        #endregion Member Variables..

        #region Properties..
        #endregion Properties..

        #region Setup
        [SetUp]
        public void Setup()
        {
            TestDataDirectory = Path.Combine(TestConfigurationManager.ProjectDirectory, _TestDataRelativePath);
            _TestFilePath = Path.Combine(TestDataDirectory, "DeleteOutput.txt");

            List<string> DescriptionCollection = ConsoleFlag.Delete.GetCustomAttribute<DescriptionCollectionAttribute>()?.Value.OrderBy(x => x.Length).ToList();
            _FlagDescriptorShort = DescriptionCollection[0];
            _FlagDescriptorLong = DescriptionCollection[1];
        }
        #endregion Setup

        #region Tests..
        #region FlagFirst..
        #region Write_FlagFirst_FlagShort
        [Test]
        public void Write_FlagFirst_FlagShort()
        {
            File.WriteAllText(_TestFilePath, "Delete flag test");

            string SearchTerm = "Delete flag test";
            string Command = $"{_FlagDescriptorShort} -f '{_TestFilePath}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsFalse(File.Exists(_TestFilePath));
        }
        #endregion Write_FlagFirst_FlagShort 
        #endregion FlagFirst..

        #region FlagMiddle..
        #region Write_FlagMiddle_FlagShort
        [Test]
        public void Write_FlagMiddle_FlagShort()
        {
            File.WriteAllText(_TestFilePath, "Delete flag test");

            string SearchTerm = "Delete flag test";
            string Command = $"-f '{_TestFilePath}' {_FlagDescriptorShort} {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsFalse(File.Exists(_TestFilePath));
        }
        #endregion Write_FlagMiddle_FlagShort 
        #endregion FlagMiddle..

        #region FlagLast..
        #region Write_FlagLast_FlagShort
        [Test]
        public void Write_FlagLast_FlagShort()
        {
            File.WriteAllText(_TestFilePath, "Delete flag test");

            string SearchTerm = "Delete flag test";
            string Command = $"-f '{_TestFilePath}' {SearchTerm} {_FlagDescriptorShort}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsFalse(File.Exists(_TestFilePath));
        }
        #endregion Write_FlagLast_FlagShort 
        #endregion FlagLast..
        #endregion Tests..

        #region Methods..
        #endregion Methods..
    }
}
