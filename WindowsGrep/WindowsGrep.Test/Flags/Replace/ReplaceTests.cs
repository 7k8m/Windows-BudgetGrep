﻿using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WindowsGrep.Common;
using WindowsGrep.Engine;

namespace WindowsGrep.Test.Flags.Replace
{
    public class ReplaceTests : TestBase
    {
        #region Member Variables..
        private const string _TestFileTemplateText = "The quick brown fox jumps over the lazy dog";
        private const string _TestFileExpectedResultText = "The slow green turtle jumps over the lazy dog";

        private string _FlagDescriptorShort;
        private string _FlagDescriptorLong;
        private string _TestDataRelativePath = @"Flags\Replace\TestData";
        #endregion Member Variables..

        #region Properties..
        #endregion Properties..

        #region Setup
        [SetUp]
        public void Setup()
        {
            TestDataDirectory = Path.Combine(TestConfigurationManager.ProjectDirectory, _TestDataRelativePath);

            List<string> DescriptionCollection = ConsoleFlag.Replace.GetCustomAttribute<DescriptionCollectionAttribute>()?.Value.OrderBy(x => x.Length).ToList();
            _FlagDescriptorShort = DescriptionCollection[0];
            _FlagDescriptorLong = DescriptionCollection[1];

            // Build TestData directory if it doesn't exist yet
            System.IO.Directory.CreateDirectory(TestDataDirectory);
        }
        #endregion Setup

        #region Tests..
        #region FlagFirst..
        #region Replace_FlagFirst_FlagShort_SingleQuotes
        [Test]
        public void Replace_FlagFirst_FlagShort_SingleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"{_FlagDescriptorShort} '{ReplaceText}' -d '{TestDataDirectory}' {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagFirst_FlagShort_SingleQuotes 

        #region Replace_FlagFirst_FlagShort_DoubleQuotes
        [Test]
        public void Replace_FlagFirst_FlagShort_DoubleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"{_FlagDescriptorShort} \"{ReplaceText}\" -d '{TestDataDirectory}' {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagFirst_FlagShort_DoubleQuotes

        #region Replace_FlagFirst_FlagLong_SingleQuotes
        [Test]
        public void Replace_FlagFirst_FlagLong_SingleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"{_FlagDescriptorLong} '{ReplaceText}' -d '{TestDataDirectory}' {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagFirst_FlagLong_SingleQuotes 

        #region Replace_FlagFirst_FlagLong_DoubleQuotes
        [Test]
        public void Replace_FlagFirst_FlagLong_DoubleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"{_FlagDescriptorLong} \"{ReplaceText}\" -d '{TestDataDirectory}' {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagFirst_FlagLong_DoubleQuotes
        #endregion FlagFirst..

        #region FlagMiddle..
        #region Replace_FlagMiddle_FlagShort_SingleQuotes
        [Test]
        public void Replace_FlagMiddle_FlagShort_SingleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {_FlagDescriptorShort} '{ReplaceText}' {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagMiddle_FlagShort_SingleQuotes 

        #region Replace_FlagMiddle_FlagShort_DoubleQuotes
        [Test]
        public void Replace_FlagMiddle_FlagShort_DoubleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {_FlagDescriptorShort} \"{ReplaceText}\" {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagMiddle_FlagShort_DoubleQuotes

        #region Replace_FlagMiddle_FlagLong_SingleQuotes
        [Test]
        public void Replace_FlagMiddle_FlagLong_SingleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {_FlagDescriptorLong} '{ReplaceText}' {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagMiddle_FlagLong_SingleQuotes 

        #region Replace_FlagMiddle_FlagLong_DoubleQuotes
        [Test]
        public void Replace_FlagMiddle_FlagLong_DoubleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {_FlagDescriptorLong} \"{ReplaceText}\" {SearchTerm}";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagMiddle_FlagLong_DoubleQuotes
        #endregion FlagMiddle..

        #region FlagLast..
        #region Replace_FlagLast_FlagShort_SingleQuotes
        [Test]
        public void Replace_FlagLast_FlagShort_SingleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {SearchTerm} {_FlagDescriptorShort} '{ReplaceText}'";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagLast_FlagShort_SingleQuotes 

        #region Replace_FlagLast_FlagShort_DoubleQuotes
        [Test]
        public void Replace_FlagLast_FlagShort_DoubleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {SearchTerm} {_FlagDescriptorShort} \"{ReplaceText}\"";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagLast_FlagShort_DoubleQuotes

        #region Replace_FlagLast_FlagLong_SingleQuotes
        [Test]
        public void Replace_FlagLast_FlagLong_SingleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {SearchTerm} {_FlagDescriptorLong} '{ReplaceText}'";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagLast_FlagLong_SingleQuotes 

        #region Replace_FlagLast_FlagLong_DoubleQuotes
        [Test]
        public void Replace_FlagLast_FlagLong_DoubleQuotes()
        {
            try
            {
                CreateTestFiles();

                string SearchTerm = "quick brown fox";
                string ReplaceText = "slow green turtle";
                string Command = $"-d '{TestDataDirectory}' {SearchTerm} {_FlagDescriptorLong} \"{ReplaceText}\"";

                var GrepResultCollection = new GrepResultCollection();
                GrepEngine.RunCommand(Command, GrepResultCollection);

                // Assert there are no files returned in the grep collection whose text doesn't match the expected text
                Assert.IsFalse(GrepResultCollection.Where(result => File.ReadAllText(result.SourceFile) != _TestFileExpectedResultText).Any());
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteTestFiles();
            }
        }
        #endregion Replace_FlagLast_FlagLong_DoubleQuotes
        #endregion FlagLast..
        #endregion Tests..

        #region Methods..

        #region CreateTestFiles
        /// <summary>
        /// Create a copy of each file in TestData
        /// </summary>
        private void CreateTestFiles()
        {
            // File one
            string FilePathOne = Path.Combine(TestDataDirectory, "ReplaceOne.txt");
            File.WriteAllText(FilePathOne, _TestFileTemplateText);
            Assert.IsTrue(File.Exists(FilePathOne));

            // File two
            string FilePathTwo = Path.Combine(TestDataDirectory, "ReplaceTwo.txt");
            File.WriteAllText(FilePathTwo, _TestFileTemplateText);
            Assert.IsTrue(File.Exists(FilePathTwo));
        }
        #endregion CreateTestFiles


        #region DeleteTestFiles
        private void DeleteTestFiles()
        {
            // Delete all files in TestData
            var DirectoryInfo = new DirectoryInfo(TestDataDirectory);
            DirectoryInfo.GetFiles().ToList().ForEach(file => file.Delete());
        }
        #endregion DeleteTestFiles
        #endregion Methods..
    }
}
