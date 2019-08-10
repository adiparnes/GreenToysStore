using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GreenToys.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? TypeOfToyID { get; set; }
        public int? ToyID { get; set; }
        public int? CustomerID { get; set; }
        public int? MembershipTypeID { get; set; }
        public string UserID { get; set; }
        public int? ToyRentalID { get; set; }


        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if(ToyID!=null&& ToyID > 0)
                {
                    param.Append(String.Format("{0}",ToyID));
                }

                if (TypeOfToyID != null && TypeOfToyID > 0)
                {
                    param.Append(String.Format("{0}", TypeOfToyID));
                }

                if (CustomerID != null && CustomerID > 0)
                {
                    param.Append(String.Format("{0}", CustomerID));

                }

                if (MembershipTypeID != null && MembershipTypeID > 0)
                {
                    param.Append(String.Format("{0}", MembershipTypeID));
                }

                if (UserID != null && UserID.Trim().Length > 0)
                {
                    param.Append(String.Format("{0}", UserID));

                }
                if (ToyRentalID != null && ToyRentalID > 0)
                {
                    param.Append(String.Format("{0}", ToyRentalID));
                }


                return param.ToString();
            }

        }
    }
}