using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CIDescription")]
	public class CIDescription
	{

		[XmlElement(ElementName = "CIGeneralInfo")]
		public string CIGeneralInfo;

		[XmlElement(ElementName = "CIAbout")]
		public CIAbout CIAbout;

		[XmlElement(ElementName = "CIBenefits")]
		public CIBenefits CIBenefits;
	}


}
