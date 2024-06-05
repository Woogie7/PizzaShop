using iTextSharp.text.pdf.qrcode;
using PizzaShop.Application.DTOs;
using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PizzaShop.WPF.VIewModel;

internal class ReportViewModel : ObservaleObject
{

    private readonly CartViewModel _cartViewModel;

    private ObservableCollection<OrderDto> _orders;

    public ObservableCollection<OrderDto> Orders
    {
        get { return _orders; }
        set
        {
            _orders = value;
            OnPropertyChanged();
        }
    }

    private int _sumQuantity;
    public int SumQuantity
    {
        get { return _sumQuantity; }
        set
        {
            _sumQuantity = value;
            OnPropertyChanged();
        }
    }

    private decimal _sumTotalAmount;
    public decimal SumTotalAmount
    {
        get { return _sumTotalAmount; }
        set
        {
            _sumTotalAmount = value;
            OnPropertyChanged();
        }
    }

    private string _userName;

    public string UserName
    {
        get { return _userName; }
        set { _userName = value;
            OnPropertyChanged();
        }
    }

    private string _orderNumber;

    public string OrderNumber
    {
        get { return _orderNumber; }
        set
        {
            _orderNumber = value;
            OnPropertyChanged();
        }
    }
    private DateTime _dateIssued;

    public DateTime DateIssued
    {
        get { return DateTime.Now; }
    }

    private bool _isEnabled = true;

    public bool IsEnabled
    {
        get { return _isEnabled; }
        set
        {
            if (_isEnabled != value)
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
    }

    private BitmapImage _qRCodeImage;

    public BitmapImage QRCodeImage
    {
        get { return _qRCodeImage; }
        set
        {
            _qRCodeImage = value;
            OnPropertyChanged();
        }
    }

    public ICommand PrintPdfFile { get; set; }


    public ReportViewModel(CartViewModel cartViewModel)
    {
        _cartViewModel = cartViewModel;

        Orders = _cartViewModel.Orders;
        SumQuantity = _cartViewModel.SumQuantity;
        SumTotalAmount = _cartViewModel.SumTotalAmount;
        UserName = _cartViewModel.Orders[1].UserName;
        OrderNumber = _cartViewModel.Orders[1].OrderNumber;

        GenerateQrCode();

        PrintPdfFile = new PrintPdfFile();
    }

    private void GenerateQrCode()
    {
        string orderData = $"Имя клиента: {UserName}, Дата выдачи: {DateTime.Now}, Номер заказа: {OrderNumber}";
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(orderData, QRCodeGenerator.ECCLevel.Q);
        QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
        Bitmap qrCodeBitmap = qrCode.GetGraphic(20); // 20 - размер модуля в пикселях

        // Преобразование Bitmap в BitmapImage
        using (MemoryStream memory = new MemoryStream())
        {
            qrCodeBitmap.Save(memory, ImageFormat.Png);
            memory.Position = 0;

            BitmapImage qrCodeImage = new BitmapImage();
            qrCodeImage.BeginInit();
            qrCodeImage.StreamSource = memory;
            qrCodeImage.CacheOption = BitmapCacheOption.OnLoad;
            qrCodeImage.EndInit();

            // Присваивание QR-кода свойству
            QRCodeImage = qrCodeImage;
        }
    }
}
