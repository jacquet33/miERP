﻿/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using MixERP.Net.Common.Helpers;
using MixERP.Net.Core.Modules.Inventory.Resources;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.WebControls.ScrudFactory;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class ItemGroups : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (ScrudForm scrud = new ScrudForm())
            {
                scrud.KeyColumn = "item_group_id";
                scrud.TableSchema = "core";
                scrud.Table = "item_groups";
                scrud.ViewSchema = "core";
                scrud.View = "item_group_scrud_view";
                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();

                scrud.Text = Titles.ItemGroups;
                scrud.ResourceAssembly = Assembly.GetAssembly(typeof(ItemGroups));
                this.ScrudPlaceholder.Controls.Add(scrud);
            }

            base.OnControlLoad(sender, e);
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.item_groups.item_group_id",
                ConfigurationHelper.GetDbParameter("ItemGroupDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.taxes.tax_id",
                ConfigurationHelper.GetDbParameter("TaxDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.taxes.tax_id", "core.tax_selector_view");
            return string.Join(",", displayViews);
        }
    }
}