#define DEBUG
using System;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDesignerActionItem : DesignerActionMethodItem
{
	private DesignerVerb _verb;

	private string _category;

	public override string Category => _category;

	public override string Description => _verb.Description;

	public override string DisplayName => _verb.Text;

	public override bool IncludeAsDesignerVerb => false;

	public override string MemberName => null;

	public KryptonDesignerActionItem(DesignerVerb verb, string category)
		: base(null, null, null)
	{
		Debug.Assert(verb != null);
		Debug.Assert(category != null);
		if (verb == null)
		{
			throw new ArgumentNullException("verb");
		}
		if (category == null)
		{
			throw new ArgumentNullException("category");
		}
		_verb = verb;
		_category = category;
	}

	public override void Invoke()
	{
		_verb.Invoke();
	}
}
