using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.Type1.CharStrings;

namespace UglyToad.PdfPig.Fonts.Type1;

public class Type1PrivateDictionary : AdobeStylePrivateDictionary
{
	internal class Builder : BaseBuilder
	{
		public object Rd { get; set; }

		public object NoAccessPut { get; set; }

		public object NoAccessDef { get; set; }

		public IReadOnlyList<Type1CharstringDecryptedBytes> Subroutines { get; set; }

		public object[] OtherSubroutines { get; set; }

		public int? UniqueId { get; set; }

		public int? Password { get; set; }

		public int LenIv { get; set; }

		public MinFeature MinFeature { get; set; }

		public bool? RoundStemUp { get; set; }

		public Type1PrivateDictionary Build()
		{
			return new Type1PrivateDictionary(this);
		}
	}

	public int? UniqueId { get; set; }

	public int LenIv { get; }

	public bool? RoundStemUp { get; }

	public int Password { get; } = 5839;

	public MinFeature MinFeature { get; } = new MinFeature(16, 16);

	internal Type1PrivateDictionary(Builder builder)
		: base(builder)
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		UniqueId = builder.UniqueId;
		RoundStemUp = builder.RoundStemUp;
		LenIv = builder.LenIv;
		if (builder.Password.HasValue)
		{
			Password = builder.Password.Value;
		}
	}
}
