using NerdStore.Core.Interfaces;

namespace NerdStore.Core.Settings
{
	public abstract class Settings : ISettings
	{
		public override string ToString()
			=> GetType().Name;
	}
}
