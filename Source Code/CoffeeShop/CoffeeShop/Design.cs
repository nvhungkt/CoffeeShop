using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public static class Design
    {
        private static Color btnColorSuccess;
        private static Color btnColorDanger;
        private static Color btnColorInfo;

        private static Color frmBackColor;
        private static Color frmForeColor;
        private static Color groupBackColor;
        private static Color dgvBackColor;

        public static bool isDarkTheme;

        public static void SetTheme()
        {
            if (isDarkTheme)
            {
                //btnColorSuccess = Color.FromArgb(85, 139, 47);
                btnColorSuccess = Color.FromArgb(104, 159, 56);
                btnColorDanger = Color.FromArgb(229, 57, 57);
                btnColorInfo = Color.FromArgb(0, 151, 167);

                frmBackColor = Color.FromArgb(66, 66, 66);
                frmForeColor = Color.FromArgb(255, 255, 255);
                groupBackColor = Color.FromArgb(99, 99, 99);
                dgvBackColor = Color.FromArgb(99, 99, 99);
            }
            else
            {
                btnColorSuccess = Color.FromArgb(156, 204, 101);
                btnColorDanger = Color.FromArgb(255, 82, 82);
                btnColorInfo = Color.FromArgb(38, 198, 218);

                frmBackColor = Color.FromArgb(255, 255, 255);
                frmForeColor = Color.FromArgb(0, 0, 0);
                groupBackColor = Color.FromArgb(255, 255, 255);
                dgvBackColor = Color.FromArgb(255, 255, 255);
            }
        }

        public static void ApplyButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void ApplyButtonSuccess(Button btn)
        {
            btn.BackColor = btnColorSuccess;
            ApplyButton(btn);
        }

        public static void ApplyButtonDanger(Button btn)
        {
            btn.BackColor = btnColorDanger;
            ApplyButton(btn);
        }

        public static void ApplyButtonInfo(Button btn)
        {
            btn.BackColor = btnColorInfo;
            ApplyButton(btn);
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
            dgv.ForeColor = Color.Black;
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
