using System;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Content;

public class DocumentInformation
{
	private readonly string representation;

	internal static DocumentInformation Default { get; } = new DocumentInformation(null, null, null, null, null, null, null, null, null);

	public DictionaryToken? DocumentInformationDictionary { get; }

	public string? Title { get; }

	public string? Author { get; }

	public string? Subject { get; }

	public string? Keywords { get; }

	public string? Creator { get; }

	public string? Producer { get; }

	public string? CreationDate { get; }

	public string? ModifiedDate { get; }

	internal DocumentInformation(DictionaryToken? documentInformationDictionary, string? title, string? author, string? subject, string? keywords, string? creator, string? producer, string? creationDate, string? modifiedDate)
	{
		DocumentInformationDictionary = documentInformationDictionary ?? new DictionaryToken(new Dictionary<NameToken, IToken>());
		Title = title;
		Author = author;
		Subject = subject;
		Keywords = keywords;
		Creator = creator;
		Producer = producer;
		CreationDate = creationDate;
		ModifiedDate = modifiedDate;
		StringBuilder stringBuilder = new StringBuilder();
		AppendPart("Title", title, stringBuilder);
		AppendPart("Author", author, stringBuilder);
		AppendPart("Subject", subject, stringBuilder);
		AppendPart("Keywords", keywords, stringBuilder);
		AppendPart("Creator", creator, stringBuilder);
		AppendPart("Producer", producer, stringBuilder);
		AppendPart("CreationDate", creationDate, stringBuilder);
		AppendPart("ModifiedDate", modifiedDate, stringBuilder);
		representation = stringBuilder.ToString();
	}

	public DateTimeOffset? GetCreatedDateTimeOffset()
	{
		if (CreationDate == null)
		{
			return null;
		}
		if (!DateFormatHelper.TryParseDateTimeOffset(CreationDate, out var offset))
		{
			return null;
		}
		return offset;
	}

	public DateTimeOffset? GetModifiedDateTimeOffset()
	{
		if (ModifiedDate == null)
		{
			return null;
		}
		if (!DateFormatHelper.TryParseDateTimeOffset(ModifiedDate, out var offset))
		{
			return null;
		}
		return offset;
	}

	public override string ToString()
	{
		return representation;
	}

	private static void AppendPart(string name, string? value, StringBuilder builder)
	{
		if (value != null)
		{
			builder.Append(name).Append(": ").Append(value)
				.Append("; ");
		}
	}
}
