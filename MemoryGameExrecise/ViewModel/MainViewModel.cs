using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MemoryGameExrecise.Infra;
using MemoryGameExrecise.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MemoryGameExrecise.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Card> Cards { get; set; }
        private readonly IServiceMemoryGame _serviceMemoryGame;
        
        public ICommand Btn { get; set; }
        public int pic1 { get; set; }
        public bool[] Buttons { get; set; }
        public int CountOfTimes { get; set; }
        public bool flag { get; set; }
        public MainViewModel(IServiceMemoryGame serviceMemoryGame)
        {

            _serviceMemoryGame = serviceMemoryGame;
            
            LoadListFromServer();
            pic1 = -1;
            CountOfTimes = 0;
            InitCommand();

        }
        public void InitCommand()
        {
            Btn = new RelayCommand((p) =>
            {
                if (pic1 == -1)
                {
                    pic1 = int.Parse(p.ToString());
                    Buttons = _serviceMemoryGame.ChangeStatusBeforeChecking(pic1);
                    LoadListFromServer();
                    flag = true;
                }
                else if (flag)
                {
                    int pic2 = int.Parse(p.ToString());
                    Buttons = _serviceMemoryGame.ChangeStatusBeforeChecking(pic2);
                    RaisePropertyChanged("Buttons");
                    LoadListFromServer();
                    flag = false;


                    System.Timers.Timer tmr = new System.Timers.Timer();
                    tmr.Interval = 5000;
                    tmr.Start();
                    tmr.Elapsed += (s, e) =>
                    {
                        Buttons = _serviceMemoryGame.IsMatch(pic1, pic2);

                        LoadListFromServer();
                        pic1 = -1;
                        tmr.Stop();
                    };



                    CountOfTimes++;
                    if (CountOfTimes >= 8)
                    {
                        bool IsFinish = _serviceMemoryGame.CheckFinish();
                        if (IsFinish)
                            _iDialogService.ShowMessage(string.Format("You are right, it only took you {0} guesses!", CountOfTimes), "The game is finish-Results");

                    }

                }
            });
        }
        public void LoadListFromServer()
        {
            bool[] arr;
            Cards = new ObservableCollection<Card>(_serviceMemoryGame.GetIconList(out arr));
            Buttons = arr;
            RaisePropertyChanged("Buttons");
            RaisePropertyChanged("Cards");
        }



    }
}