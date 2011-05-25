using System;
namespace AutoComplete.Common
{

    internal class AutoCompleteSettingsMapper
    {
        /// <summary>
        /// Creates a Dto representing the settings to use to initialize
        /// the autocomplete functionalities for a textbox.
        /// It initializes the dto from an instance of 
        /// <see cref="AutoCompleteTextBox"/>.
        /// </summary>
        /// <param name="autoCompleteTextBox">The <see cref="AutoCompleteTextBox"/>
        /// instance to use to initialize the Dto instance.</param>
        /// <returns>A Dto representing the settings to initialize
        /// an autocomplete control.</returns>
        internal static AutoCompleteSettingsDto GetDtoFrom(AutoCompleteTextBox autoCompleteTextBox)
        {
            AutoCompleteSettingsDto settings = new AutoCompleteSettingsDto();
            settings.ControlId = autoCompleteTextBox.ClientID;
            settings.Url = autoCompleteTextBox.JsonDataSourceUrl;
            settings.HttpMethod = autoCompleteTextBox.HttpMethod;
            settings.MinChars = autoCompleteTextBox.MinCharsRequired;
            settings.LabelField = autoCompleteTextBox.LabelField;
            settings.ValueField = autoCompleteTextBox.ValueField;
            settings.SelectionCallback = autoCompleteTextBox.OnClientSelection;
            settings.ErrorCallback = autoCompleteTextBox.OnClientError;
            settings.ErrorMessage = autoCompleteTextBox.ErrorMessage;
            settings.NoResultsMessage = autoCompleteTextBox.NoResultsMessage;
            return settings;
        }

        /// <summary>
        /// Creates a Dto representing the settings to use to initialize
        /// the autocomplete functionalities for a textbox.
        /// It initializes the dto from an instance of 
        /// <see cref="AutoCompleteTextBox"/>.
        /// </summary>
        /// <param name="controlId">The id of the input textbox to which add
        /// autocomplete functionalities.</param>
        /// <param name="url">The URL.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="minChars">The min chars.</param>
        /// <param name="labelField">The label field.</param>
        /// <param name="valueField">The value field.</param>
        /// <param name="selectionCallback">The selection callback.</param>
        /// <param name="errorCallback">The error callback.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="noResultsMessage">The no results message.</param>
        /// <returns>A Dto representing the settings to initialize
        /// an autocomplete control.</returns>
        internal static AutoCompleteSettingsDto GetDtoFrom(string controlId,
                                                           Uri url,
                                                           HttpMethod httpMethod,
                                                           int minChars,
                                                           string labelField,
                                                           string valueField,
                                                           string selectionCallback,
                                                           string errorCallback,
                                                           string errorMessage,
                                                           string noResultsMessage)
        {
            AutoCompleteSettingsDto settings = new AutoCompleteSettingsDto();
            settings.ControlId = controlId;
            settings.Url = url;
            settings.HttpMethod = httpMethod;
            settings.MinChars = minChars;
            settings.LabelField = labelField;
            settings.ValueField = valueField;
            settings.SelectionCallback = selectionCallback;
            settings.ErrorCallback = errorCallback;
            settings.ErrorMessage = errorMessage;
            settings.NoResultsMessage = noResultsMessage;
            return settings;
        }
    }
}
