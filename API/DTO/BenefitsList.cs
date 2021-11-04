using System.Collections.Generic;
using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "BenefitsList")]
	public class BenefitsList
	{

		[XmlElement(ElementName = "BenefitItem")]
		public List<string> BenefitItem;
	}


}
