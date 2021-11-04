using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CIPriceInfo")]
	public class CIPriceInfo
	{

		[XmlElement(ElementName = "CIDiscount")]
		public CIDiscount CIDiscount;

		[XmlElement(ElementName = "CIPrice")]
		public double CIPrice;
	}


}
