namespace WebFormsLove.Core.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.DynamicData;
    using System.Web.UI;

    /// <summary>
    /// Provides a link between ValidationAttributes, some input control and the model
    /// </summary>
    public class MetadataSource : Control
    {
        /// <summary>
        /// Gets or sets the type of the object to reflect on
        /// </summary>
        /// <value>The type of the object.</value>
        public string ObjectType { get; set; }

        private MetaTable _metaTable;
        private MetaTable MetaTable
        {
            get { return _metaTable ?? (_metaTable = System.Web.DynamicData.MetaTable.CreateTable(Type.GetType(ObjectType))); }
        }

        /// <summary>
        /// Gets the validation attributes for the type specified in <see cref="MetadataSource.ObjectType"/>
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public IEnumerable<ValidationAttribute> GetValidationAttributes(string property)
        {
            return MetaTable.GetColumn(property).Attributes.OfType<ValidationAttribute>();
        }

        /// <summary>
        /// Gets the display name for the specified <paramref name="objectProperty"/>
        /// </summary>
        /// <param name="objectProperty">The object property.</param>
        /// <returns></returns>
        public string GetDisplayName(string objectProperty)
        {
            var displayAttribute = MetaTable.GetColumn(objectProperty)
                .Attributes.OfType<DisplayAttribute>()
                .FirstOrDefault();

            return displayAttribute == null ? objectProperty : displayAttribute.GetName();
        }
    }
}