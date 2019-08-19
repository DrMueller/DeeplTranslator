using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Dt.WpfUI.Areas.ResxTranslation.ViewModels
{
    public partial class TranslateResxView : UserControl, IViewMap<TranslateResxViewModel>
    {
        public TranslateResxView()
        {
            InitializeComponent();
        }
    }
}