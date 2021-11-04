using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CatalogItem")]
	public class CatalogItem
	{

		[XmlElement(ElementName = "CINo")]
		public int CINo;

		[XmlElement(ElementName = "CIImage")]
		public CIImage CIImage;

		[XmlElement(ElementName = "CITitle")]
		public string CITitle;

		[XmlElement(ElementName = "CIDescription")]
		public CIDescription CIDescription;

		[XmlElement(ElementName = "CIPriceInfo")]
		public CIPriceInfo CIPriceInfo;

		[XmlAttribute(AttributeName = "ciid")]
		public string Ciid;

		[XmlAttribute(AttributeName = "available")]
		public string Available;

		[XmlAttribute(AttributeName = "class")]
		public string Class;

		[XmlText]
		public string Text;
	}


}
