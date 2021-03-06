﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WindowsGrep.Common;
using WindowsGrep.Engine;

namespace WindowsGrep.Test.Flags.FileNamesOnly
{
    public class FileNamesOnlyTests : TestBase
    {
        #region Member Variables..
        private string _FlagDescriptorShort;
        private string _FlagDescriptorLong;
        private string _TestDataRelativePath = @"Flags\FileNamesOnly\TestData";
        #endregion Member Variables..

        #region Properties..
        #endregion Properties..

        #region Setup
        [SetUp]
        public void Setup()
        {
            TestDataDirectory = Path.Combine(TestConfigurationManager.ProjectDirectory, _TestDataRelativePath);

            List<string> DescriptionCollection = ConsoleFlag.FileNamesOnly.GetCustomAttribute<DescriptionCollectionAttribute>()?.Value.OrderBy(x => x.Length).ToList();
            _FlagDescriptorShort = DescriptionCollection[0];
            _FlagDescriptorLong = DescriptionCollection[1];
        }
        #endregion Setup

        #region Tests..
        #region FlagFirst..
        #region FileNamesOnly_FlagFirst_FlagShort_SingleResult
        [Test]
        public void FileNamesOnly_FlagFirst_FlagShort_SingleResult()
        {
            string SearchTerm = "One";
            string Command = $"{_FlagDescriptorShort} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 1);
        }
        #endregion FileNamesOnly_FlagFirst_FlagShort_SingleResult 

        #region FileNamesOnly_FlagFirst_FlagShort_MultiResult
        [Test]
        public void FileNamesOnly_FlagFirst_FlagShort_MultiResult()
        {
            string SearchTerm = "FileNamesOnly";
            string Command = $"{_FlagDescriptorShort} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 4);
        }
        #endregion FileNamesOnly_FlagFirst_FlagShort_MultiResult 

        #region FileNamesOnly_FlagFirst_FlagLong_SingleResult
        [Test]
        public void FileNamesOnly_FlagFirst_FlagLong_SingleResult()
        {
            string SearchTerm = "One";
            string Command = $"{_FlagDescriptorLong} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 1);
        }
        #endregion FileNamesOnly_FlagFirst_FlagLong_SingleResult

        #region FileNamesOnly_FlagFirst_FlagLong_MultiResult
        [Test]
        public void FileNamesOnly_FlagFirst_FlagLong_MultiResult()
        {
            string SearchTerm = "FileNamesOnly";
            string Command = $"{_FlagDescriptorLong} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 4);
        }
        #endregion FileNamesOnly_FlagFirst_FlagLong_MultiResult
        #endregion FlagFirst..

        #region FlagMiddle..
        #region FileNamesOnly_FlagMiddle_FlagShort_SingleResult
        [Test]
        public void FileNamesOnly_FlagMiddle_FlagShort_SingleResult()
        {
            string SearchTerm = "One";
            string Command = $"-i {_FlagDescriptorShort} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 1);
        }
        #endregion FileNamesOnly_FlagMiddle_FlagShort_SingleResult 

        #region FileNamesOnly_FlagMiddle_FlagShort_MultiResult
        [Test]
        public void FileNamesOnly_FlagMiddle_FlagShort_MultiResult()
        {
            string SearchTerm = "FileNamesOnly";
            string Command = $"-i {_FlagDescriptorShort} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 5);
        }
        #endregion FileNamesOnly_FlagMiddle_FlagShort_MultiResult 

        #region FileNamesOnly_FlagMiddle_FlagLong_SingleResult
        [Test]
        public void FileNamesOnly_FlagMiddle_FlagLong_SingleResult()
        {
            string SearchTerm = "One";
            string Command = $"-i {_FlagDescriptorLong} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 1);
        }
        #endregion FileNamesOnly_FlagMiddle_FlagLong_SingleResult

        #region FileNamesOnly_FlagMiddle_FlagLong_MultiResult
        [Test]
        public void FileNamesOnly_FlagMiddle_FlagLong_MultiResult()
        {
            string SearchTerm = "FileNamesOnly";
            string Command = $"-i {_FlagDescriptorLong} -d '{TestDataDirectory}' {SearchTerm}";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 5);
        }
        #endregion FileNamesOnly_FlagMiddle_FlagLong_MultiResult
        #endregion FlagMiddle..

        #region FlagLast..
        #region FileNamesOnly_FlagLast_FlagShort_SingleResult
        [Test]
        public void FileNamesOnly_FlagLast_FlagShort_SingleResult()
        {
            string SearchTerm = "One";
            string Command = $"{SearchTerm} {_FlagDescriptorShort} -d '{TestDataDirectory}'";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 1);
        }
        #endregion FileNamesOnly_FlagLast_FlagShort_SingleResult 

        #region FileNamesOnly_FlagLast_FlagShort_MultiResult
        [Test]
        public void FileNamesOnly_FlagLast_FlagShort_MultiResult()
        {
            string SearchTerm = "FileNamesOnly";
            string Command = $"{SearchTerm} {_FlagDescriptorShort} -d '{TestDataDirectory}'";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 4);
        }
        #endregion FileNamesOnly_FlagLast_FlagShort_MultiResult 

        #region FileNamesOnly_FlagLast_FlagLong_SingleResult
        [Test]
        public void FileNamesOnly_FlagLast_FlagLong_SingleResult()
        {
            string SearchTerm = "One";
            string Command = $"{SearchTerm} {_FlagDescriptorLong} -d '{TestDataDirectory}'";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 1);
        }
        #endregion FileNamesOnly_FlagLast_FlagLong_SingleResult

        #region FileNamesOnly_FlagLast_FlagLong_MultiResult
        [Test]
        public void FileNamesOnly_FlagLast_FlagLong_MultiResult()
        {
            string SearchTerm = "FileNamesOnly";
            string Command = $"{SearchTerm} {_FlagDescriptorLong} -d '{TestDataDirectory}'";

            var GrepResultCollection = new GrepResultCollection();
            GrepEngine.RunCommand(Command, GrepResultCollection);

            Assert.IsTrue(GrepResultCollection.Count(x => x.MatchedString.EqualsIgnoreCase(SearchTerm)) == 4);
        }
        #endregion FileNamesOnly_FlagLast_FlagLong_MultiResult
        #endregion FlagLast..
        #endregion Tests..
    }
}
