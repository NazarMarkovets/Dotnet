using API.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GlobalTesting.API
{
    [TestFixture]
    class DataTransferObjectsTest
    {
        private Catalog catalogMain;
        private XmlSerializer serializerMain;
        private readonly string pathMain = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Serialization");
        private const string fileName = "CatalogSerialization.xml";
        private string FullPath => $"{pathMain}\\{fileName}";
        private string stableGUID;

        private string StableGUID => stableGUID ??= Guid.NewGuid().ToString();

        [OneTimeSetUp]
        protected void Prepare()
        {
            catalogMain = new Catalog();
            serializerMain = new XmlSerializer(typeof(Catalog));
            if (!Directory.Exists(pathMain)) Directory.CreateDirectory(pathMain);
        }

        [SetUp]
        protected void Setup()
        {
            catalogMain.CatalogCategory = new CatalogCategory();
            catalogMain.CatalogCategory.Title = "TEST TITLE";
            catalogMain.CatalogCategory.Ccid = StableGUID;
        }

        [Test]
        [Order(1)]
        [Description("Check serialization working")]
        public void SerializationTest()
        {
            using FileStream fileStream = new(FullPath, FileMode.Create);
            serializerMain.Serialize(fileStream, catalogMain);
            Assert.True(File.Exists(FullPath), "Object can't be serialized");
            fileStream.Close();
            fileStream.Dispose();
        }

        [Test]
        [Order(2)]
        [Description("Check serialization working")]
        public void DeserializationTest()
        {
            SerializationTest();
            FileStream fileStream = null;
            Assert.DoesNotThrow(() => fileStream = new(FullPath, FileMode.Open));
            catalogMain = (Catalog)serializerMain.Deserialize(fileStream);
            Assert.AreEqual(expected: StableGUID, catalogMain.CatalogCategory.Ccid);
            Assert.AreEqual(expected: "TEST TITLE", catalogMain.CatalogCategory.Title);
            fileStream.Close();
            fileStream.Dispose();
        }


    }
}
