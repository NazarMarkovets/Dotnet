using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CIAbout")]
	public class CIAbout
	{

		[XmlElement(ElementName = "CIAboutTitle")]
		public string CIAboutTitle;

		[XmlElement(ElementName = "CIAboutMain")]
		public string CIAboutMain;
	}


}
