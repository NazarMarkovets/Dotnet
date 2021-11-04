using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CIBenefits")]
	public class CIBenefits
	{

		[XmlElement(ElementName = "BenefitTitle")]
		public string BenefitTitle;

		[XmlElement(ElementName = "BenefitsList")]
		public BenefitsList BenefitsList;
	}


}
