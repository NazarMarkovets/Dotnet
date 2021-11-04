using System.Collections.Generic;
using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CatalogCategory")]
	public class CatalogCategory
	{

		[XmlElement(ElementName = "CatalogItem")]
		public List<CatalogItem> CatalogItem;

		[XmlAttribute(AttributeName = "ccid")]
		public string Ccid;

		[XmlAttribute(AttributeName = "title")]
		public string Title;

		[XmlText]
		public string Text;
	}


}
