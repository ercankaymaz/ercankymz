using System;

namespace PdfSharp.Pdf;

public sealed class PdfDocumentInformation : PdfDictionary
{
	internal sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string Title = "/Title";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string Author = "/Author";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string Subject = "/Subject";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string Keywords = "/Keywords";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string Creator = "/Creator";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string Producer = "/Producer";

		[KeyInfo(KeyType.Date | KeyType.Optional)]
		public const string CreationDate = "/CreationDate";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string ModDate = "/ModDate";

		[KeyInfo("1.3", KeyType.Name | KeyType.Optional)]
		public const string Trapped = "/Trapped";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public string Title
	{
		get
		{
			return base.Elements.GetString("/Title");
		}
		set
		{
			base.Elements.SetString("/Title", value);
		}
	}

	public string Author
	{
		get
		{
			return base.Elements.GetString("/Author");
		}
		set
		{
			base.Elements.SetString("/Author", value);
		}
	}

	public string Subject
	{
		get
		{
			return base.Elements.GetString("/Subject");
		}
		set
		{
			base.Elements.SetString("/Subject", value);
		}
	}

	public string Keywords
	{
		get
		{
			return base.Elements.GetString("/Keywords");
		}
		set
		{
			base.Elements.SetString("/Keywords", value);
		}
	}

	public string Creator
	{
		get
		{
			return base.Elements.GetString("/Creator");
		}
		set
		{
			base.Elements.SetString("/Creator", value);
		}
	}

	public string Producer => base.Elements.GetString("/Producer");

	public DateTime CreationDate
	{
		get
		{
			return base.Elements.GetDateTime("/CreationDate", DateTime.MinValue);
		}
		set
		{
			base.Elements.SetDateTime("/CreationDate", value);
		}
	}

	public DateTime ModificationDate
	{
		get
		{
			return base.Elements.GetDateTime("/ModDate", DateTime.MinValue);
		}
		set
		{
			base.Elements.SetDateTime("/ModDate", value);
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfDocumentInformation(PdfDocument document)
		: base(document)
	{
	}

	internal PdfDocumentInformation(PdfDictionary dict)
		: base(dict)
	{
	}
}
