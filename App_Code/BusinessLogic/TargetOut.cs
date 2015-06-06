using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TargetOut
/// </summary>
namespace BusinessLogic
{
    public class TargetOut
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public bool VAT { get; set; }

        public void Save(out string ErrorMessage)
        {
            DataLayer.DataManager.InsertNewTarget(this, out ErrorMessage);
        }

        public static List<TargetOut> GetTargetsList(out string ErrorMessage)
        {
            return DataLayer.DataManager.SelectTargetsList(out ErrorMessage);
        }
    }
}