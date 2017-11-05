using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public class Design
    {
        private static Color btnColorSuccess = Color.FromArgb(156, 204, 101);
        private static Color btnColorDanger = Color.FromArgb(255, 82, 82);
        private static Color btnColorInfo = Color.FromArgb(38, 198, 218);

        private static Color frmBackColor = Color.FromArgb(255, 255, 255);
        private static Color frmForeColor = Color.FromArgb(0, 0, 0);
        private static Color groupBackColor = Color.FromArgb(255, 255, 255);
        private static Color dgvBackColor = Color.FromArgb(255, 255, 255);

        public static void ApplyButtonSuccess(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = btnColorSuccess;
            btn.ForeColor = Color.White;
        }

        public static void ApplyButtonDanger(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = btnColorDanger;
            btn.ForeColor = Color.White;
        }

        public static void ApplyButtonInfo(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = btnColorInfo;
            btn.ForeColor = Color.White;
        }

        public static void ApplyFormColor(Form frm)
        {
            frm.BackColor = frmBackColor;
            frm.ForeColor = frmForeColor;
        }

        public static void ApplyGroupColor(GroupBox group)
        {
            group.BackColor = groupBackColor;
            group.ForeColor = frmForeColor;
        }

        public static void ApplyDGVColor(DataGridView dgv)
        {
            dgv.BackgroundColor = dgvBackColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
