using System;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using SqlDataAccess;

namespace DBTools
{
    public partial class frmBrowse : Form
    {
        private SqlDataAccess.SqlDataAccess m_db;
        private TreeNode m_selectedNode;
        private string m_path;
        private string[] m_pathParts;
        private bool m_includeFiles;
        private bool m_unload = false;

        #region Form event handlers
        public frmBrowse(string defaultPath, bool includeFiles)
        {
            InitializeComponent();

            DataTable dt = null;
            TreeNode parentNode;
            string drive;
            string driveNodeDesc;
            int mark;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.m_includeFiles = includeFiles;
                this.m_path = defaultPath;

                if (Path.HasExtension(defaultPath))
                {
                    this.m_path = Path.GetDirectoryName(defaultPath);
                }
                else
                {
                    if (defaultPath.Count(x => x == '\\') > 1)
                    {
                        if (Directory.Exists(defaultPath))
                        {
                            this.m_path = defaultPath;
                        }
                        else
                        {
                            mark = defaultPath.LastIndexOf("\\");
                            this.m_path = defaultPath.Substring(0, mark);
                        }
                    }
                    else
                    {
                        this.m_path = defaultPath;
                    }
                }

                txtFolder.Text = this.m_path;

                if (includeFiles)
                {
                    txtFolder.ReadOnly = true;
                }
                else
                {
                    lblFileName.Visible = false;
                    txtFileName.Visible = false;
                    cmdOK.Location = new Point(cmdOK.Location.X, cmdOK.Location.Y - 25);
                    cmdCancel.Location = new Point(cmdCancel.Location.X, cmdCancel.Location.Y - 25);
                    this.Height = this.Height - 25;
                }

                m_db = new SqlDataAccess.SqlDataAccess(Program.CurrentServer.ConnectionContext.ConnectionString);

                // Split up the path we are going to drill down to into its
                // component folders. Appending the extra backslash for paths 
                // that aren't drive roots adds one empty element to the end 
                // of the array. This element is used to signal the end of 
                // the recursion that will be used to add additional nodes
                // to the tree.
                //
                // Example:
                //   defaultPath = C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup
                //   m_pathParts will contain:
                //     0 = C:
                //     1 = Program Files
                //     2 = Microsoft SQL Server
                //     3 = MSSQL10.SQLEXPRESS
                //     4 = MSSQL
                //     4 = Backup
                //     5 = <Empty string>
                if (defaultPath.Length == 3)
                {
                    this.m_pathParts = defaultPath.Split('\\');
                }
                else
                {
                    // If a file path was passed in, we get its directory portion. 
                    // If we did that to a folder path, we'd lose the last folder
                    if (Path.HasExtension(defaultPath))
                    {
                        this.m_pathParts = (Path.GetDirectoryName(defaultPath) + Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
                    }
                    else
                    {
                        this.m_pathParts = (defaultPath + Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
                    }
                }

                dt = this.m_db.ExecuteDataTable("exec xp_fixeddrives");

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        drive = dr["Drive"].ToString() + ":";
                        driveNodeDesc = drive.ToUpper() + "\\ (" + Utility.FormatSize((long)(int)dr["MB Free"] * 1024 * 1024) + " free)";
                        parentNode = tvwMain.Nodes.Add(drive, driveNodeDesc);
                        parentNode.ImageKey = "FolderClosed";
                        parentNode.SelectedImageKey = "FolderOpen";
                        parentNode.Tag = drive + Path.DirectorySeparatorChar;

                        if (dt.Rows.IndexOf(dr) == 0)
                        {
                            this.m_selectedNode = parentNode;
                        }

                        if (defaultPath != "" && defaultPath.Substring(0, 1).ToLower() == drive.Substring(0, 1).ToLower())
                        {
                            // We must append a path separator after the drive 
                            // designation since Path.Combine(), which is used
                            // in AddChildren(), doesn't work if you have a 
                            // relative drive path
                            AddChildren(parentNode, drive + Path.DirectorySeparatorChar, this.m_pathParts[1], 1);
                            RemoveSystemItems(parentNode);
                        }
                    }
                }

                this.m_selectedNode.EnsureVisible();
                this.m_selectedNode.Expand();
                tvwMain.SelectedNode = this.m_selectedNode;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "New", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private void frmBrowse_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.m_db != null)
                {
                    m_db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "frmBrowse_FormClosing", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc event handlers
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFolder.Text))
                {
                    Utility.ShowError("Path cannot be blank.");
                    return;
                }

                if (this.m_includeFiles && string.IsNullOrEmpty(txtFileName.Text))
                {
                    Utility.ShowError("File name cannot be blank.");
                    return;
                }

                if (this.m_includeFiles)
                {
                    this.m_path = Path.Combine(txtFolder.Text, txtFileName.Text);
                }
                else
                {
                    this.m_path = txtFolder.Text;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void tvwMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.ImageKey == "File")
                {
                    txtFileName.Text = e.Node.Text;
                }
                else
                {
                    txtFolder.Text = e.Node.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "tvwMain_AfterSelect", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void tvwMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                HandleNodeSelection(tvwMain.GetNodeAt(e.X, e.Y), "Mouse");
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "tvwMain_MouseDoubleClick", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void tvwMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Right)
                {
                    HandleNodeSelection(tvwMain.SelectedNode, "Keyboard");
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "tvwMain_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc routines
        private void AddChildren(TreeNode parentNode, string folderPath, string nextFolder, int index)
        {
            DataTable dt = null;
            TreeNode node;
            string sql;
            string subDir;

            try
            {
                if (this.m_includeFiles)
                {
                    sql = "Create table #DirTreeTemp (subdirectory varchar(256), depth int, [file] int) ";
                }
                else
                {
                    sql = "Create table #DirTreeTemp (subdirectory varchar(256), depth int) ";
                }

                sql = sql + "INSERT INTO #DirTreeTemp exec xp_dirtree '{0}', 1, {1} ";
                sql = sql + "select * from #DirTreeTemp order by {2} ";
                sql = sql + "drop table #DirTreeTemp";

                if (this.m_includeFiles)
                {
                    sql = string.Format(sql, folderPath, 1, "[file], subdirectory Asc");
                }
                else
                {
                    sql = string.Format(sql, folderPath, 0, "subdirectory Asc");
                }

                dt = this.m_db.ExecuteDataTable(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        subDir = dr["subdirectory"].ToString();
                        node = parentNode.Nodes.Add(subDir);
                        node.Tag = Path.Combine(folderPath, subDir);

                        if (this.m_includeFiles)
                        {
                            if ((int) dr["file"] == 0)
                            {
                                node.ImageKey = "FolderClosed";
                                node.SelectedImageKey = "FolderOpen";
                            }
                            else
                            {
                                node.ImageKey = "File";
                                node.SelectedImageKey = "File";
                            }
                        }
                        else
                        {
                            node.ImageKey = "FolderClosed";
                            node.SelectedImageKey = "FolderOpen";
                        }

                        if (nextFolder == "")
                        {
                            this.m_selectedNode = parentNode;
                        }

                        if (subDir.ToLower() == nextFolder.ToLower())
                        {
                            AddChildren(node, node.Tag.ToString(), this.m_pathParts[index + 1], index + 1);
                        }
                    }
                }
                else
                {
                    if (nextFolder == "")
                    {
                        this.m_selectedNode = parentNode;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "AddChildren", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private void RemoveSystemItems(TreeNode driveNode)
        {
            string name;

            try
            {
                for (int i = driveNode.Nodes.Count - 1; i != -1; i--)
                {
                    name = driveNode.Nodes[i].Text.ToLower();

                    if (name == "$recycle.bin" ||
                        name == "config.msi" ||
                        name == "documents and settings" ||
                        name == "system volume information" ||
                        name == "recovery")
                    {
                        driveNode.Nodes.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "RemoveSystemItems", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void HandleNodeSelection(TreeNode node, string action)
        {
            try
            {
                if (node != null && node.Nodes.Count == 0)
                {
                    // If the current node represents a file then set the form-level variable 
                    // that holds the selected object path and close the form. Otherwise
                    // we try to add any children and if there are none, and we aren// t
                    // showing files, we assume the user wants to select the given 
                    // folder, so set the path and close the form. If there are children
                    // then we simply expand the node
                    if (node.ImageKey == "File")
                    {
                        if (this.m_includeFiles)
                        {
                            this.m_path = Path.Combine(txtFolder.Text, txtFileName.Text);
                        }
                        else
                        {
                            this.m_path = txtFolder.Text;
                        }

                        if (action == "Mouse")
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                    }
                    else
                    {
                        AddChildren(node, node.Tag.ToString(), "", -1);

                        if (node.Tag.ToString().Length == 3)
                        {
                            RemoveSystemItems(node);
                        }

                        if (this.m_selectedNode.Nodes.Count == 0)
                        {
                            if (!this.m_includeFiles)
                            {
                                this.m_path = txtFolder.Text;

                                if (action == "Mouse")
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            this.m_selectedNode.EnsureVisible();
                            this.m_selectedNode.Expand();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBrowse", "HandleNodeSelection", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Properties
        public string SelectedPath
        {
            get
            {
                return this.m_path;
            }
        }

        public bool Unload
        {
            get
            {
                return this.m_unload;
            }
        }
        #endregion
    }
}
