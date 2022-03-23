using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using ReactiveUI;
using Kotin_lab6.Models;

namespace Kotin_lab6.ViewModels
{
    internal class SecondViewModel : ViewModelBase
    {
        public SecondViewModel(Note item)
        {
            Name = item.Name;
            Text = item.Text;
            var okEnabled = this.WhenAnyValue(
                    x => x.Name,
                    x => !string.IsNullOrWhiteSpace(x));

            OKButton = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    item.Name = Name;
                    item.Text = Text;
                    return Unit.Default;
                }, okEnabled);
            CancelButton = ReactiveCommand.Create(() => { });
        }
        string name;
        string text;
        public string Name
        {
            get { return name; }
            set { this.RaiseAndSetIfChanged(ref name, value); }
        }
        public string Text
        {
            get { return text; }
            set { this.RaiseAndSetIfChanged(ref text, value); }
        }
        public ReactiveCommand<Unit, Unit> OKButton { get; }
        public ReactiveCommand<Unit, Unit> CancelButton { get; }
    }
}
