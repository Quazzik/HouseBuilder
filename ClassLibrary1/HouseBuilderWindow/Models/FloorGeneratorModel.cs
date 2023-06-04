using ReactiveUI;
using System;
using System.ComponentModel;
using System.Windows;

namespace HouseBuilderWindow.Models
{
    public class FloorGeneratorModel : ReactiveObject
    {
        public FloorGeneratorModel()
        {
        }

        public string Label { get; set; }

        private double _area;
        public double Area
        {
            get => _area;
            set
            {
                this.RaiseAndSetIfChanged(ref _area, value);
            }
        }
    }
}
