using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API.DTO
{

    [XmlRoot(ElementName = "Catalog")]
	[Serializable]
	public class Catalog
	{
		[XmlElement(ElementName = "CatalogCategory")]
		public CatalogCategory CatalogCategory;

		[XmlAttribute(AttributeName = "xs")]
		public string Xs;

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi;

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation;

		[XmlText]
		public string Text;
	}


}
