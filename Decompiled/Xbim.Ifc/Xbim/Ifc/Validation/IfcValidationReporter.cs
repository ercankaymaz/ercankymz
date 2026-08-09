using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common.ExpressValidation;

namespace Xbim.Ifc.Validation;

public class IfcValidationReporter : IEnumerable<string>, IEnumerable
{
	private readonly Stack<IEnumerator<ValidationResult>> _queue = new Stack<IEnumerator<ValidationResult>>();

	private IEnumerator<ValidationResult> _currentEnum;

	private int _indent;

	public IfcValidationReporter(IEnumerable<ValidationResult> results)
	{
		_currentEnum = results.GetEnumerator();
	}

	public IEnumerator<string> GetEnumerator()
	{
		while (true)
		{
			if (_currentEnum.MoveNext())
			{
				string text = _currentEnum.Current.Message;
				if (string.IsNullOrEmpty(text))
				{
					text = _currentEnum.Current.Report();
				}
				yield return new string('\t', _indent) + text;
				if (_currentEnum.Current.Details.Any())
				{
					_queue.Push(_currentEnum);
					_currentEnum = _currentEnum.Current.Details.GetEnumerator();
					_indent++;
				}
			}
			else
			{
				if (!_queue.Any())
				{
					break;
				}
				_currentEnum = _queue.Pop();
				_indent--;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
