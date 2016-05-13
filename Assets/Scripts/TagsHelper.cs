using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    static class TagsHelper
    {
        public static string Incinerables = "Incinerable";
        public static string[] Recyclables = { "Aluminium", "Pet", "Glass", "Paper", "Battery" };
        public static Dictionary<string, string> recyclableToThrash = new Dictionary<string, string>
        {
            {"Aluminium", "AluThrash"},
            {"Pet", "PetThrash"},
            {"Glass", "GlassThrash"},
            {"Paper", "PaperThrash"},
            {"Battery", "BatteryThrash"}
        };
        public static string Wall = "Wall";
    }
}
