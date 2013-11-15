namespace WebFormsLove.Core.Validation
{
    /// <summary>
    /// Interface for validation attributes which wish to be used for client-side validation
    /// </summary>
    public interface IClientSideValidator
    {
        /// <summary>
        /// Gets the client side comparison value.
        /// </summary>
        /// <value>The client side comparison value.</value>
        object ClientSideComparisonValue { get; }

        /// <summary>
        /// Gets the name of the client side validation method.
        /// </summary>
        /// <value>The name of the client side validation method.</value>
        string ClientSideValidationName { get; }
    }
}
