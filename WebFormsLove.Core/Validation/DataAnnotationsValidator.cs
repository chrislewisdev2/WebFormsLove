namespace WebFormsLove.Core.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Newtonsoft.Json;

    /// <summary>
    /// Validation control that makes use of DataAnnotations to provide a clean validation model.
    /// Also, outputs data-* attributes on the control to validate to hook up client-side validation
    /// </summary>
    /// <remarks>see http://amanek.com/building-data-annotations-validator-control-with-client-side-validation/</remarks>
    public class DataAnnotationsValidator : BaseValidator
    {
        private const string MetadataSourceViewStateKey = "DataAnnotationsValidator_MetadataSourceID";

        private MetadataSource _metadataSource;
        private IEnumerable<ValidationAttribute> _validationAttributes;
        private string _displayName;

        /// <summary>
        /// Gets or sets the metadata source id.
        /// </summary>
        /// <value>The metadata source id.</value>
        [Category("Behavior")]
        [Themeable(false)]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(MetadataSource))]
        public string MetadataSourceId
        {
            get
            {
                return (string)ViewState[MetadataSourceViewStateKey];
            }
            set
            {
                ViewState[MetadataSourceViewStateKey] = value;
            }
        }


        /// <summary>
        /// The property on the model that we will validate against
        /// </summary>
        /// <value>The object property.</value>
        [Category("Behavior")]
        [Themeable(false)]
        [DefaultValue("")]
        public string ObjectProperty { get; set; }

        private Control _targetControl;
        /// <summary>
        /// Gets the target control.
        /// </summary>
        /// <value>The target control.</value>
        protected Control TargetControl
        {
            get { return _targetControl ?? (_targetControl = NamingContainer.FindControl(ControlToValidate)); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAnnotationsValidator"/> class.
        /// </summary>
        public DataAnnotationsValidator()
        {
            //set some sensible defaults
            base.CssClass = "error";
            Display = ValidatorDisplay.Dynamic;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!ControlPropertiesValid()) return;

            _metadataSource = this.FindChildControl<MetadataSource>(MetadataSourceId);
            _validationAttributes = _metadataSource.GetValidationAttributes(ObjectProperty);
            _displayName = _metadataSource.GetDisplayName(ObjectProperty);

            DecorateTarget();
        }

        /// <summary>
        /// Adds neccesary HTML attributes to the control referred to by 
        /// <see cref="TargetControl"/> to trigger client-side validation
        /// </summary>
        protected void DecorateTarget()
        {
            var target = TargetControl as IAttributeAccessor;
            if (target == null) return;

            var rules = _validationAttributes.ToClientSideValidationRules();
            var msgs = _validationAttributes.ToClientSideValidationMessages();

            target.SetAttribute("data-val", "true");
            target.SetAttribute("data-val-rules", JsonConvert.SerializeObject(rules, Formatting.None));
            target.SetAttribute("data-val-messages", JsonConvert.SerializeObject(msgs, Formatting.None));
        }


        #region Overrides of BaseValidator

        /// <summary>
        /// determines whether the value in the input control is valid.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the value in the input control is valid; otherwise, <c>false</c>.
        /// </returns>
        protected override bool EvaluateIsValid()
        {
            object value = GetControlValidationValue(ControlToValidate);

            foreach (var validationAttribute in _validationAttributes)
            {
                // Here, we will try to convert value to type specified on RangeAttibute.
                // RangeAttribute.OperandType should be either IConvertible or of built in primitive types
                var rangeAttribute = validationAttribute as RangeAttribute;
                if (rangeAttribute != null)
                {
                    value = Convert.ChangeType(value, rangeAttribute.OperandType);
                }

                if (validationAttribute.IsValid(value)) continue;

                ErrorMessage = validationAttribute.FormatErrorMessage(_displayName);
                return false;
            }

            return true;
        }


        /// <summary>
        /// Gets the HTML tag that is used to render the <see cref="T:System.Web.UI.WebControls.Label"/> control.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value used to render the <see cref="T:System.Web.UI.WebControls.Label"/>.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Label; }
        }

        /// <summary>
        /// Adds the HTML attributes and styles that need to be rendered for the control to the specified <see cref="T:System.Web.UI.HtmlTextWriter"/> object.
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");
            base.AddAttributesToRender(writer);

            writer.AddAttribute(HtmlTextWriterAttribute.For, TargetControl.ClientID);
        }

        #endregion
    }
}
