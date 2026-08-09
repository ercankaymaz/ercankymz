using System.IO;
using System.IdentityModel;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class WSUtilitySpecificationVersion
{
	private sealed class WSUtilitySpecificationVersionOneDotZero : WSUtilitySpecificationVersion
	{
		public static WSUtilitySpecificationVersionOneDotZero Instance { get; } = new WSUtilitySpecificationVersionOneDotZero();

		private WSUtilitySpecificationVersionOneDotZero()
			: base(XD.UtilityDictionary.Namespace)
		{
		}

		internal override bool IsReaderAtTimestamp(XmlDictionaryReader reader)
		{
			return reader.IsStartElement(XD.UtilityDictionary.Timestamp, XD.UtilityDictionary.Namespace);
		}

		internal override SecurityTimestamp ReadTimestamp(XmlDictionaryReader reader, string digestAlgorithm, SignatureResourcePool resourcePool)
		{
			bool flag = digestAlgorithm != null && reader.CanCanonicalize;
			HashStream hashStream = null;
			reader.MoveToStartElement(XD.UtilityDictionary.Timestamp, XD.UtilityDictionary.Namespace);
			if (flag)
			{
				hashStream = resourcePool.TakeHashStream(digestAlgorithm);
				reader.StartCanonicalization(hashStream, includeComments: false, null);
			}
			string attribute = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			reader.ReadStartElement();
			reader.ReadStartElement(XD.UtilityDictionary.CreatedElement, XD.UtilityDictionary.Namespace);
			DateTime creationTimeUtc = reader.ReadContentAsDateTime().ToUniversalTime();
			reader.ReadEndElement();
			DateTime expiryTimeUtc;
			if (reader.IsStartElement(XD.UtilityDictionary.ExpiresElement, XD.UtilityDictionary.Namespace))
			{
				reader.ReadStartElement();
				expiryTimeUtc = reader.ReadContentAsDateTime().ToUniversalTime();
				reader.ReadEndElement();
			}
			else
			{
				expiryTimeUtc = SecurityUtils.MaxUtcDateTime;
			}
			reader.ReadEndElement();
			byte[] digest;
			if (flag)
			{
				reader.EndCanonicalization();
				digest = hashStream.FlushHashAndGetValue();
			}
			else
			{
				digest = null;
			}
			return new SecurityTimestamp(creationTimeUtc, expiryTimeUtc, attribute, digestAlgorithm, digest);
		}

		internal override void WriteTimestamp(XmlDictionaryWriter writer, SecurityTimestamp timestamp)
		{
			writer.WriteStartElement(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.Timestamp, XD.UtilityDictionary.Namespace);
			writer.WriteAttributeString(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, timestamp.Id);
			writer.WriteStartElement(XD.UtilityDictionary.CreatedElement, XD.UtilityDictionary.Namespace);
			char[] creationTimeChars = timestamp.GetCreationTimeChars();
			writer.WriteChars(creationTimeChars, 0, creationTimeChars.Length);
			writer.WriteEndElement();
			writer.WriteStartElement(XD.UtilityDictionary.ExpiresElement, XD.UtilityDictionary.Namespace);
			char[] expiryTimeChars = timestamp.GetExpiryTimeChars();
			writer.WriteChars(expiryTimeChars, 0, expiryTimeChars.Length);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}

		internal override void WriteTimestampCanonicalForm(Stream stream, SecurityTimestamp timestamp, byte[] workBuffer)
		{
			TimestampCanonicalFormWriter.Instance.WriteCanonicalForm(stream, timestamp.Id, timestamp.GetCreationTimeChars(), timestamp.GetExpiryTimeChars(), workBuffer);
		}
	}

	private sealed class TimestampCanonicalFormWriter : CanonicalFormWriter
	{
		private const string timestamp = "u:Timestamp";

		private const string created = "u:Created";

		private const string expires = "u:Expires";

		private const string idAttribute = "u:Id";

		private const string ns = "xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\"";

		private const string xml1 = "<u:Timestamp xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" u:Id=\"";

		private const string xml2 = "\"><u:Created>";

		private const string xml3 = "</u:Created><u:Expires>";

		private const string xml4 = "</u:Expires></u:Timestamp>";

		private readonly byte[] _fragment1;

		private readonly byte[] _fragment2;

		private readonly byte[] _fragment3;

		private readonly byte[] _fragment4;

		public static TimestampCanonicalFormWriter Instance { get; } = new TimestampCanonicalFormWriter();

		private TimestampCanonicalFormWriter()
		{
			Encoding utf8WithoutPreamble = CanonicalFormWriter.Utf8WithoutPreamble;
			_fragment1 = utf8WithoutPreamble.GetBytes("<u:Timestamp xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" u:Id=\"");
			_fragment2 = utf8WithoutPreamble.GetBytes("\"><u:Created>");
			_fragment3 = utf8WithoutPreamble.GetBytes("</u:Created><u:Expires>");
			_fragment4 = utf8WithoutPreamble.GetBytes("</u:Expires></u:Timestamp>");
		}

		public void WriteCanonicalForm(Stream stream, string id, char[] created, char[] expires, byte[] workBuffer)
		{
			stream.Write(_fragment1, 0, _fragment1.Length);
			CanonicalFormWriter.EncodeAndWrite(stream, workBuffer, id);
			stream.Write(_fragment2, 0, _fragment2.Length);
			CanonicalFormWriter.EncodeAndWrite(stream, workBuffer, created);
			stream.Write(_fragment3, 0, _fragment3.Length);
			CanonicalFormWriter.EncodeAndWrite(stream, workBuffer, expires);
			stream.Write(_fragment4, 0, _fragment4.Length);
		}
	}

	internal static readonly string[] AcceptedDateTimeFormats = new string[8] { "yyyy-MM-ddTHH:mm:ss.fffffffZ", "yyyy-MM-ddTHH:mm:ss.ffffffZ", "yyyy-MM-ddTHH:mm:ss.fffffZ", "yyyy-MM-ddTHH:mm:ss.ffffZ", "yyyy-MM-ddTHH:mm:ss.fffZ", "yyyy-MM-ddTHH:mm:ss.ffZ", "yyyy-MM-ddTHH:mm:ss.fZ", "yyyy-MM-ddTHH:mm:ssZ" };

	public static WSUtilitySpecificationVersion Default => OneDotZero;

	internal XmlDictionaryString NamespaceUri { get; }

	public static WSUtilitySpecificationVersion OneDotZero => WSUtilitySpecificationVersionOneDotZero.Instance;

	internal WSUtilitySpecificationVersion(XmlDictionaryString namespaceUri)
	{
		NamespaceUri = namespaceUri;
	}

	internal abstract bool IsReaderAtTimestamp(XmlDictionaryReader reader);

	internal abstract SecurityTimestamp ReadTimestamp(XmlDictionaryReader reader, string digestAlgorithm, SignatureResourcePool resourcePool);

	internal abstract void WriteTimestamp(XmlDictionaryWriter writer, SecurityTimestamp timestamp);

	internal abstract void WriteTimestampCanonicalForm(Stream stream, SecurityTimestamp timestamp, byte[] buffer);
}
