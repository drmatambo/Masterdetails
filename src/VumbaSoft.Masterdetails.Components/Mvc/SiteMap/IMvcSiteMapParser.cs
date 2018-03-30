using System.Collections.Generic;
using System.Xml.Linq;

namespace VumbaSoft.Masterdetails.Components.Mvc
{
    public interface IMvcSiteMapParser
    {
        IEnumerable<MvcSiteMapNode> GetNodeTree(XElement siteMap);
    }
}
