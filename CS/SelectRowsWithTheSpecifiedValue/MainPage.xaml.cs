using System.Windows;
using System.Windows.Controls;

namespace SelectRowsWithTheSpecifiedValue {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = new ProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SelectProducts(20);
        }

        private void SelectProducts(double minPrice) {
            tableView.BeginSelection();
            tableView.ClearSelection();
            for (int i = 0; i < grid.VisibleRowCount; i++) {
                int rowHandle = grid.GetRowHandleByVisibleIndex(i);
                if (!grid.IsGroupRowHandle(rowHandle)) {
                    double price = (double)grid.GetCellValue(rowHandle,
                        grid.Columns["UnitPrice"]);
                    if (price >= minPrice)
                        tableView.SelectRow(rowHandle);
                }
            }
            tableView.EndSelection();
        }

    }
}
