// 
// PackageManagementOptionsPanel.cs
// 
// Author:
//   Matt Ward <ward.matt@gmail.com>
// 
// Copyright (C) 2013 Matthew Ward
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using MonoDevelop.Components;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Dialogs;
using Xwt;

namespace MonoDevelop.PackageManagement.Gui
{
	class PackageManagementOptionsPanel : OptionsPanel
	{
		readonly PackageManagementOptionsViewModel optionsViewModel = new PackageManagementOptionsViewModel ();

		public override Control CreatePanelWidget ()
		{
			var vbox = new VBox { Spacing = 12 };

			vbox.PackStart (new Label { Markup = "<b>" + GettextCatalog.GetString ("Package Restore") + "</b>" });

			var restoreOnOpenCheck = new CheckBox {
				Label = GettextCatalog.GetString ("_Automatically restore packages when opening a solution."),
				MarginLeft = 12,
				Active = optionsViewModel.IsAutomaticPackageRestoreOnOpeningSolutionEnabled
			};
			restoreOnOpenCheck.Toggled += delegate {
				optionsViewModel.IsAutomaticPackageRestoreOnOpeningSolutionEnabled = restoreOnOpenCheck.Active;
			};
			vbox.PackStart (restoreOnOpenCheck);

			vbox.PackStart (new Label { Markup = "<b>" + GettextCatalog.GetString ("Package Updates") + "</b>" });

			var checkUpdatesOnOpenCheck = new CheckBox {
				Label = GettextCatalog.GetString ("Check for package _updates when opening a solution."),
				MarginLeft = 12,
				Active = optionsViewModel.IsCheckForPackageUpdatesOnOpeningSolutionEnabled
			};
			checkUpdatesOnOpenCheck.Toggled += delegate {
				optionsViewModel.IsCheckForPackageUpdatesOnOpeningSolutionEnabled = checkUpdatesOnOpenCheck.Active;
			};
			vbox.PackStart (checkUpdatesOnOpenCheck);

			return new XwtControl (vbox);
		}
		
		public override void ApplyChanges() => optionsViewModel.SaveOptions ();
	}
}

