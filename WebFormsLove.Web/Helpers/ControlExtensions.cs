using System;

namespace WebFormsLove.Helpers
{
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public static class ControlExtensions
    {
        /// <summary>
        /// Finds the <see cref="System.Web.UI.Control"/> with the specified <paramref name="id"/> 
        /// and casts to the desired type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> to search within</param>
        /// <param name="id">The id. of the <see cref="System.Web.UI.Control"/> to find</param>
        /// <returns><c>true</c> if the tc was found, <c>false</c> otherwise</returns>
        public static T FindControl<T>(this Control control, string id) where T : Control
        {
            if (id == null) throw new ArgumentNullException("id");

            return control.FindControl(id) as T;
        }

        /// <summary>
        /// Finds a <see cref="System.Web.UI.Control"/> with the specified <paramref name="id"/>, and of type <typeparamref name="TControl"/> within <paramref name="control"/>.
        /// If a <see cref="System.Web.UI.Control"/> is found, the supplied <paramref name="action"/> is executed against it.
        /// </summary>
        /// <typeparam name="TControl">The type of <see cref="System.Web.UI.Control"/> that we're searching for</typeparam>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> we're searching within.</param>
        /// <param name="id">ID of the we're looking for.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>If found, returns the <see cref="System.Web.UI.Control"/> with ID <paramref name="id"/> of type <typeparamref name="TControl"/>, 
        /// returns <c>null</c> otherwise </returns>
        public static TControl FindBind<TControl>(this Control control, string id, Action<TControl> action)
            where TControl : Control
        {
            var target = control.FindControl(id) as TControl;
            if (target != null)
            {
                action(target);
            }

            return target;
        }

        /// <summary>
        /// Adds the supplied class to the given control
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="cssClass">The CSS class.</param>
        public static void AddClass(this WebControl control, string cssClass)
        {
            AddClass(control.Attributes, cssClass);
        }

        /// <summary>
        /// Adds the supplied class to the given control
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="cssClass">The CSS class.</param>
        public static void AddClass(this HtmlControl control, string cssClass)
        {
            AddClass(control.Attributes, cssClass);
        }

        /// <summary>
        /// Adds the supplied class to the given attributes
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="cssClass">The CSS class name.</param>
        public static void AddClass(AttributeCollection attributes, string cssClass)
        {
            const string cssClassKey = "class";

            if (cssClass == null) return;

            string current = attributes[cssClassKey] ?? string.Empty;
            current = current.Trim();

            //already has a class set, so append supplied class
            if (!string.IsNullOrWhiteSpace(current))
            {
                cssClass = current + " " + cssClass.Trim();
            }

            attributes[cssClassKey] = cssClass;
        }
    }
}