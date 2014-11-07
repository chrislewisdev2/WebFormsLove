namespace WebFormsLove.Core.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Extension methods for mapping an <see cref="IEnumerable{ValidationAttribute}"/>
    /// to <see cref="IDictionary{TKey,TValue}"/> for use in client-side validation
    /// </summary>
    internal static class ClientValidationHelpers
    {
        /// <summary>
        /// Maps the <paramref name="attributes"/> to a dictionary of client-side validation rules
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns>a dictionary where the key is the name of the client-side validation method
        /// and the value is the param to pass to the client-side method</returns>
        public static IDictionary<string, object> ToClientSideValidationRules(this IEnumerable<ValidationAttribute> attributes)
        {
            return attributes
                .OfType<IClientSideValidator>()
                .ToDictionary(x => x.ClientSideValidationName, x => x.ClientSideComparisonValue);
        }

        /// <summary>
        /// Maps <paramref name="attributes"/> to a dictionary of client-side validation messages.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns>a dictionary where the key is the name of the client-side validation method
        /// and the value iis the message to be displayed is that validation fails</returns>
        public static IDictionary<string, string> ToClientSideValidationMessages(this IEnumerable<ValidationAttribute> attributes)
        {
            if (attributes == null) throw new ArgumentNullException("attributes");

            var msgs = attributes
                .Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage))
                .OfType<IClientSideValidator>()
                .ToDictionary(x => x.ClientSideValidationName, x => ((ValidationAttribute)x).ErrorMessage); //TODO: avoid cast here

            return msgs.Count == 0 ? null : msgs;
        }

    }
}