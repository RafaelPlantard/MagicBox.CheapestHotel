using MagicBox.CheapestHotel.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MagicBox.CheapestHotel.ViewModels
{
    /// <summary>
    /// Defines the properties and commands that the Main view model must to have.
    /// </summary>
    public interface IMainViewModel
    {
        /// <summary>
        /// Call the File Picker to the user select a text file.
        /// </summary>
        ICommand ReadFileCommand { set; get; }

        ObservableCollection<IHotelChoice> ResultHotelChoices { get; set; }
    }
}