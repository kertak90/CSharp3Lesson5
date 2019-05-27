using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib.Entityes;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Lesson1.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecepientsData _RecepientsData;
        private readonly IRecipientsListData recipientsListData;
        private readonly ISendersData sendersData;
        private readonly IMailMessagesData mailMessagesData;
        private readonly IMailLists mailLists;
        private readonly IServerData serverData;
        private readonly ISchedulerTasksData schedulerTasksData;
        private string _Title = "Рассыльщик почты v1";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private CollectionViewSource _FiltredRecipientsSource;

        private void OnRecipientsFiltred(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Recipient recipient) || string.IsNullOrWhiteSpace(_RecipientNameFilterText)) return;

            if (recipient.Name is null
                || recipient.Name.IndexOf(_RecipientNameFilterText, StringComparison.OrdinalIgnoreCase) < 0)
                e.Accepted = false;
        }

        public ICollectionView FiltredRecipients => _FiltredRecipientsSource?.View;

        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set
            {
                if (!Set(ref _Recipients, value)) return;

                if (_FiltredRecipientsSource != null)
                    _FiltredRecipientsSource.Filter -= OnRecipientsFiltred;
                _FiltredRecipientsSource = new CollectionViewSource { Source = value };
                _FiltredRecipientsSource.Filter += OnRecipientsFiltred;

                RaisePropertyChanged(nameof(FiltredRecipients));
            }
        }

        private Recipient _SelectedRecepient;

        public Recipient SelectedRecepient
        {
            get => _SelectedRecepient;
            set => Set(ref _SelectedRecepient, value);
        }

        private string _RecipientNameFilterText;

        public string RecipientNameFilterText
        {
            get => _RecipientNameFilterText;
            set
            {
                if (!Set(ref _RecipientNameFilterText, value)) return;
                _FiltredRecipientsSource?.View?.Refresh();
            }
        }

        #region Commands
        public ICommand RefreshDataCommand { get; }
        public ICommand WriteRecipientDataCommand { get; }
        public ICommand CreateNewRecepientCommand { get; }
        
        #endregion

        public MainWindowViewModel(
            IRecepientsData RecepientsData,
            IRecipientsListData recipientsListData,
            ISendersData sendersData,
            IMailMessagesData mailMessagesData,
            IMailLists mailLists,
            IServerData serverData,
            ISchedulerTasksData schedulerTasksData)
        {
            _RecepientsData = RecepientsData;
            this.recipientsListData = recipientsListData;
            this.sendersData = sendersData;
            this.mailMessagesData = mailMessagesData;
            this.mailLists = mailLists;
            this.serverData = serverData;
            this.schedulerTasksData = schedulerTasksData;
            RefreshDataCommand = new RelayCommand(OnRefreshDataCommandExecuted, CanrefreshDataCommandExecute);
            WriteRecipientDataCommand = new RelayCommand<Recipient>(OnWriteRecepientDataCommandExecute, CanWriteRecipientDataCommandExecute);
            CreateNewRecepientCommand = new RelayCommand(OnCreateNewRecepientCommandExecute, CanCreateNewRecepientCommandExecute);
        }

        private bool CanCreateNewRecepientCommandExecute() => true;

        private void OnCreateNewRecepientCommandExecute()
        {
            var new_recipient = new Recipient { Name = "Recipient", Email = "recipient@address.com" };
            var id = _RecepientsData.Add(new_recipient);
            if (id == 0) return;
            Recipients.Add(new_recipient);
            SelectedRecepient = new_recipient;

        }

        private bool CanWriteRecipientDataCommandExecute(Recipient recipient) => recipient != null;

        private void OnWriteRecepientDataCommandExecute(Recipient recipient)
        {
            _RecepientsData.Edit(recipient);
            _RecepientsData.SaveChanges();
        }

        private bool CanrefreshDataCommandExecute() => true;

        private void OnRefreshDataCommandExecuted() => LoadData();

        private void LoadData()
        {            
            var recipients = _RecepientsData.GetAll();
            Recipients = new ObservableCollection<Recipient>(recipients);
        }
    }
}
