using System.Xml.Serialization;

namespace API.DTO
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Catalog)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "CIImage")]
	public class CIImage
	{

		[XmlAttribute(AttributeName = "cipid")]
		public string Cipid;

		[XmlAttribute(AttributeName = "title")]
		public string Title;

		[XmlAttribute(AttributeName = "imgType")]
		public string ImgType;

		[XmlAttribute(AttributeName = "srcLink")]
		public string SrcLink;
	}


}
