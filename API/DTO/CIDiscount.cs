using System;
using System.Xml.Serialization;

namespace API.DTO
{
    [XmlRoot(ElementName = "CIDiscount")]
	public class CIDiscount
	{

		[XmlAttribute(AttributeName = "currency")]
		public string Currency;

		[XmlAttribute(AttributeName = "discountActive")]
		public string DiscountActive;

		[XmlAttribute(AttributeName = "discountDate")]
		public DateTime DiscountDate;

		[XmlText]
		public double Text;
	}


}
