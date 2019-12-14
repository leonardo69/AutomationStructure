using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Infrastructure.GlobalSettings
{
    public static class GeneralGlobalVariables
    {
        public static int extra_kant = 0;
        public static string hinge_number = "";
        public static string shelf_holder_number = "";
        public static string shelf_skrew_number = "";

        public static string deep_groove_back_panel = "";
        public static string wide_groove_back_panel = "";
        public static string groove_edge_indent_back_panel = "";
        public static string upm_back_slot_space = "";
        public static string upm_back_holder_cut_up = "";
        public static string upm_back_holder_cut_side = "";

        public static string saw_thick = "";
        public static string ratio_dsp_cut = "";
        public static string leavings_dsp_cut = "";

        // Lists
        public static int[] extra_kant_values = {10, 20, 30, 40, 50, 100, 150, 200, 250, 300};
        public static int[] deep_groove_back_panel_values = {5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
        public static double[] wide_groove_back_panel_values = {3, 3.5, 4, 4.5, 5, 6, 7, 8};

    }


}
