using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        
        private static string CatalogGUID => stableGUID ??= Guid.NewGuid().ToString();
        private static string stableGUID;
        
        private readonly string pathMain = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                                                        $"..\\..\\..\\Serialization");
        private Catalog catalogMain;
        private readonly XmlSerializer serializerMain;
        private const string fileName = "CatalogSerialization.xml";
        private string FullPath(string ID) => $"{pathMain}\\{ID}";
        private string FullPathWithName(string ID) => $"{pathMain}\\{ID}\\{fileName}";

        public CatalogController()
        {
            serializerMain ??= new XmlSerializer(typeof(TestDto));
            if (!Directory.Exists(pathMain)) Directory.CreateDirectory(pathMain);
        }

        [HttpGet("Content")]
        [Produces("text/xml")]
        [Consumes("text/xml", "application/xml")]
        public TestDto GetString()
        {
            var test = new TestDto();
            test.TestValue = new List<string>() { "Item1", "Item2" };

            return test;
        }

        
        [HttpPost("Content/Add/{id}")]
        [Produces("text/xml")]
        [Consumes("text/xml", "application/xml")]
        public IActionResult GetCatalogContentByID(string id, [FromBody] TestDto requestDTO)
        {
            if (requestDTO == null || !Guid.TryParse(id, out Guid resultGUID)) return BadRequest();
            if (!Directory.Exists(FullPath(id))) Directory.CreateDirectory(FullPath(id)); 
            using (FileStream fileStream = new FileStream(FullPathWithName(resultGUID.ToString()), FileMode.Create))
            {
                serializerMain.Serialize(fileStream, requestDTO);
                fileStream.Close();
            }
            
            TestDto example = new();
            using (FileStream fileStream = new(FullPathWithName(resultGUID.ToString()), FileMode.Open))
            {
                example = (TestDto)serializerMain.Deserialize(fileStream);
            }
            
            return Ok(example);
        }

        
        
        [XmlRoot(ElementName = "TestDTo")]
        [Serializable()]
        public sealed class TestDto
        {

            [XmlAnyElement("VersionComment")]
            public XmlComment VersionComment { get { return new XmlDocument().CreateComment("Generated as responce"); } set { } }


            [XmlArray(ElementName = "TestValue")]
            public List<string> TestValue { get; set; }
        }
        
        ~CatalogController()
        {
            DirectoryInfo[] subDirectories = new DirectoryInfo($"{pathMain}\\").GetDirectories();
            if (subDirectories.Length > 5)
            {
                for (int i = 0; i < subDirectories.Length; i++)
                {
                    DirectoryInfo subDirectory = subDirectories[i];
                    subDirectory.Delete(true);
                }
            }
        }
    }
}
