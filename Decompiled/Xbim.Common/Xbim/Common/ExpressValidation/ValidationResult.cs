using System.Collections.Generic;
using Xbim.Common.Enumerations;

namespace Xbim.Common.ExpressValidation;

public class ValidationResult
{
	public IPersist Item;

	public ValidationFlags IssueType;

	public string IssueSource;

	public string Message;

	private List<ValidationResult> _details;

	public ValidationResult Context;

	public IEnumerable<ValidationResult> Details
	{
		get
		{
			EnsureDetails();
			return _details;
		}
	}

	public void AddDetail(ValidationResult detail)
	{
		detail.Context = this;
		EnsureDetails();
		IssueType |= detail.IssueType;
		_details.Add(detail);
	}

	private void EnsureDetails()
	{
		if (_details == null)
		{
			_details = new List<ValidationResult>();
		}
	}

	public string Report()
	{
		return $"Issue of type {IssueType} on {IssueSource}.";
	}
}
