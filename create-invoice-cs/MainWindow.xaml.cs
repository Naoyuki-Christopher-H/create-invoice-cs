using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace create_invoice_cs
{
    public partial class MainWindow : Window
    {
        public class InvoiceItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Total => Quantity * UnitPrice;
        }

        private List<InvoiceItem> invoiceItems = new List<InvoiceItem>();

        public MainWindow()
        {
            InitializeComponent();
            dgInvoiceItems.ItemsSource = invoiceItems;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                !decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                MessageBox.Show("Please enter valid item details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newItem = new InvoiceItem
            {
                Name = txtItemName.Text,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            invoiceItems.Add(newItem);
            dgInvoiceItems.Items.Refresh();
            CalculateTotals();

            // Clear input fields
            txtItemName.Text = "";
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtItemName.Focus();
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0;
            foreach (var item in invoiceItems)
            {
                subtotal += item.Total;
            }

            decimal tax = subtotal * 0.10m; // 10% tax
            decimal total = subtotal + tax;

            lblSubtotal.Content = subtotal.ToString("C");
            lblTax.Content = tax.ToString("C");
            lblTotal.Content = total.ToString("C");
        }

        private void GenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter customer information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (invoiceItems.Count == 0)
            {
                MessageBox.Show("Please add at least one item to the invoice.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string invoice = $"INVOICE\n\n";
            invoice += "--------------------------------------------------\n";
            invoice += $"CUSTOMER: {txtCustomerName.Text}\n";
            invoice += $"ADDRESS: {txtCustomerAddress.Text}\n\n";
            invoice += "ITEMS:\n";
            invoice += "--------------------------------------------------\n";

            foreach (var item in invoiceItems)
            {
                invoice += $"{item.Name} ({item.Quantity} x {item.UnitPrice:C}) = {item.Total:C}\n";
            }

            invoice += "--------------------------------------------------\n";
            invoice += $"SUB-TOTAL: {lblSubtotal.Content}\n";
            invoice += $"TAX (10%): {lblTax.Content}\n";
            invoice += $"TOTAL: {lblTotal.Content}\n\n";
            invoice += $"DATE: {DateTime.Now.ToShortDateString()}";

            MessageBox.Show(invoice, "Invoice Generated", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}