using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;
using AutoComplete.Common;

namespace AutoComplete
{
    /// <summary>
    /// 
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:AutoCompleteTextBox JsonDataSourceUrl='' ValueField='' runat=server></{0}:AutoCompleteTextBox>")]
    public class AutoCompleteTextBox : WebControl, IPostBackDataHandler
    {
        #region Constants

        const int DefaultMinChars = 2;
        const HttpMethod DefaultHttpMethod = HttpMethod.GET;

        #endregion

        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <b>AutoCompleteTextBox</b> class. 
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the 
        /// <b>AutoCompleteTextBox</b> class.
        /// </remarks>
        public AutoCompleteTextBox()
            : base(HtmlTextWriterTag.Input) 
        {
            RegisterDefaultStyleSheet = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// The TextChanged Event.
        /// </summary>
        /// <remarks>
        /// This event is raised when the content of the <b>AutoCompleteTextBox</b> 
        /// (<see cref="AutoCompleteTextBox.Text"/>) changes between posts to the server. 
        /// </remarks>
        public event EventHandler TextChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the text displaied in the input field.
        /// </summary>
        /// <value>The text displaied in the input field.</value>
        [Bindable(true)]
        [Category("AutoComplete")]
        [DefaultValue("")]
        [Description("The value displayed in the TextBox.")]
        public string Text
        {
            get
            {
                string text = ViewState["Text"] as string;
                return text ?? String.Empty;
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// Minimum number of chars to digit before the autocomplete is fired.
        /// </summary>
        [Category("AutoComplete")]
        [DefaultValue(2)]
        [Description("The minimum number of chars to digit to fire autocomplete.")]
        public int MinCharsRequired
        {
            get
            {
                if (ViewState["MinCharsRequired"] == null)
                {
                    return DefaultMinChars;
                }
                int minCharsRequired = (int)ViewState["MinCharsRequired"];
                return minCharsRequired;
            }
            set
            {
                ViewState["MinCharsRequired"] = value;
            }
        }
        
        /// <summary>
        /// An Uri identifying a resource returned in Json format.
        /// Not relying on automatic property allows us to resolve
        /// the ~ character in Urls.
        /// </summary>
        [UrlProperty()]
        [Category("AutoComplete")]
        [Description("The url to retrieve the source data from.")]
        public Uri JsonDataSourceUrl
        {
            get
            {
                string targetUrl = ViewState["JsonDataSourceUrl"] as string;
                return (targetUrl == null) ? null : new Uri(targetUrl, UriKind.RelativeOrAbsolute);
            }
            set
            {
                ViewState["JsonDataSourceUrl"] = ResolveUrl(value.ToString());
            }
        }

        /// <summary>
        /// Specifies the method to be used for the http invocation:
        /// GET or POST.
        /// If a value is not specified for this property it will
        /// default to GET.
        /// </summary>
        [Category("AutoComplete")]
        [Description("The http method (GET/POST) to use for the remote request.")]
        public HttpMethod HttpMethod 
        {
            get
            {
                if (ViewState["HttpMethod"] == null)
                {
                    return DefaultHttpMethod;
                }
                HttpMethod httpMethod = (HttpMethod)ViewState["HttpMethod"];
                return httpMethod;
            }
            set
            {
                ViewState["HttpMethod"] = value;
            }
        }

        /// <summary>
        /// A javascript function to be invoked when a suggested item is selected.
        /// </summary>
        [Category("AutoComplete")]
        [Description("A Javascript function to execute when an item is selected.")]
        public string OnClientSelection { get; set; }

        /// <summary>
        /// A javascript function to be invoked when an error occurs during the
        /// ajax request to retrieve suggestions.
        /// </summary>
        [Category("AutoComplete")]
        [Description("A Javascript function to execute when an error occurs during the ajax request.")]
        public string OnClientError { get; set; }

        /// <summary>
        /// Specifies the name of a property of the returned object type.
        /// Such property will be used to fill the textbox once one of the items
        /// in the dropdownlist has been selected.
        /// If it is not specified the value in the property: 
        /// ValueField will be used in the autocomplete initialization.
        /// </summary>
        [Category("AutoComplete")]
        [Description("The property of the object returned, to be displaied in the list.")]
        public string LabelField { get; set; }

        /// <summary>
        /// Specifies the name of a property of the returned object type.
        /// Such property will be used to display the descriptions of the items
        /// in the dropdownlist.
        /// If a LabelField property is not specified this property's value
        /// will be used as LabelField value in the autocomplete initialization.
        /// </summary>
        [Category("AutoComplete")]
        [Description("The property of the object selected, to be displaied in the textbox.")]
        public string ValueField { get; set; }

        /// <summary>
        /// Specifies if a reference to the jquery and jquery UI javascript
        /// libraries is required or they're already present in page.
        /// The versions bundled with the WebControl are:
        /// jquery 1.4.4 and jquery.ui 1.8.7
        /// Default value is false.
        /// </summary>
        [Category("AutoComplete")]
        [Description("Instructs the control wether to emit script tags to include a reference to jquery.js and jquery-ui.js.")]
        public bool RegisterJQueryAndJQueryUI { get; set; }

        /// <summary>
        /// Specifies if a reference to a default autocomplete stylesheet 
        /// built with the Jquery ThemeRoller must be added to the page.
        /// If a theme has already been added to the page, setting
        /// this property is not necessary.
        /// Default value is true.
        /// </summary>
        [Category("AutoComplete")]
        [Description("Instructs the control wether to emit a link to the stylesheet for the autocomplete dropdownlist.")]
        public bool RegisterDefaultStyleSheet { get; set; }

        /// <summary>
        /// Specifies the text to be displaied in the autosuggest list when
        /// an error occurred during the ajax request.
        /// Such property will be used to display an informational message
        /// in the dropdownlist.
        /// </summary>
        [Category("AutoComplete")]
        [Description("An informational message, to be displaied in the autosuggest list in case of error.")]
        public string ErrorMessage { get; set; }
                
        /// <summary>
        /// Specifies the text to be displaied in the autosuggest list when
        /// an the ajax request returns an empty resultset.
        /// Such property will be used to display an informational message
        /// in the dropdownlist.
        /// </summary>
        [Category("AutoComplete")]
        [Description("An informational message, to be displaied in the autosuggest list in case of emptry resultset.")]
        public string NoResultsMessage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Processes postback data for the AutoCompleteTextBox control.
        /// </summary>
        /// <param name="postCollection">
        /// NameValueCollection that indicates the collection posted to the server.
        /// </param>
        /// <param name="postDataKey">
        /// String that indicates the index within the posted collection that 
        /// references the content to load.
        /// </param>
        /// <returns>
        /// true if the server control's state changes 
        /// as a result of the postback; otherwise, false.
        /// </returns>
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            if (Enabled)
            {
                try
                {
                    string previousText = this.Text;
                    Text = postCollection[postDataKey];

                    bool isTextChanged = (previousText != Text);
                    return isTextChanged;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Signals the server control to notify the ASP.NET application 
        /// when the state of the AutoCompleteTextBox control has changed.
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            if (TextChanged != null)
            {
                TextChanged(this, EventArgs.Empty); // Fire Event
            }
        }

        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered
        /// to the specified <see cref="T:System.Web.UI.HtmlTextWriterTag"/>. 
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> 
        /// that represents the output stream to render HTML content on the client.
        /// </param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, Text);
        }

        /// <summary>
        /// Ensures that properties required for the correct behavior of the control
        /// are correctly set.
        /// In case a required property is not set an exception is raised.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> 
        /// object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            const string defaultMessage = "A value must be provided for the specified property.";
            base.OnInit(e);
            if ((JsonDataSourceUrl == null) || 
                string.IsNullOrEmpty(JsonDataSourceUrl.OriginalString))
            {
                throw new Exception("Required property: JsonDataSourceUrl for: " + ID + Environment.NewLine + defaultMessage);
            }
            if (string.IsNullOrEmpty(ValueField))
            {
                throw new Exception("Required property: ValueField for: " + ID + Environment.NewLine + defaultMessage);
            }
        }

        /// <summary>
        /// Raises the PreRender event.
        /// </summary>
        /// <param name="e">
        /// An EventArgs object that contains the event data. 
        /// </param>
        /// <remarks>
        /// <para>
        /// This method notifies the server control to perform any necessary prerendering 
        /// steps prior to saving view state and rendering content.
        /// Registers client side dynamic scripts for the Picker control.
        /// Page code behind should not change Picker.PickerFormat after PreRender (e.g. PrerenderComplete)
        /// ClientScript validation would hold different format than Picker.Value .
        /// </para>
        /// <para>
        /// ClientScript registration is made here because is the last useful life cycle phase to register
        /// client script resources. Array declaration is made here too to not duplicate the 
        /// ClientScriptManager object declaration.
        /// </para>
        /// <para>
        /// Array declaration is made in Picker instead of the adapter because m_Format.Months is not 
        /// visible for protection level and we don't want to make it visible.
        /// Besides, array name is made unambiguous in case of different instances of Picker have 
        /// different formats (LongMonthdate, ShortMonthDate).
        /// </para>
        /// </remarks>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            const string clientScriptPath = "AutoComplete.Scripts.IM.AutoComplete.js";
            const string jqueryScriptPath = "AutoComplete.Scripts.jquery.js";
            const string jqueryUIScriptPath = "AutoComplete.Scripts.jquery-ui.js";
            if (Enabled)
            {
                ClientScriptManager clientScriptManager = Page.ClientScript;
                clientScriptManager.RegisterClientScriptResource(GetType(), clientScriptPath);

                if (RegisterJQueryAndJQueryUI)
                {
                    clientScriptManager.RegisterClientScriptResource(GetType(), jqueryScriptPath);
                    clientScriptManager.RegisterClientScriptResource(GetType(), jqueryUIScriptPath);
                }
                if (RegisterDefaultStyleSheet)
                {
                    AddDefaultStyleSheet();
                }

                AutoCompleteSettingsDto settings = AutoCompleteSettingsMapper.GetDtoFrom(this);
                string initializeAutoComplete = AutoCompleteInitializer.GetJsInitialization(settings);
                Type controlType = GetType();
                string scriptName = "autoComplete" + ClientID;
                if (!clientScriptManager.IsStartupScriptRegistered(controlType, scriptName))
                {
                    clientScriptManager.RegisterStartupScript(controlType, scriptName, initializeAutoComplete, true);
                }
            }
        }

        /// <summary>
        /// Adds a ThemeRoller default stylesheet to the page header 
        /// if none has been added yet.
        /// The stylesheet is added only if the header controlcollection
        /// is not readonly. Such control has been added in order to avoid 
        /// the exception:
        /// [HttpException (0x80004005): The Controls collection cannot be 
        /// modified because the control contains code blocks (i.e. <% ... %>).],
        /// when inline code blocks exist in the page header. 
        /// <remarks>When using code blocks inside the header the style must
        /// be explicitly set in the page as in the following snippet:
        /// <![CDATA[
        /// <link href="/Style/AutoComplete/jquery-ui.css"
        ///       rel="stylesheet" 
        ///       type="text/css" />
        /// ]]>
        /// and the file: jquery-ui.css, available with the download, must be
        /// placed in the folder specified in the href attribute.
        /// </remarks>
        /// </summary>
        private void AddDefaultStyleSheet()
        {
            const string jqueryUICssPath = "AutoComplete.Style.jquery-ui.css";
            if (Page.Header != null &&
                !Page.Header.Controls.IsReadOnly &&
                Page.Header.FindControl("AutoCompleteStyle") == null)
            {
                HtmlLink autoCompleteStyle = new HtmlLink();
                autoCompleteStyle.ID = "AutoCompleteStyle";
                autoCompleteStyle.Href = Page.ClientScript.GetWebResourceUrl(GetType(), jqueryUICssPath);
                autoCompleteStyle.Attributes.Add("rel", "stylesheet");
                autoCompleteStyle.Attributes.Add("type", "text/css");
                Page.Header.Controls.Add(autoCompleteStyle);
            }
        }

        #endregion
    }
}