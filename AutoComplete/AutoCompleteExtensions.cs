namespace AutoComplete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using AutoComplete.Common;
    using System.Linq.Expressions;

    public static class AutoCompleteExtensions
    {
        #region Constants

        const int DefaultMinChars = 2;
        const HttpMethod DefaultHttpMethod = HttpMethod.GET;

        #endregion

        #region Empty TextBox

        /* Region without value and htmlAttributes for input textbox*/

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                        Uri url, string labelField)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                        Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, valueField, DefaultMinChars);
        }
                
        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, valueField, minChars,
                                       selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                Uri url, string labelField, string valueField,
                                                int minChars, string selectionCallback, string errorCallback,
                                                string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBox(helper, name, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback,
                                       errorMessage, noResultsMessage, DefaultHttpMethod);
        } 

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name,
                                                Uri url, string labelField, string valueField,
                                                int minChars, string selectionCallback, string errorCallback,
                                                string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            return AutoCompleteTextBox(helper, name, null, (object)null, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback,
                                       errorMessage, noResultsMessage, httpMethod);
        } 

        #endregion

        #region TextBox With Initial Value

        /* Region without htmlAttributes for input textbox*/

        /// <summary>
        /// It's discouraged to provide a non null value as the 'value' argument
        /// because the autocomplete textbox
        /// should be blank when the page is loaded, so no value should be provided.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name of the input control.</param>
        /// <param name="value">The value displaied in the control 
        /// when the page is loaded.</param>
        /// <returns></returns>
        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper htmlHelper, string name, object value,
                                                        Uri url, string labelField)
        {
            return AutoCompleteTextBox(htmlHelper, name, value, url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                        Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBox(helper, name, value, url, labelField, valueField, DefaultMinChars);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars)
        {
            return AutoCompleteTextBox(helper, name, value, url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback)
        {
            return AutoCompleteTextBox(helper, name, value, url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBox(helper, name, value, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage)
        {
            return AutoCompleteTextBox(helper, name, value, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBox(helper, name, value, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, 
                                       errorMessage, noResultsMessage, DefaultHttpMethod);
        }


        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value,
                                                Uri url, string labelField, string valueField,
                                                int minChars, string selectionCallback, string errorCallback,
                                                string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            return AutoCompleteTextBox(helper, name, value, (object)null, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, 
                                       errorMessage, noResultsMessage, httpMethod);
        } 

        #endregion

        #region TextBox with Custom Html Attributes

        /* Region with all the 3 arguments for input textbox with HtmlAttributes as object*/

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes, 
                                                        Uri url, string labelField)
        {
            return AutoCompleteTextBox(htmlHelper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes, 
                                                        Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField, DefaultMinChars);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes,
                                                 Uri url, string labelField, string valueField,
                                                 int minChars)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes, 
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes, 
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes, 
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes,
                                                       Uri url, string labelField, string valueField,
                                                       int minChars, string selectionCallback, string errorCallback,
                                                       string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage, DefaultHttpMethod);
        }


        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes, 
                                                Uri url, string labelField, string valueField,
                                                int minChars, string selectionCallback, string errorCallback,
                                                string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            return AutoCompleteTextBox(helper, name, value, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback,
                                       errorMessage, noResultsMessage, httpMethod);
        } 

        #endregion

        #region TextBox with Custom Html Attributes as IDictionary

        /* Region with all the 3 arguments for input textbox with HtmlAttributes as IDictionary*/

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField)
        {
            return AutoCompleteTextBox(htmlHelper, name, value, htmlAttributes, url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBox(helper, name, value, htmlAttributes, url, labelField, valueField, DefaultMinChars);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes,
                                             Uri url, string labelField, string valueField,
                                             int minChars)
        {
            return AutoCompleteTextBox(helper, name, value, htmlAttributes, url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback)
        {
            return AutoCompleteTextBox(helper, name, value, htmlAttributes, url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBox(helper, name, value, htmlAttributes, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage)
        {
            return AutoCompleteTextBox(helper, name, value, htmlAttributes, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBox(helper, name, value, htmlAttributes, url, labelField, valueField,
                                       minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage);
        }
        
        public static MvcHtmlString AutoCompleteTextBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField, int minChars,
                                                        string selectionCallback, string errorCallback ,
                                                        string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            string scriptBlock = GetInitializeAutoCompleteScript(htmlHelper, name, url, labelField, valueField, minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage, httpMethod);
            MvcHtmlString textBox = htmlHelper.TextBox(name, value, htmlAttributes);
            return MvcHtmlString.Create(scriptBlock + textBox.ToString());
        }

        #endregion

        #region StronglyTypedHelpers With Initial Value

        /* Region without htmlAttributes for input textbox*/

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url)
        {
            string labelField = ExpressionHelper.GetExpressionText(expression);
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, valueField, DefaultMinChars);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback,
                                                                           string errorMessage)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback,
                                                                           string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback,
                                          errorMessage, noResultsMessage, DefaultHttpMethod);
        }


        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback,
                                                                           string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, (object)null, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback,
                                          errorMessage, noResultsMessage, httpMethod);
        }

        #endregion

        #region StronglyTypedHelpers with Custom Html Attributes

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url)
        {
            string labelField = ExpressionHelper.GetExpressionText(expression);
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField, DefaultMinChars);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback,
                                                                           string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes,
                                                                           Uri url, string labelField, string valueField, int minChars,
                                                                           string selectionCallback, string errorCallback,
                                                                           string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes), url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage, httpMethod);
        }


        #endregion
                
        #region StronglyTypedHelpers with Custom Html Attributes as IDictionary

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                   Uri url)
        {
            string labelField = ExpressionHelper.GetExpressionText(expression);
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, labelField);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField, string valueField)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, valueField, DefaultMinChars);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, valueField, minChars, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, valueField, minChars, selectionCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                        Uri url, string labelField, string valueField,
                                                        int minChars, string selectionCallback, string errorCallback,
                                                        string errorMessage)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, errorMessage, null);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField, string valueField,
                                                                           int minChars, string selectionCallback, string errorCallback,
                                                                           string errorMessage, string noResultsMessage)
        {
            return AutoCompleteTextBoxFor(htmlHelper, expression, htmlAttributes, url, labelField, valueField,
                                          minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage);
        }

        public static MvcHtmlString AutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes,
                                                                           Uri url, string labelField, string valueField, int minChars,
                                                                           string selectionCallback, string errorCallback,
                                                                           string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            
            string scriptBlock = GetInitializeAutoCompleteScript(htmlHelper, name, url, labelField, valueField, minChars, selectionCallback, errorCallback, errorMessage, noResultsMessage, httpMethod);
            MvcHtmlString textBox = htmlHelper.TextBoxFor(expression, htmlAttributes);
            return MvcHtmlString.Create(scriptBlock + textBox.ToString());
        }


        #endregion

        #region Helper Methods

        private static string GetInitializeAutoCompleteScript(HtmlHelper htmlHelper, string name,
                                                              Uri url, string labelField, string valueField,
                                                              int minChars, string selectionCallback, string errorCallback,
                                                              string errorMessage, string noResultsMessage, HttpMethod httpMethod)
        {
            const string defaultMessage = "A value must be provided for the specified argument.";
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(string.Format("Required argument: name.\r\n{0}", defaultMessage));
            }
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException(string.Format("Required argument: fullName.\r\n{0}", defaultMessage));
            }

            if (url == null)
            {
                throw new ArgumentException(string.Format("Required argument: url for: {0}\r\n{1}", name, defaultMessage));
            }
            if (string.IsNullOrEmpty(url.OriginalString))
            {
                throw new ArgumentException(string.Format("Required argument: url for: {0}\r\n{1}", name, defaultMessage));
            }
            if (string.IsNullOrEmpty(valueField))
            {
                throw new ArgumentException(string.Format("Required argument: valueField for: {0}\r\n{1}", name, defaultMessage));
            }

            string controlId = fullName;
            string absoluteUrl = UrlHelper.GenerateContentUrl(url.ToString(), htmlHelper.ViewContext.HttpContext);

            // script with the invocation of InitializeAutocComplete on the rendered TextBox
            TagBuilder scriptTagBuilder = new TagBuilder("script");
            scriptTagBuilder.MergeAttribute("type", "text/javascript");

            AutoCompleteSettingsDto settings = AutoCompleteSettingsMapper.GetDtoFrom
                (controlId,
                 new Uri(absoluteUrl, UriKind.RelativeOrAbsolute),
                 httpMethod,
                 minChars,
                 labelField,
                 valueField,
                 selectionCallback,
                 errorCallback,
                 errorMessage,
                 noResultsMessage);
            string initializeAutoComplete = AutoCompleteInitializer.GetJsInitialization(settings);
            scriptTagBuilder.SetInnerText(initializeAutoComplete);
            return scriptTagBuilder.ToString(TagRenderMode.Normal);
        }
        
        #endregion
    }
}
