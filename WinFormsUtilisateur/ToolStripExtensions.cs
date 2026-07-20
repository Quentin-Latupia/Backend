using System.Windows.Forms;

namespace WinFormsUtilisateur
{
    public static class ToolStripExtensions
    {
        /// <summary>
        /// Remplace les éléments du menu déroulant par les éléments fournis (Clear puis AddRange).
        /// Usage: menuoptionToolStripMenuItem.ReplaceDropDownItems(planningToolStripMenuItem);
        /// </summary>
        public static void ReplaceDropDownItems(this ToolStripMenuItem menu, params ToolStripItem[] items)
        {
            if (menu == null) return;
            menu.DropDownItems.Clear();
            if (items == null || items.Length == 0) return;
            menu.DropDownItems.AddRange(items);
        }
    }
}
