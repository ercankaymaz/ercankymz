using System;
using System.ComponentModel;
using System.IO;
using Xbim.Common.Metadata;
using Xbim.IO.Step21;

namespace Xbim.Common;

public abstract class PersistEntity : IPersistEntity, IPersist, INotifyPropertyChanged
{
	protected internal bool _activated;

	public int EntityLabel { get; private set; }

	public IModel Model { get; private set; }

	[Obsolete("This property is deprecated and likely to be removed. Use just 'Model' instead.")]
	public IModel ModelOf => Model;

	bool IPersistEntity.Activated => _activated;

	ExpressType IPersistEntity.ExpressType => Model.Metadata.ExpressType(this);

	public event PropertyChangedEventHandler PropertyChanged;

	protected PersistEntity(IModel model, int label, bool activated)
	{
		Model = model;
		EntityLabel = label;
		_activated = activated;
	}

	protected void Activate()
	{
		if (!_activated)
		{
			Model.Activate(this);
		}
	}

	public abstract void Parse(int propIndex, IPropertyValue value, int[] nested);

	protected void NotifyPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	protected void SetValue<TProperty>(Action<TProperty> setter, TProperty oldValue, TProperty newValue, string notifyPropertyName, int propertyOrder)
	{
		if (!_activated)
		{
			Activate();
		}
		if (!Model.IsTransactional)
		{
			setter(newValue);
			NotifyPropertyChanged(notifyPropertyName);
		}
		else
		{
			(Model.CurrentTransaction ?? throw new Exception("Operation out of transaction.")).DoReversibleAction(doAction, undoAction, this, ChangeType.Modified, propertyOrder);
		}
		void doAction()
		{
			setter(newValue);
			NotifyPropertyChanged(notifyPropertyName);
		}
		void undoAction()
		{
			setter(oldValue);
			NotifyPropertyChanged(notifyPropertyName);
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!(obj is IPersistEntity persistEntity))
		{
			return false;
		}
		if (EntityLabel.Equals(persistEntity.EntityLabel))
		{
			return Model.Equals(persistEntity.Model);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return EntityLabel.GetHashCode();
	}

	public static bool operator ==(PersistEntity left, object right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left == null || right == null)
		{
			return false;
		}
		if (!(right is IPersistEntity persistEntity))
		{
			return false;
		}
		if (left.EntityLabel == persistEntity.EntityLabel)
		{
			return left.Model.Equals(persistEntity.Model);
		}
		return false;
	}

	public static bool operator !=(PersistEntity left, object right)
	{
		return !(left == right);
	}

	public override string ToString()
	{
		ExpressMetaData expressMetaData = null;
		expressMetaData = ((Model == null) ? ExpressMetaData.GetMetadata(GetType().Module) : Model.Metadata);
		using StringWriter stringWriter = new StringWriter();
		Part21Writer.WriteEntity(this, stringWriter, expressMetaData);
		return stringWriter.ToString();
	}
}
