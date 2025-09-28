namespace GeneralDotNetSourceGenerators.Abstractions.AutoRegistration.AcrossCompilation
{
	/// <summary>
	///   Apply this interface to a class to enable being registered.
	/// </summary>
	public interface IRegistrant
	{
		/// <summary>
		///  Implements behaviour  to initialize the registration of this class to the appropriate registry.
		/// </summary>
		void Register();
	}
}