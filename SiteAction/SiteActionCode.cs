using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;

namespace MANSoftDev.SiteAction
{
    public class SiteActionCode : WebControl
    {
        protected override void CreateChildControls()
        {
            SubMenuTemplate sub = new SubMenuTemplate();
            sub.Text = "Custom Menu";
            sub.Description = "Custom menu with submenu";
            sub.ImageUrl = "/_layouts/images/settingsIcon.png";
            sub.MenuGroupId = 90;
            sub.Sequence = 100;

            Controls.Add(sub);

            MenuItemTemplate item = new MenuItemTemplate("SubMenu");
            item.Description = "A submenu item";
            item.ImageUrl = "/_layouts/images/settingsIcon.png";

            sub.Controls.Add(item);

            SubMenuTemplate sub2 = new SubMenuTemplate();
            sub2.Text = "Custom Menu";
            sub2.Description = "Custom menu with submenu";
            sub2.ImageUrl = "/_layouts/images/settingsIcon.png";

            sub.Controls.Add(sub2);

            item = new MenuItemTemplate("SubMenu");
            item.Description = "A submenu item";
            item.ImageUrl = "/_layouts/images/settingsIcon.png";

            sub2.Controls.Add(item);
        }
    }
}
