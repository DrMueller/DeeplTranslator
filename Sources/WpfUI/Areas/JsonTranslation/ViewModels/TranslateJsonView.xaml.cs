using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewModels
{
    /// <summary>
    /// Interaction logic for TranslateJsonView.xaml
    /// </summary>
    public partial class TranslateJsonView : UserControl, IViewMap<TranslateJsonViewModel>
    {
        public TranslateJsonView()
        {
            InitializeComponent();
        }
    }
}