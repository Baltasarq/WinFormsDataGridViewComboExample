namespace DataGridViewComboExample
{
    using System.Drawing;
    using System.Windows.Forms;

    public class MainFormView: Form
    {
        public MainFormView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new TableLayoutPanel{ Dock = DockStyle.Fill };

            this.Table = this.BuildGridView();
            this.EdSelected = this.BuildTextBox();

            mainPanel.Controls.Add( this.EdSelected );
            mainPanel.Controls.Add( this.Table );

            this.Controls.Add( mainPanel );
            this.MinimumSize = new Size( 640, 480 );
        }

        TextBox BuildTextBox()
        {
            var toret = new TextBox { Dock = DockStyle.Top, ReadOnly = true };

            return toret;
        }

        DataGridView BuildGridView()
        {
            var toret = new DataGridView { Dock = DockStyle.Fill };
            var columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn(),
                new DataGridViewComboBoxColumn(),
            };
            var columnHeaders = new string[] {
                "Name",
                "Status"
            };

            toret = new DataGridView();
            toret.Columns.AddRange( columns );

            // Column headers
            for(int i = 0; i < columns.Length; ++i) {
                columns[ i ].HeaderText = columnHeaders[ i ];
            }

            return toret;
        }

        public DataGridView Table {
            get; private set;
        }

        public TextBox EdSelected {
            get; private set;
        }
    }
}
