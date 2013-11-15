namespace WebFormsLove.Core.Validation
{
    /// <summary>
    /// Wrapper around <see cref="System.ComponentModel.DataAnnotations.RegularExpressionAttribute"/>
    /// to enable client-side validation
    /// </summary>
    public class RegularExpressionAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute, IClientSideValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegularExpressionAttribute"/> class.
        /// </summary>
        /// <param name="pattern">The regular expression that is used to validate the data field value.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="pattern"/> is null.</exception>
        public RegularExpressionAttribute(string pattern)
            : base(pattern)
        {
        }

        #region Implementation of IClientSideValidator

        /// <summary>
        /// Gets the client side comparison value.
        /// </summary>
        /// <value>The client side comparison value.</value>
        public object ClientSideComparisonValue
        {
            get { return Pattern; }
        }

        /// <summary>
        /// Gets the name of the client side validation method.
        /// </summary>
        /// <value>The name of the client side validation.</value>
        public string ClientSideValidationName
        {
            get { return "regex"; }
        }


        #endregion
    }
}
