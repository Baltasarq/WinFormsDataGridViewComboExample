namespace DataGridViewComboExample
{
    using System.Windows.Forms;

    public class MainForm
    {
        public MainForm()
        {
            this.Form = new MainFormView();

            this.Form.FormClosed += (sender, e) => Application.Exit();
            this.Form.Table.EditingControlShowing +=
                    (sender, e) => this.OnEditingControlShowing( e );
        }

        void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            if ( e.Control is ComboBox comboEdited ) {
                comboEdited.SelectedIndexChanged +=
                    (sender, evt) => this.OnComboSelectedIndexChanged( sender );
                System.Console.WriteLine( "Attached event handler" );
            }

            return;
        }

        void OnComboSelectedIndexChanged(object sender)
        {
            int selectedIndex = ((ComboBox) sender).SelectedIndex;

            selectedIndex = System.Math.Max( 0, selectedIndex );
            string selectedValue = MainFormView.ListBoxItems[ selectedIndex ];

            this.Form.EdSelected.Text = selectedValue;
        }

        // The view of the form
        public MainFormView Form {
            get; private set;
        }
    }
}
