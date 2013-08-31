namespace AngryGroceries.Specs.Util
{
    public interface IBrowserScenario
    {
        /// <summary>
        /// Gets the navigator for getting around the application
        /// </summary>
        Navigator Navigator { get; }
    }
}