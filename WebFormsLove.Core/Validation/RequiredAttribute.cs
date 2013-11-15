namespace WebFormsLove.Core.Validation
{
    /// <summary>
    /// Wrapper around <see cref="System.ComponentModel.DataAnnotations.RequiredAttribute"/>
    /// to enable client-side validation
    /// </summary>
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute, IClientSideValidator
    {
        #region Implementation of IClientSideValidator

        /// <summary>
        /// Gets the client side comparison value.
        /// </summary>
        /// <value>The client side comparison value.</value>
        public object ClientSideComparisonValue
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the name of the client side validation method.
        /// </summary>
        /// <value>The name of the client side validation method.</value>
        public string ClientSideValidationName
        {
            get { return "required"; }
        }

        #endregion
    }
}