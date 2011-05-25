namespace AutoComplete.Common
{
    using System;

    internal class AutoCompleteSettingsDto
    {
        #region Fields

        HttpMethod httpMethod = HttpMethod.GET;

        #endregion

        #region Properties

        /// <summary>
        /// Represents the id to retrieve the input control
        /// to provide with autocomplete functionalities.
        /// </summary>
        public string ControlId { get; set; }

        /// <summary>
        /// Minimum number of chars to digit before the autocomplete is fired.
        /// </summary>
        public int MinChars { get; set; }

        /// <summary>
        /// An Uri identifying a resource returned in Json format.
        /// Not relying on automatic property allows us to resolve
        /// the ~ character in Urls.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Specifies the method to be used for the http invocation:
        /// GET or POST.
        /// If a value is not specified for this property it will
        /// default to GET.
        /// </summary>
        public HttpMethod HttpMethod
        {
            get
            {
                return this.httpMethod;
            }
            set
            {
                this.httpMethod = value;
            }
        }

        /// <summary>
        /// A javascript function to be invoked when a suggested item is selected.
        /// </summary>
        public string SelectionCallback { get; set; }

        /// <summary>
        /// A javascript function to be invoked when an error occurs during the
        /// ajax request to retrieve suggestions.
        /// </summary>
        public string ErrorCallback { get; set; }

        /// <summary>
        /// Specifies the name of a property of the returned object type.
        /// Such property will be used to fill the textbox once one of the items
        /// in the dropdownlist has been selected.
        /// If it is not specified the value in the property: 
        /// ValueField will be used in the autocomplete initialization.
        /// </summary>
        public string LabelField { get; set; }

        /// <summary>
        /// Specifies the name of a property of the returned object type.
        /// Such property will be used to display the descriptions of the items
        /// in the dropdownlist.
        /// If a LabelField property is not specified this property's value
        /// will be used as LabelField value in the autocomplete initialization.
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// Specifies if a reference to the jquery and jquery UI javascript
        /// libraries is required or they're already present in page.
        /// The versions bundled with the WebControl are:
        /// jquery 1.4.4 and jquery.ui 1.8.7
        /// Default value is false.
        /// </summary>
        public bool RegisterJQueryAndJQueryUI { get; set; }

        /// <summary>
        /// Specifies if a reference to a default autocomplete stylesheet 
        /// built with the Jquery ThemeRoller must be added to the page.
        /// If a theme has already been added to the page, setting
        /// this property is not necessary.
        /// Default value is false.
        /// </summary>
        public bool RegisterDefaultStyleSheet { get; set; }

        /// <summary>
        /// Specifies the text to be displaied in the autosuggest list when
        /// an error occurred during the ajax request.
        /// Such property will be used to display an informational message
        /// in the dropdownlist.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Specifies the text to be displaied in the autosuggest list when
        /// an the ajax request returns an empty resultset.
        /// Such property will be used to display an informational message
        /// in the dropdownlist.
        /// </summary>
        public string NoResultsMessage { get; set; }

        #endregion
    }
}
