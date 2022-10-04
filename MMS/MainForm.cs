using MMS.Controller;
using MMS.Extensions;
using MMS.Forms;
using MMS.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace MMS                                         
{
    public partial class MainForm : Form
    {
        private MaterialController _MaterialController;
        private TransactionController _TransactionController;

        private Dictionary<FeaturePage, Form> _ChildForms = new Dictionary<FeaturePage, Form>();

        private Button currentButton;
        private Form activeForm;

        enum FeaturePage
        {
            Home = 0, Material, Stock, Transaction
        }

        public MainForm()
        {
            InitializeComponent();

            try
            {
                AppInitializer.Instance.Initialize();
            }
            catch(Exception ex)
            {
                MessageBoxEx.ShowError(ex.Message);
                Environment.Exit(1);
            }
            
            Model.MaterialModelAccess materialAccess = new Model.MaterialModelAccess(AppInitializer.Instance.UserDBPath);
            _MaterialController = new MaterialController(materialAccess);
            _TransactionController = new TransactionController(new Model.TransactionModelAccess(AppInitializer.Instance.UserDBPath), materialAccess);            

            MinimumSize = new Size(1800, 700);            
        }
      
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeSettings();                           
                btnHome_Click(btnHome, new EventArgs());
            }
            catch(Exception ex)
            {
                MessageBoxEx.ShowError($"Failed to load settings file:{ex.Message}.");
            }
        }

        private void InitializeSettings()
        {
            SettingsController controller = new SettingsController(AppInitializer.Instance.UserSettingPath);

            Settings.Instance.SetMaterialGroupParameter(controller.GroupParameter);
            Settings.Instance.SetMoveTypeParameter(controller.MoveTypeParameter);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();                    
                    currentButton = (Button)btnSender;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = ThemeFont.GetMainButtonFont();
                    panelNavg.Left = currentButton.Left;
                    panelNavg.Top = currentButton.Top;
                    panelNavg.Height = currentButton.Height;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = ColorTranslator.FromHtml(ThemeColor.NormalButtonColor);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form form = GetChildForm(FeaturePage.Home);
            if (form == null)
            {
                form = new FormHome();
                _ChildForms.Add(FeaturePage.Home, form);
            }
            OpenChildForm(form, sender);            
        }

        private void button1_Click(object sender, EventArgs e)        
        {
            Form form = GetChildForm(FeaturePage.Material);
            if (form == null)
            {
                form = new FormMaterial(_MaterialController);
                _ChildForms.Add(FeaturePage.Material, form);
            }
            OpenChildForm(form, sender);            
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Form form = GetChildForm(FeaturePage.Stock);
            if (form == null)
            {
                form = new FormStock(_TransactionController, _MaterialController);
                _ChildForms.Add(FeaturePage.Stock, form);
            }
            OpenChildForm(form, sender);            
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Form form = GetChildForm(FeaturePage.Transaction);
            if (form == null)
            {
                form = new FormTransaction(_TransactionController, _MaterialController);
                _ChildForms.Add(FeaturePage.Transaction, form);
            }
            OpenChildForm(form, sender);            
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            using (FormSettings form = new FormSettings())
            {
                form.ShowDialog();
            }            
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null && activeForm.Name == childForm.Name)
            {
                return;
            }
            if (activeForm != null)
            {
                activeForm.Hide();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            AddFormIfNotExisted(childForm);

            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void AddFormIfNotExisted(Form childForm)
        {
            if (IsFormExisted(childForm) == false)
            {
                this.panelDesktop.Controls.Add(childForm);
            }
        }

        private bool IsFormExisted(Form childForm)
        {
            foreach (Form form in panelDesktop.Controls)
            {
                if (form.Text == childForm.Text)
                {
                    return true;
                }
            }

            return false;
        }

        private Form GetChildForm(FeaturePage page)
        {
            if (_ChildForms.ContainsKey(page) == true)
            {
                return _ChildForms[page];
            }
            else
                return null;
        }
    }
}
