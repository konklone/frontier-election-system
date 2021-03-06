// -----------------------------------------------------------------------------
// <copyright file="ZipHelperFixture.cs" company="Sequoia Voting Systems"> 
//     Copyright (c) 2009 Sequoia Voting Systems, Inc. All Rights Reserved.
//     Distribution of source code is allowable only under the terms of the
//     license agreement found at http://www.sequoiavote.com/license.html
// </copyright>
// <summary>
//     This file contains the ZipHelperFixture test class.
// </summary>
// <revision revisor="dev06" date="1/11/2009" version="1.0.0.0">
//     File Created
// </revision>
// <revision revisor="dev13" date="11/18/2009" version="1.1.3.6">
//     File modified
// </revision>
// -----------------------------------------------------------------------------

namespace UtilityTests
{
    #region Using directives

    using System;
    using System.IO;
    using System.Text;
    
    using NUnit.Framework;

    using Sequoia.Utilities.Compression;
    using Sequoia.Utilities.IO;

    #endregion

    /// <summary>
    ///	    ZipHelperFixture is a test fixture for running tests against the 
    ///     zip helper class in the compression library.
    /// </summary>
    /// <externalUnit/>
    /// <revision revisor="dev06" date="1/11/2009" version="1.0.0.0">
    ///     Class created.
    /// </revision>
    /// <revision revisor="dev13" date="11/18/2009" version="1.1.3.6">
    ///     Formatting changes
    /// </revision>
    [TestFixture]
    public class ZipHelperFixture
    {
        #region Fixture Setup
        /// <summary>
        ///     This method runs once for the entire test fixture. Place any 
        ///     logic that needs to happen before this test fixture is run 
        ///     in this method.
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
        }

        #endregion

        #region Fixture Teardown
        /// <summary>
        ///     This method runs once for the entire test fixture. Place any 
        ///     logic that needs to happen when this test fixture is unloaded.
        /// </summary>
        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
        }
        #endregion

        #region Test Setup
        /// <summary>
        ///     This method runs once for every test in the entire test fixture. 
        ///     Place any logic that needs to happen before every test is loaded 
        ///     in this method.
        /// </summary>
        [SetUp]
        public void TestSetup()
        {
        }
        #endregion

        #region Test Teardown
        /// <summary>
        ///     This method runs once for every test in the entire test fixture. 
        ///     Place any logic that needs to happen when every test is unloaded 
        ///     in this method.
        /// </summary>
        [TearDown]
        public void TestTeardown()
        {
            string testPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        @"..\..\TestData\");
     
            Assert.IsTrue(FileManager.DeleteAllFilesInFolder(
               Path.Combine(testPath, "CompressTestFolder")));
        }

        #endregion

        #region Tests

        /// <summary>
        ///     Tests the zip helper compression
        /// </summary>
        /// <externalUnit/>
        /// <revision revisor="dev13" date="11/18/2009" version="1.1.3.6">
        ///     Added documentation header
        /// </revision>
        [Test]
        public void ZipHelperCompressionTest()
        {
            var compressedItem = ZipHelper.Compress("Hello World");

            string decompressedData = ZipHelper.Decompress(compressedItem);

            Assert.AreEqual("Hello World", decompressedData);
            Assert.AreNotEqual("Hello world", decompressedData);
        }

        /// <summary>
        ///     Tests the zip helper extended unicode compression
        /// </summary>
        /// <externalUnit/>
        /// <revision revisor="dev13" date="11/18/2009" version="1.1.3.6">
        ///     Added documentation header
        /// </revision>
        [Test]
        public void ZipHelperExtendedUnicodeCompressionTest()
        {
            var compressedItem =
                ZipHelper.Compress(
                    "普選正式選票2008年11月4日，星期二伊利諾州芝加哥市");

            string decompressedData = ZipHelper.Decompress(compressedItem);

            Assert.AreEqual(
                "普選正式選票2008年11月4日，星期二伊利諾州芝加哥市",
                decompressedData);
        }

        /// <summary>
        ///     Tests zip helper serialization
        /// </summary>
        /// <externalUnit/>
        /// <revision revisor="dev13" date="11/18/2009" version="1.1.3.6">
        ///     Added documentation header
        /// </revision>
        [Test]
        public void ZipHelperSerialization()
        {
            string testPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\TestData\CompressTestFolder");

            var compressedItem =
                ZipHelper.Compress(
                    "普選正式選票2008年11月4日，星期二伊利諾州芝加哥市");
            int size = compressedItem.CompressedSize;

            File.WriteAllBytes(
                Path.Combine(testPath, "SerializedCompressed.comp"),
                Encoding.Unicode.GetBytes(compressedItem.ToString()));


            var decompressedItem =
                CompressedItem.FromXml(
                    Encoding.Unicode.GetString(
                        File.ReadAllBytes(
                            Path.Combine(
                            testPath, "SerializedCompressed.comp"))));
            
            Assert.AreEqual(size,decompressedItem.CompressedSize);

            string decompressedData = 
                ZipHelper.Decompress(decompressedItem);


            Assert.AreEqual(
                "普選正式選票2008年11月4日，星期二伊利諾州芝加哥市",
                decompressedData);

            File.Delete(Path.Combine(testPath, "SerializedCompressed.comp"));
        }

        /// <summary>
        ///     Tests compressing and decompressing
        /// </summary>
        /// <externalUnit/>
        /// <revision revisor="dev13" date="11/18/2009" version="1.1.3.6">
        ///     Added documentation header
        /// </revision>
        [Test]
        public void CompressDecompressFileTest()
        {
              string testPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\TestData\");
              Assert.IsTrue(FileManager.DeleteAllFilesInFolder(
                 Path.Combine(testPath, "CompressTestFolder")));
       
            Assert.IsTrue(FileManager.DeleteAllFilesInFolder(
                              Path.Combine(testPath, "CompressTestFolder")));
            Assert.AreEqual(
                Directory.GetFiles(
                    Path.Combine(testPath, "CompressTestFolder")).Length, 0);
            Assert.IsTrue(ZipHelper.DeCompressFiles(
                              Path.Combine(testPath, "Test.zip"),
                              Path.Combine(testPath, "CompressTestFolder")));
            Assert.AreEqual(12,
                Directory.GetFiles(
                    Path.Combine(testPath, "CompressTestFolder")).Length);
            Assert.IsTrue(ZipHelper.CompressFiles(
                              Path.Combine(testPath, "CompressTestFolder"),
                              Path.Combine(testPath, "TestNew.zip"),
                              false));
            Assert.AreEqual(
                Directory.GetFiles(
                    testPath, "*.zip").Length, 2);

            Assert.IsTrue(FileManager.DeleteAllFilesInFolder(
                              Path.Combine(testPath, "CompressTestFolder")));
            Assert.AreEqual(
                Directory.GetFiles(
                    Path.Combine(testPath, "CompressTestFolder")).Length, 0);

            Assert.IsTrue(ZipHelper.DeCompressFiles(
                              Path.Combine(testPath, "TestNew.zip"),
                              Path.Combine(testPath, "CompressTestFolder")));
            Assert.AreEqual(12,
                Directory.GetFiles(
                    Path.Combine(testPath, "CompressTestFolder")).Length);

            Assert.IsTrue(FileManager.DeleteAllFilesInFolder(
                              testPath,
                              "*New.zip"));
            Assert.AreEqual(
                Directory.GetFiles(
                    testPath, "*.zip").Length, 1);

            Assert.IsTrue(FileManager.DeleteAllFilesInFolder(
                              Path.Combine(testPath, "CompressTestFolder")));
            Assert.AreEqual(
                Directory.GetFiles(
                    Path.Combine(testPath, "CompressTestFolder")).Length, 0);
        }

        #endregion
    }
}
