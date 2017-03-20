using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MediaBindTest
{
    public class PlayViewModel
    {
        public ICommand OnPlayButton { get; set; }
        private MediaElement _mediaElement;

        public PlayViewModel()
        {
            OnPlayButton = new CommandHandler<MediaElement>((o) => { Play(o); });
        }

        public void Play(object obj)
        {
            try
            {
                _mediaElement = obj as MediaElement;
                _mediaElement.Source = new Uri("ms-appx:///Assets/hello.mp3");
                _mediaElement.Play();
            }
            catch (Exception exception)
            {
            }
        }
    }

    public class CommandHandler<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<T> _action;

        public CommandHandler(Action<T> action)
        {
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._action((T)parameter);
        }
    }
}