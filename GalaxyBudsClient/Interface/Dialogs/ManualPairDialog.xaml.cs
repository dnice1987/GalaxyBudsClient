using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CSScriptLib;
using GalaxyBudsClient.Bluetooth;
using GalaxyBudsClient.Model.Attributes;
using GalaxyBudsClient.Model.Constants;
using GalaxyBudsClient.Platform;

namespace GalaxyBudsClient.Interface.Dialogs
{
    public sealed class ManualPairDialog : Window
    {
        private readonly IReadOnlyList<String> _modelCache
            = Enum.GetValues(typeof(Models)).Cast<Models>().Where(x => x != Models.NULL)
                .Select(x => x.GetModelMetadata()?.Name ?? string.Empty).ToList();

        public IEnumerable ModelSource => _modelCache;
    
        public readonly ComboBox Device;
        public readonly ComboBox Model;

        public Models SelectedModel { private set; get; } = Models.NULL;
        public string? SelectedDeviceMac { private set; get; }
        
        public ManualPairDialog()
        {
            AvaloniaXamlLoader.Load(this);
            this.AttachDevTools();

            DataContext = this;
            
            Device = this.GetControl<ComboBox>("Device");
            Model = this.GetControl<ComboBox>("Model");
            
            Init();
        }

        public new async Task<TResult> ShowDialog<TResult>(Window owner)
        {
            return await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await Task.Delay(300);
                return await base.ShowDialog<TResult>(owner);
            });
        }

        private async void Init()
        {
            Device.ItemsSource = await BluetoothImpl.Instance.GetDevicesAsync();
        }
        
        private void Cancel_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Close(false);
        }

        private void Apply_OnClick(object? sender, RoutedEventArgs e)
        {
            var modelIndex = Model.SelectedIndex;
            if (modelIndex < 0)
                SelectedModel = Models.NULL;
            else
                SelectedModel = (Models)modelIndex + 1;// +1 because NULL is not in list
            SelectedDeviceMac = (Device.SelectedItem as BluetoothDevice)?.Address;
            this.Close(true);
        }
    }
}