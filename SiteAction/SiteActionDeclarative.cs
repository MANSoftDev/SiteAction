using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;

namespace MANSoftDev.SiteAction
{
    public class SiteActionDeclarative : WebControl
    {

        protected override void CreateChildControls()
        {
            // Initialize collections
            SubMenus = new List<SubMenuTemplate>();
            FeatureMenus = new Dictionary<string, FeatureMenuTemplate>();

            // Create the SUbMenuTemplates
            SubMenuTemplate submenu = CreateSubMenu();
            Controls.Add(submenu);

            submenu = CreateSubMenu();
            Controls.Add(submenu);

            // Create the FeatureMenuTemplates
            FeatureMenuTemplate featureMenu = CreateFeatureMenu("MANSoftDev_Sub1");
            Controls.Add(featureMenu);

            featureMenu = featureMenu = CreateFeatureMenu("MANSoftDev_Sub2");
            Controls.Add(featureMenu);            
        }

        protected override void OnPreRender(EventArgs e)
        {
            // Add the first level menu items
            while(FeatureMenus["MANSoftDev_Sub1"].Controls.Count != 0)
            {
                MenuItemTemplate menu = FeatureMenus["MANSoftDev_Sub1"].Controls[0] as MenuItemTemplate;
                SubMenus[0].Controls.Add(menu); 
            }

            // Add the second level menu items
            while(FeatureMenus["MANSoftDev_Sub2"].Controls.Count != 0)
            {
                MenuItemTemplate menu = FeatureMenus["MANSoftDev_Sub2"].Controls[0] as MenuItemTemplate;
                SubMenus[1].Controls.Add(menu);
            }

            // Add the second level submenu to the top
            SubMenus[0].Controls.Add(SubMenus[1]);

            base.OnPreRender(e);
        }

        #region Private Methods

        /// <summary>
        /// Create a SubMenuTemplate and add to collection
        /// </summary>
        /// <returns></returns>
        private SubMenuTemplate CreateSubMenu()
        {
            SubMenuTemplate subMenu = new SubMenuTemplate();
            subMenu.Text = "Custom Menu";
            subMenu.Description = "Custom menu with submenu";
            subMenu.ImageUrl = "/_layouts/images/settingsIcon.png";
            subMenu.MenuGroupId = 90;
            subMenu.Sequence = 100;

            SubMenus.Add(subMenu);

            return subMenu;
        }

        /// <summary>
        /// Create FeatureMenuTemplate with the specified groupId and
        /// add to collection
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private FeatureMenuTemplate CreateFeatureMenu(string groupId)
        {
            FeatureMenuTemplate featureMenu = new FeatureMenuTemplate();
            featureMenu.Location = "MANSoftDev.CustomMenu";
            featureMenu.GroupId = groupId;

            FeatureMenus.Add(groupId, featureMenu);

            return featureMenu;
        }

        #endregion

        #region Properties

        private List<SubMenuTemplate> SubMenus { get; set; }
        private Dictionary<string, FeatureMenuTemplate> FeatureMenus { get; set; }

        #endregion

    }
}
