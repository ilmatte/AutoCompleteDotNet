Notes on jquery-ui.css

Such stylesheet has been produced with the JQuery UI ThemeRoller.

The style relative to the Autocomplete widget starts at row: 304.

.ui-autocomplete { position: absolute; cursor: default; font: normal 82.5% inherit; }
.ui-autocomplete-loading { background: white url('images/ui-anim_basic_16x16.gif') right center no-repeat; }

/* workarounds */
* html .ui-autocomplete { width:1px; } /* without this, the menu expands to 100% in IE6 */

The rule: 'ui-autocomplete-loading'
has been removed in stylesheet produced from recent versions because 
the ThemeRoller is not able to produce the required image too.
I modified the stylesheet adding this rule retrieved from a previous version: 1.8.2.
I also added the corresponding image retrieved from the same version (1.8.2).

If you want to see the spinner image in the textbox you need
to place it in a folder named: 'images' in the root of the web application.
If you want to place it elsewhere you need to modify the stylesheet rule
with the desired file path and rebuild the WebControl.

Moreover in the rule:
.ui-autocomplete { position: absolute; cursor: default; font: normal 82.5% inherit; }

the style:
font: normal 82.5% inherit; 
has been added by me in order to have a default style for the item in
the dropdownlist of suggestions.