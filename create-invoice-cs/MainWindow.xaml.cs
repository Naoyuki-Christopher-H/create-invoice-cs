using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace create_invoice_cs
{
    public partial class MainWindow : Window
    {
        public class InvoiceItem
        {
            public string Name { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Total => Quantity * UnitPrice;
        }

        private readonly ObservableCollection<InvoiceItem> _invoiceItems = new();
        private const decimal TaxRate = 0.10m; // 10% tax

        public MainWindow()
        {
            InitializeComponent();
            dgInvoiceItems.ItemsSource = _invoiceItems;
            ClearInvoiceData();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateItemInputs(out int quantity, out decimal unitPrice))
            {
                return;
            }

            _invoiceItems.Add(new InvoiceItem
            {
                Name = txtItemName.Text.Trim(),
                Quantity = quantity,
                UnitPrice = unitPrice
            });

            ClearItemInputs();
            CalculateTotals();
        }

        private bool ValidateItemInputs(out int quantity, out decimal unitPrice)
        {
            quantity = 0;
            unitPrice = 0m;

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                ShowError("Please enter an item name.");
                txtItemName.Focus();
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
            {
                ShowError("Please enter a valid quantity (must be a positive number).");
                txtQuantity.Focus();
                return false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out unitPrice) || unitPrice <= 0)
            {
                ShowError("Please enter a valid unit price (must be a positive number).");
                txtUnitPrice.Focus();
                return false;
            }

            return true;
        }

        private void ClearItemInputs()
        {
            txtItemName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtItemName.Focus();
        }

        private void ClearInvoiceData()
        {
            _invoiceItems.Clear();
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            UpdateTotals(0, 0, 0);
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0m;
            foreach (var item in _invoiceItems)
            {
                subtotal += item.Total;
            }

            decimal tax = subtotal * TaxRate;
            decimal total = subtotal + tax;

            UpdateTotals(subtotal, tax, total);
        }

        private void UpdateTotals(decimal subtotal, decimal tax, decimal total)
        {
            lblSubtotal.Content = subtotal.ToString("C");
            lblTax.Content = tax.ToString("C");
            lblTotal.Content = total.ToString("C");
        }

        private void GenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInvoice())
            {
                return;
            }

            var invoice = GenerateInvoiceText();
            MessageBox.Show(invoice, "Invoice Generated", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool ValidateInvoice()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                ShowError("Please enter customer name.");
                txtCustomerName.Focus();
                return false;
            }

            if (_invoiceItems.Count == 0)
            {
                ShowError("Please add at least one item to the invoice.");
                return false;
            }

            return true;
        }

        private string GenerateInvoiceText()
        {
            return $"""
                INVOICE
                --------------------------------------------------
                CUSTOMER: {txtCustomerName.Text.Trim()}
                ADDRESS: {txtCustomerAddress.Text.Trim()}
                
                ITEMS:
                --------------------------------------------------
                {GetItemsText()}
                --------------------------------------------------
                SUB-TOTAL: {lblSubtotal.Content}
                TAX (10%): {lblTax.Content}
                TOTAL: {lblTotal.Content}
                
                DATE: {DateTime.Now:yyyy-MM-dd}
                """;
        }

        private string GetItemsText()
        {
            var itemsText = "";
            foreach (var item in _invoiceItems)
            {
                itemsText += $"{item.Name} ({item.Quantity} x {item.UnitPrice:C}) = {item.Total:C}\n";
            }
            return itemsText;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (dgInvoiceItems.SelectedItem is InvoiceItem selectedItem)
            {
                _invoiceItems.Remove(selectedItem);
                CalculateTotals();
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            if (_invoiceItems.Count > 0 ||
                !string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                !string.IsNullOrWhiteSpace(txtCustomerAddress.Text))
            {
                var result = MessageBox.Show("Are you sure you want to clear all invoice data?",
                    "Confirm Clear", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ClearInvoiceData();
                }
            }
        }
    }
}