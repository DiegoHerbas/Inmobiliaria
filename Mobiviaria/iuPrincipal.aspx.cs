using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobiviaria
{
    public partial class iuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if(! IsPostBack)
			{
				divAdvertencia.Visible = false;            
            }
		}
    }
}