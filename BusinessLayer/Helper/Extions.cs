using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helper
{
    public static class Extions
    {
        public static string formattedDate(DateTime date)
        {
            return ((DateTime)date).ToString("dd-MMM-yyyy");
        }
    }
}
