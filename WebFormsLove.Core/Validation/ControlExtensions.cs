namespace WebFormsLove.Core.Validation
{
    using System;
    using System.Web.UI;

    /// <summary>
    /// A collection of helper methods for dealing with controls
    /// </summary>
    internal static class ControlExtensions
    {
        /// <summary>
        /// Recursively searches for desired control
        /// </summary>
        /// <typeparam name="T">the type of control we're searching for</typeparam>
        /// <param name="startingControl">The starting control.</param>
        /// <param name="targetId">The Id of the target control.</param>
        /// <returns></returns>
        /// <remarks>Assumes that startingControl is NOT the control you are searching for. </remarks>
        public static T FindChildControl<T>(this Control startingControl, string targetId)
            where T : Control
        {
            if (startingControl == null) throw new ArgumentNullException("startingControl");

            Control currentContainer = startingControl;
            Control found = null;

            if (startingControl == startingControl.Page)
            {
                return (T)startingControl.FindControl(targetId);
            }

            while (found == null && currentContainer != startingControl.Page)
            {
                currentContainer = currentContainer.NamingContainer;
                if (currentContainer == null)
                {
                    throw new ArgumentException(string.Format("Naming container was not found for {0}", startingControl.GetType().Name));
                }
                // CodeReview: SJH 29/08/12: Why not return here?
                found = currentContainer.FindControl(targetId);
            }

            return (T)found;
        }

    }
}