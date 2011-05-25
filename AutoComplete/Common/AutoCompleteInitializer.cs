namespace AutoComplete.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains helper methods providing common functionalities
    /// to ASP.NET and ASP.NET MVC components.
    /// </summary>
    internal static class AutoCompleteInitializer
    {
        /// <summary>
        /// Gets a string containing the invocation of the InitializeAutocomplete
        /// javascript method used to provide autocomplete functionalities
        /// to a specified input control.
        /// The parameters passed to the function is built starting from
        /// the settings passed as argument to this method.
        /// </summary>
        /// <param name="settings">The settings to use to initialize autocomplete
        /// functionalities on the control whose id is specified in the settings
        /// themselves.</param>
        /// <returns>A string containing the correct invocation of the javascript
        /// method initializing autocomplete.</returns>
        internal static string GetJsInitialization(AutoCompleteSettingsDto settings)
        {
            string errorMessage = string.IsNullOrEmpty(settings.ErrorMessage) ? "null" : string.Format("'{0}'", settings.ErrorMessage);
            string noResultsMessage = string.IsNullOrEmpty(settings.NoResultsMessage) ? "null" : string.Format("'{0}'", settings.NoResultsMessage);

            const string initializeAutoCompleteFormat = @"
if (typeof InitializeAutocomplete == 'undefined') {{
     // IM.AutoComplete.js is not loaded
     alert('AutoComplete functionality is not loaded');
}}
else {{
    InitializeAutocomplete({{Id: '{0}',
                            Url: '{1}',
                            HttpMethod: '{2}',
                            MinChars: {3},
                            LabelField: '{4}',
                            ValueField: '{5}',
                            SelectionCallback: {6},
                            NoResultsMessage: {7},
                            ErrorCallback: {8},                        
                            ErrorMessage: {9}}}
                         );
}}
";
            string initializeAutoComplete = string.Format(initializeAutoCompleteFormat,
                                                          settings.ControlId,
                                                          settings.Url,
                                                          settings.HttpMethod,
                                                          settings.MinChars,
                                                          settings.LabelField ?? settings.ValueField,
                                                          settings.ValueField,
                                                          string.IsNullOrEmpty(settings.SelectionCallback) ? "null" : settings.SelectionCallback,
                                                          noResultsMessage,
                                                          string.IsNullOrEmpty(settings.ErrorCallback) ? "null" : settings.ErrorCallback,
                                                          errorMessage
                                                          );
            return initializeAutoComplete;
        }
    }
}
