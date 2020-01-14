namespace NET.W._2019.Titkov._19
{
    /// <summary>
    /// Provides methods to validate data in string format.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates data in string format.
        /// </summary>
        /// <param name="value">String to validate.</param>
        /// <returns>True if data is valid, otherwise false.</returns>
        bool IsValid(string value);
    }
}
