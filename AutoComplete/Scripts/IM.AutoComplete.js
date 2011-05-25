// Disables right menu for the control whose id is passed as argument.
function DisableContextMenu(id) {
    $("#" + id).bind("contextmenu", function(e) {
        return false;
    });
}

// When invoked, this function initializes autocomplete functionalities for
// the input field whose id is passed as argument.
function InitializeAutocomplete(settings) {
    if (typeof jQuery == 'undefined') {
        // jQuery is not loaded
        alert('jQuery not loaded');
        return;
    }
    if (!jQuery.ui) {
        // jQuery UI not loaded
        alert('jQuery UI not loaded');
        return;
    }
    if (settings.Id == undefined) {
        // Id of the input textbox not specified
        alert('Id of the input textbox not specified');
        return;
    }
    if (settings.Url == undefined) {
        // DataSource url not specified
        alert('Missing DataSource Url');
        return;
    }
    if (settings.ValueField == undefined) {
        // Value of the field to display is not specified
        alert('ValueField is not specified');
        return;
    }
    if (settings.LabelField == undefined) {
        // Value of the field to display after selection, is not specified
        alert('LabelField is not specified');
        return;
    }

    $(function() {
        DisableContextMenu(settings.Id);
        $("#" + settings.Id).autocomplete({
            source: function(request, response) {
                RemoteRequest(request, response, settings);
            }, // end source
            minLength: settings.MinChars,
            select: function(event, ui) {
                if (settings.SelectionCallback == null ||
                    ui.item.label == settings.NoResultsMessage ||
                    ui.item.label == "<" + settings.NoResultsMessage + ">" ||
                    ui.item.label == settings.ErrorMessage ||
                    ui.item.label == "<" + settings.ErrorMessage + ">") {
                    return;
                }
                settings.SelectionCallback(ui.item.object);
            }
        }); // end autocomplete
    });        // end document.ready
}

// Need to control ajax requests race conditions
var previousRequest;

// Invokes the url passed as argument expecting it to return a json result
function RemoteRequest(request, response, settings) {
    var httpMethod = (settings.HttpMethod == undefined || settings.HttpMethod == null) ?
                       "POST" : settings.HttpMethod;
    var contentType = (settings.HttpMethod == undefined || settings.HttpMethod == null) ?
                        "application/x-www-form-urlencoded; charset=utf-8" : "application/json; charset=utf-8";
    previousRequest = $.ajax({
        // Need to control ajax requests race conditions
        beforeSend: function() {
            if ((previousRequest != undefined) && (previousRequest.readyState != 4)) {
                previousRequest.abort();
            }
        },
        type: httpMethod,
        contentType: contentType,
        url: settings.Url,
        dataType: "json",
        data: { startsWith: request.term },
        success: function(data) {
            if ((data == null) || (data.length == 0)) {
                ReturnEmptyResultSet(response, settings.NoResultsMessage);
                return;
            }

            var labelUndefined = ((data[0])[settings.LabelField] == undefined);
            var valueUndefined = ((data[0])[settings.ValueField] == undefined);
            if (labelUndefined || valueUndefined) {
                if (settings.ErrorCallback != null) {
                    var error = "The following properties are not defined in the result object: ";
                    error = labelUndefined ? error + settings.LabelField : error;
                    error = valueUndefined ? error + " " + settings.ValueField : error;
                    settings.ErrorCallback(error);
                }
                ReturnEmptyResultSet(response, settings.ErrorMessage);
                return;
            }
            response($.map(data,
                           function(item) {
                               return MappingFunction(item, settings.LabelField, settings.ValueField);
                           }
                    ) // end map	  
            ); // end response
        }, // end success
        error: function(xmlHttpRequest, status, error) {
            if (settings.ErrorCallback != null) {
                var message = (error == undefined) ? status + ": " + xmlHttpRequest.status : error;
                settings.ErrorCallback(message);
            }
            ReturnEmptyResultSet(response, settings.ErrorMessage);
        } // end error
    });             // end ajax
}

// This function accepts an item and uses it to initialize an object with
// the properties: label, value and object.
// It expects that the item received is an instance of an object supporting
// two properties with the names corresponding to the strings 
// passed as the second and third parameters.
function MappingFunction(item, labelField, valueField) {
    return {
        label: item[labelField],
        value: item[valueField],
        object: item
    }
}

// Used to return an empty result set as autosuggest list.
// The list will be composed of a single line with the message
// passed as argument if it's not null, otherwise no list will appear.
function ReturnEmptyResultSet(response, errorMessage) {
    if (errorMessage != null) {
        var item = new Object();
        item.label = "<" + errorMessage + ">";
        item.value = "";
        response([item]);
    }
    else {
        response(null);
    }
}