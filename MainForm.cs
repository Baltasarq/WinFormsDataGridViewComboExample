namespace DataGridViewComboExample
{
    using System.Windows.Forms;

    public class MainForm {
        public static readonly string[] ListBoxItems = { "Single", "Married" };

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
                // Can also be set in the column, globally for all combo boxes
                comboEdited.DataSource = ListBoxItems;
                comboEdited.AutoCompleteMode = AutoCompleteMode.Append;
                comboEdited.AutoCompleteSource = AutoCompleteSource.ListItems;

                // Attach event handler
                comboEdited.SelectedValueChanged +=
                    (sender, evt) => this.OnComboSelectedValueChanged( sender );
            }

            return;
        }

        void OnComboSelectedValueChanged(object sender)
        {
            string selectedValue;
            ComboBox comboBox = (ComboBox) sender;
            int selectedIndex = comboBox.SelectedIndex;

            if ( selectedIndex >= 0 ) {
                selectedValue = ListBoxItems[ selectedIndex ];
            } else {
                selectedValue = comboBox.Text;
            }

            this.Form.EdSelected.Text = selectedValue;
        }

        // The view of the form
        public MainFormView Form {
            get; private set;
        }
    }
}
